using System;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DAY3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i_resultDay3Part1 = 0;
            int i_resultDay3Part2 = 0;

            string[] s_inputLines = System.IO.File.ReadAllLines(@"F:\GitHub\AdventOfCode2021\DAY3\Input.txt");
            int i_binaryLength = s_inputLines[0].Length;
            string s_binaryResult = "";
            string s_opositeBinaryResult = "";
            
            #region Solution 1    
            s_binaryResult = "";
            s_opositeBinaryResult = "";
            
            for(int i = 0; i < i_binaryLength; i++)
            {
                int i_1Count = 0;
                int i_0Count = 0;
                foreach(string s_line in s_inputLines)
                {
                    if(s_line[i] == '0')
                    {
                        i_0Count ++;
                    }
                    else if (s_line[i] == '1')
                    {
                        i_1Count ++;
                    }
                }

                if(i_0Count >= i_1Count)
                {
                    s_binaryResult += '0';
                    s_opositeBinaryResult += '1';
                }
                else
                {
                    s_binaryResult += '1';
                    s_opositeBinaryResult += '0';
                }
            }

            i_resultDay3Part1 = (Convert.ToInt32(s_binaryResult, 2) * Convert.ToInt32(s_opositeBinaryResult, 2));
            Console.WriteLine("The answer for DAY 3 question 1 is = {0}", i_resultDay3Part1);
            #endregion

            #region Solution 2
            List<string> l_validLines = s_inputLines.ToList();
            List<string> l_validLinesOpposite = s_inputLines.ToList();

            string s_oxygen = GetFinalValue(l_validLines, 0);
            string s_C02 = GetFinalValue(l_validLinesOpposite, 1);

            i_resultDay3Part2 = (Convert.ToInt32(s_oxygen, 2) * Convert.ToInt32(s_C02, 2));
            Console.WriteLine("The answer for DAY 3 question 2 is = {0}", i_resultDay3Part2);
            #endregion
        }

        static string GetHighestAndLowestBinary(int charToCheck, List<string> arrayToCheck)
        {
            string s_findlargerBinaryValue = "";
            int i_0Count = 0;
            int i_1Count = 0;

            foreach(string s_line in arrayToCheck)
            {
                if(s_line[charToCheck] == '0')
                {
                    i_0Count ++;
                }
                else if (s_line[charToCheck] == '1')
                {
                    i_1Count ++;
                }
            }

            if(i_0Count > i_1Count)
            {
                s_findlargerBinaryValue = "0";
                s_findlargerBinaryValue += '1';
            }
            else if(i_0Count == i_1Count)
            {

                s_findlargerBinaryValue = "1";
                s_findlargerBinaryValue += '0';
            }
            else
            {
                s_findlargerBinaryValue = "1";
                s_findlargerBinaryValue += '0';
            }

            return s_findlargerBinaryValue;
        }

        static string GetFinalValue(List<string> arrayToCheck, int charPos)
        {
            int i_charCount = 0;
            while(arrayToCheck.Count > 1 && i_charCount < arrayToCheck[0].Length)
            {
                string s_chars = "";
                s_chars = GetHighestAndLowestBinary(i_charCount, arrayToCheck);

                for(int o = 0; o < arrayToCheck.Count; o++)
                {
                    string line = arrayToCheck[o];
                    if(line[i_charCount] != s_chars[charPos])
                    {
                        arrayToCheck.RemoveAt(o);
                        o--;
                    }
                }
                i_charCount++;
            }
            
            return arrayToCheck[0];
        }
    }
}
