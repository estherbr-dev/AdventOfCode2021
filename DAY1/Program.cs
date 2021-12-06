using System;
using System.Net;
using System.IO;

namespace DAY1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i_resultDay1Part1 = 0;
            int i_resultDay1Part2 = 0;

            string[] s_inputLines = System.IO.File.ReadAllLines(@"F:\GitHub\AdventOfCode2021\DAY1\Input.txt");

            #region Solution 1
            int i_previousValue = 0;
            int i_currentValue = 0;

            for(int i = 1; i < s_inputLines.Length; i++)
            {
                i_previousValue = Int32.Parse(s_inputLines[i-1]);
                i_currentValue = Int32.Parse(s_inputLines[i]);
                if(i_currentValue > i_previousValue)
                {
                    i_resultDay1Part1++;
                }
            }

            Console.WriteLine("The answer for DAY 1 question 1 is = {0}", i_resultDay1Part1);
            #endregion

            #region Solution 2

            for(int i = 0; i < s_inputLines.Length; i++)
            {
                if(i+3 < s_inputLines.Length)
                {
                    i_previousValue = Int32.Parse(s_inputLines[i]) + Int32.Parse(s_inputLines[i+1]) + Int32.Parse(s_inputLines[i+2]);
                    i_currentValue = Int32.Parse(s_inputLines[i+1]) + Int32.Parse(s_inputLines[i+2]) + Int32.Parse(s_inputLines[i+3]);

                    if(i_currentValue > i_previousValue)
                    {
                        i_resultDay1Part2++;
                    }
                }
            }
            Console.WriteLine("The answer for DAY 1 question 2 is = {0}", i_resultDay1Part2);
            #endregion
        }
    }
}
