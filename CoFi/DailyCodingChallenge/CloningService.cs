﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DailyCodingChallenge
{
    public interface ICloningService
    {
        T Clone<T>(T source);
    }

    public class CloningService : ICloningService
    {
        public T Clone<T>(T source)
        {
            // Please implement this method
            List<PropertyInfo> deepProps = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(CloneableAttribute), true)
           .Where(ca => ((CloneableAttribute)ca).Mode == CloningMode.Deep)
           .Any()).ToList();

            List<PropertyInfo> shallowProps = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(CloneableAttribute), true)
            .Where(ca => ((CloneableAttribute)ca).Mode == CloningMode.Shallow)
            .Any()).ToList();

            List<PropertyInfo> ignoredProps = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(CloneableAttribute), true)
           .Where(ca => ((CloneableAttribute)ca).Mode == CloningMode.Ignore)
           .Any()).ToList();

            T result = (T)Activator.CreateInstance(typeof(T));

            foreach (var prop in typeof(T).GetProperties())
            {
                var newPropValue = prop.GetValue(source);
                if (ignoredProps.Contains(prop))
                    continue;
                else if (shallowProps.Contains(prop))
                {
                    ShallowClone(prop);
                }
                else
                {
                    prop.SetValue(result, newPropValue);
                    DeepClone(prop);
                }

            }
            return result;
        }

        public T ShallowClone<T>(T source)
        {
            return (T)MemberwiseClone();
        }

        public T DeepClone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
        // Feel free to add any other methods, classes, etc.

    }

    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        
    }

    public enum CloningMode
    {
        Deep = 0,
        Shallow = 1,
        Ignore = 2,
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class CloneableAttribute : Attribute
    {
        public CloningMode Mode { get; }

        public CloneableAttribute(CloningMode mode)
        {
            Mode = mode;
        }
    }

    public class CloningServiceTest
    {
        public class Simple
        {
            public int I;
            public string S { get; set; }
            [Cloneable(CloningMode.Ignore)]
            public string Ignored { get; set; }
            [Cloneable(CloningMode.Shallow)]
            public object Shallow { get; set; }

            public virtual string Computed => S + I + Shallow;
        }

        public struct SimpleStruct
        {
            public int I;
            public string S { get; set; }
            [Cloneable(CloningMode.Ignore)]
            public string Ignored { get; set; }

            public string Computed => S + I;

            public SimpleStruct(int i, string s)
            {
                I = i;
                S = s;
                Ignored = null;
            }
        }

        public class Simple2 : Simple
        {
            public double D;
            public SimpleStruct SS;
            public override string Computed => S + I + D + SS.Computed;
        }

        public class Node
        {
            public Node Left;
            public Node Right;
            public object Value;
            public int TotalNodeCount =>
                1 + (Left?.TotalNodeCount ?? 0) + (Right?.TotalNodeCount ?? 0);
        }

        public ICloningService Cloner = new CloningService();
        public Action[] AllTests => new Action[] {
            SimpleTest,
            SimpleStructTest,
            Simple2Test,
            NodeTest,
            ArrayTest,
            CollectionTest,
            ArrayTest2,
            CollectionTest2,
            MixedCollectionTest,
            RecursionTest,
            RecursionTest2,
            PerformanceTest,
        };

        public static void Assert(bool criteria)
        {
            if (!criteria)
                throw new InvalidOperationException("Assertion failed.");
        }

        public void Measure(string title, Action test)
        {
            test(); // Warmup
            var sw = new Stopwatch();
            GC.Collect();
            sw.Start();
            test();
            sw.Stop();
            // Console.WriteLine($"{title}: {sw.Elapsed.TotalMilliseconds:0.000}ms");
        }

        public void SimpleTest()
        {
            var s = new Simple() { I = 1, S = "2", Ignored = "3", Shallow = new object() };
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(s.Computed == c.Computed);
            Assert(c.Ignored == null);
            Assert(ReferenceEquals(s.Shallow, c.Shallow));
        }

        public void SimpleStructTest()
        {
            var s = new SimpleStruct(1, "2") { Ignored = "3" };
            var c = Cloner.Clone(s);
            Assert(s.Computed == c.Computed);
            Assert(c.Ignored == null);
        }

        public void Simple2Test()
        {
            var s = new Simple2()
            {
                I = 1,
                S = "2",
                D = 3,
                SS = new SimpleStruct(3, "4"),
            };
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(s.Computed == c.Computed);
        }

        public void NodeTest()
        {
            var s = new Node
            {
                Left = new Node
                {
                    Right = new Node()
                },
                Right = new Node()
            };
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(s.TotalNodeCount == c.TotalNodeCount);
        }

        public void RecursionTest()
        {
            var s = new Node();
            s.Left = s;
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(null == c.Right);
            Assert(c == c.Left);
        }

        public void ArrayTest()
        {
            var n = new Node
            {
                Left = new Node
                {
                    Right = new Node()
                },
                Right = new Node()
            };
            var s = new[] { n, n };
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(s.Sum(n1 => n1.TotalNodeCount) == c.Sum(n1 => n1.TotalNodeCount));
            Assert(c[0] == c[1]);
        }

        public void CollectionTest()
        {
            var n = new Node
            {
                Left = new Node
                {
                    Right = new Node()
                },
                Right = new Node()
            };
            var s = new List<Node>() { n, n };
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(s.Sum(n1 => n1.TotalNodeCount) == c.Sum(n1 => n1.TotalNodeCount));
            Assert(c[0] == c[1]);
        }

        public void ArrayTest2()
        {
            var s = new[] { new[] { 1, 2, 3 }, new[] { 4, 5 } };
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(15 == c.SelectMany(a => a).Sum());
        }

        public void CollectionTest2()
        {
            var s = new List<List<int>> { new List<int> { 1, 2, 3 }, new List<int> { 4, 5 } };
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(15 == c.SelectMany(a => a).Sum());
        }

        public void MixedCollectionTest()
        {
            var s = new List<IEnumerable<int[]>> {
                new List<int[]> {new [] {1}},
                new List<int[]> {new [] {2, 3}},
            };
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(6 == c.SelectMany(a => a.SelectMany(b => b)).Sum());
        }

        public void RecursionTest2()
        {
            var l = new List<Node>();
            var n = new Node { Value = l };
            n.Left = n;
            l.Add(n);
            var s = new object[] { null, l, n };
            s[0] = s;
            var c = Cloner.Clone(s);
            Assert(s != c);
            Assert(c[0] == c);
            var cl = (List<Node>)c[1];
            Assert(l != cl);
            var cn = cl[0];
            Assert(n != cn);
            Assert(cl == cn.Value);
            Assert(cn.Left == cn);
        }

        public void PerformanceTest()
        {
            Func<int, Node> makeTree = null;
            makeTree = depth => {
                if (depth == 0)
                    return null;
                return new Node
                {
                    Value = depth,
                    Left = makeTree(depth - 1),
                    Right = makeTree(depth - 1),
                };
            };
            for (var i = 10; i <= 20; i++)
            {
                var root = makeTree(i);
                Measure($"Cloning {root.TotalNodeCount} nodes", () => {
                    var copy = Cloner.Clone(root);
                    Assert(root != copy);
                });
            }
        }

        public void RunAllTests()
        {
            foreach (var test in AllTests)
                test.Invoke();
            Console.WriteLine("Done.");
        }
    }

    //public class Solution
    //{
    //    public static void Main(string[] args)
    //    {
    //        var cloningServiceTest = new CloningServiceTest();
    //        var allTests = cloningServiceTest.AllTests;
    //        while (true)
    //        {
    //            var line = Console.ReadLine();
    //            if (string.IsNullOrEmpty(line))
    //                break;
    //            var test = allTests[int.Parse(line)];
    //            try
    //            {
    //                test.Invoke();
    //            }
    //            catch (Exception)
    //            {
    //                Console.WriteLine($"Failed on {test.GetMethodInfo().Name}.");
    //            }
    //        }
    //        Console.WriteLine("Done.");
    //    }
    //}
}
