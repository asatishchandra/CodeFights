using System;
using System.Collections.Generic;
using System.Linq;

namespace RaiseMe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<string> input =  new List<string>{ "2014-2015", "2015-2016", "2015 - 2020" };

            ParseSchoolYears(input);
        }

        public static List<int> ParseSchoolYears(List<string> Input)  {

            HashSet<int> schoolYears = new HashSet<int>();
            string[] temp = new string[2];

            foreach (string ele in Input) {
                temp = ele.Split('-');
                int year1 = Convert.ToInt32(temp[0]);
                int year2 = Convert.ToInt32(temp[1]);
                while (year1 <= year2) {
                    if (!schoolYears.Contains(year1))
                        schoolYears.Add(year1);
                    year1++;
                }
                   
            }
            return schoolYears.ToList();
        }

        public static List<string> YearRanges(List<int> input) {
            List<string> yearRanges = new List<string>();
            int startYear = int.MinValue;
            int endYear = 0;

            for (int i = 0; i < input.Count; i++) {
                if (startYear < input.ElementAt(i))
                    startYear = input.ElementAt(i);

                if (i + 1 >= input.Count) {
                    endYear = input.ElementAt(i);
                }
                else {
                    if(input.ElementAt(i + 1) - input.ElementAt(i) > 1) {
                        endYear = input.ElementAt(i);
                        
                        startYear = int.MinValue;

                    }
                }
                string yearString = string.Format("{0}-{1}", startYear, endYear);
                yearRanges.Add(yearString);

            }




            return yearRanges;
        }



    }
}
