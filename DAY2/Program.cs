using System;

namespace DAY2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i_resultDay2Part1 = 0;
            int i_resultDay2Part2 = 0;

            string[] s_inputLines = System.IO.File.ReadAllLines(@"F:\GitHub\AdventOfCode2021\DAY2\Input.txt");

            int i_horizontal = 0;
            int i_depth = 0;

            #region Solution 1
            i_horizontal = 0;
            i_depth = 0;

            foreach(string s_line in s_inputLines)
            {
                if(s_line.Contains("forward "))
                {
                    i_horizontal += Int32.Parse(s_line.Replace("forward ", ""));
                }
                else if(s_line.Contains("down "))
                {
                    i_depth += Int32.Parse(s_line.Replace("down ", ""));
                }
                else if(s_line.Contains("up "))
                {
                    i_depth -= Int32.Parse(s_line.Replace("up ", ""));
                }
            }

            i_resultDay2Part1 = i_horizontal * i_depth;
            Console.WriteLine("The answer for DAY 2 question 1 is = {0}", i_resultDay2Part1);
            #endregion

            #region Solution 2
            i_horizontal = 0;
            i_depth = 0;
            int i_depthAim = 0;

            foreach(string s_line in s_inputLines)
            {
                if(s_line.Contains("forward "))
                {
                    i_horizontal += Int32.Parse(s_line.Replace("forward ", ""));
                    i_depth += (i_depthAim * Int32.Parse(s_line.Replace("forward ", "")));
                }
                else if(s_line.Contains("down "))
                {
                    i_depthAim += Int32.Parse(s_line.Replace("down ", ""));
                }
                else if(s_line.Contains("up "))
                {
                    i_depthAim -= Int32.Parse(s_line.Replace("up ", ""));
                }
            }

            i_resultDay2Part2 = i_horizontal * i_depth;
            Console.WriteLine("The answer for DAY 2 question 2 is = {0}", i_resultDay2Part2);
            #endregion
        }
    }
}
