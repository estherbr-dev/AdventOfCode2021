using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DAY4
{
    class Program
    {
        public static List <List<BingoCellData>> bingosData = new List<List<BingoCellData>>();
        public static List<BingoCellData> winnerboard = new List<BingoCellData>();
        static void Main(string[] args)
        {
            #region bingo variables
            bingosData = new List<List<BingoCellData>>();
            winnerboard = new List<BingoCellData>();

            string[] s_inputLines = System.IO.File.ReadAllLines(@"T:\GITHUB\AdventOfCode2021\DAY4\Input.txt");

            string s_anouncedNumbers = s_inputLines[0];
            string[] s_anouncedNumbersList = s_inputLines[0].Split(",");
            List<int> i_bingoNumbers = new List<int>();

            int i_lastBingoNumber = 0;
            int i_resultDay4Part1 = 0;
            int i_resultDay4Part2 = 0;

            foreach(string s in s_anouncedNumbersList)
            {
                i_bingoNumbers.Add(Convert.ToInt32(s));
            }
           
            List<BingoCellData> bingoPanel = new List<BingoCellData>();

            int y = 0;
            int x = 0;
            #endregion

            #region we digest the bingo board data into more usable data
            for(int i = 2; i < s_inputLines.Length; i++)
            {
                if(s_inputLines[i] == "")
                {
                    bingosData.Add(bingoPanel);
                    bingoPanel = new List<BingoCellData>();
                    y = 0;
                }
                else
                {
                    string[] bingoNumbers = s_inputLines[i].Split(" ");
                    x = 0;
                    foreach(string s in bingoNumbers)
                    {
                        if(s != "")
                        {
                            BingoCellData bingoData = new BingoCellData();
                            bingoData.v2_cellPos = new Vector2(x,y);
                            bingoData.i_cellValue = Convert.ToInt32(s);
                            bingoData.b_numberChecked = false;
                            bingoPanel.Add(bingoData);
                            x++;
                        }
                    }
                    y++;
                }
            }
            #endregion

            #region We look for the bingo winner
            foreach(int i in i_bingoNumbers)
            {
                CheckNumberCalled(i);
                if(CheckForBingo())
                {
                    i_lastBingoNumber = i;
                    Console.WriteLine("Bingooo");
                    break;
                }
            }

            foreach(BingoCellData bingoData in winnerboard)
            {
                if(!bingoData.b_numberChecked)
                {
                    i_resultDay4Part1 += bingoData.i_cellValue;
                }
            }

            i_resultDay4Part1 = i_resultDay4Part1 * i_lastBingoNumber;
            Console.WriteLine("The answer for DAY 4 question 1 is = {0}", i_resultDay4Part1);
            #endregion

            foreach(int i in i_bingoNumbers)
            {
                CheckNumberCalled(i);
                while(CheckForBingo() && bingosData.Count > 1)
                {
                    i_lastBingoNumber = i;
                    bingosData.Remove(winnerboard);
                    winnerboard = new List<BingoCellData>();
                    //Console.WriteLine(bingosData.Count + " : " + i_lastBingoNumber);
                }
                if(CheckForBingo() && bingosData.Count == 1)
                {
                    i_lastBingoNumber = i;
                    foreach(BingoCellData bingoData in bingosData[0])
                    {
                        if(!bingoData.b_numberChecked)
                        {
                            i_resultDay4Part2 += bingoData.i_cellValue;
                        }
                    }
                    break;
                }
            }

            i_resultDay4Part2 = i_resultDay4Part2 * i_lastBingoNumber;
            Console.WriteLine("The answer for DAY 4 question 2 is = {0}", i_resultDay4Part2);
        }

        public static void CheckNumberCalled(int calledNumber)
        {
            foreach(List<BingoCellData> l_BingoCells in bingosData)
            {
                foreach(BingoCellData l_BingoCellData in l_BingoCells)
                {
                    if(l_BingoCellData.i_cellValue == calledNumber)
                    {
                        l_BingoCellData.b_numberChecked = true;
                    }
                }
            }
        }

        public static bool CheckForBingo()
        {
            foreach(List<BingoCellData> l_BingoCells in bingosData)
            {
                for(int i = 0; i < l_BingoCells.Count(); i+= 5)
                {
                    int countForHorizontalBingo = 0;
                    for(int x = i; x < i+5; x++)
                    {
                        //Console.WriteLine(x);
                        if(l_BingoCells[x].b_numberChecked)
                        {
                            countForHorizontalBingo ++;
                        }
                    }
                    if(countForHorizontalBingo == 5)
                    {
                        //Horizontal bingo
                        winnerboard = l_BingoCells;
                        return true;
                    }
                }

                for(int i = 0; i < 5; i++)
                {
                    int countForVerticalBingo = 0;
                    for(int y = i; y < (i+5*5); y+=5)
                    {
                        if(l_BingoCells[y].b_numberChecked)
                        {
                            countForVerticalBingo ++;
                        }
                    }
                    if(countForVerticalBingo == 5)
                    {
                        //Vertical bingo
                        winnerboard = l_BingoCells;
                        return true;
                    }
                }
            }

            return false;
        }
    }

    public class BingoCellData
    {
        public Vector2 v2_cellPos = new Vector2();
        public int i_cellValue = 0;
        public bool b_numberChecked = false; 
    }
}