using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    public class Recursion
    {
        //1
        public static int Multiply(int a, int b)
        {
            if (a == 1)
                return b;
            if (a == 0)
                return 0;
            return Multiply(a - 1, b) + b;
        }

        //2
        public static int sumOfDigits(int num)
        {
            if (num < 10)
                return num;
            return num % 10 + sumOfDigits(num / 10);
        }

        //3
        public static int power(int a, int b)
        {
            if (b == 1)
                return a;
            return a * power(a, b - 1);
        }

        //4
        public static int reversed(int num)
        {
            return reserved(num, 0);
        }
        private static int reserved(int num, int newNum)
        {
            newNum *= 10;
            if (num < 10)
                return newNum + num;
            return reserved(num / 10, newNum + num % 10);
        }

        //5
        public static int findSum(int[] array, int len)
        {
            if (len == 1)
                return array[0];
            return array[len - 1] + findSum(array, len - 1);
        }

        //6
        public static double divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            string str = divideInteger(a, b) + "." + divideFraction(a % b, b, 20);
            return double.Parse(str);
        }
        private static int divideInteger(int a, int b)
        {
            if (a < b)
                return 0;
            return 1 + divideInteger(a - b, b);
        }
        private static string divideFraction(int a, int b, int precision)
        {
            if (precision == 0)
                return "";
            a = Multiply(a, 10);
            //num = num + num + num + num + num + num + num + num + num + num;
            return divideInteger(a, b) + "" + divideFraction(a % b, b, precision - 1);
        }

        //7
        public static bool isPalindrome(string s)
        {
            if (s.Length <= 1)
                return true;
            if (s[0] == s[s.Length - 1])
                return isPalindrome(s.Substring(1, s.Length - 2));
            return false;
        }

        //8
        public static string decimalToBinary(int num)
        {
            if (num == 0)
                return "";
            if (num % 2 == 1)
                return decimalToBinary(num / 2) + "1";
            return decimalToBinary(num / 2) + "0";
        }


        //9
        public static int gcd(int a, int b)
        {
            return gcd(a, b, 2, 1);
        }
        private static int gcd(int a, int b, int bigest, int current)
        {
            if (bigest > a || bigest > b)
                return bigest;
            if (current % a == 0 || current % b == 0)
                bigest = current;
            return gcd(a, b, bigest, current + 1);
        }


        //10
        public static void evenNumbers(int num)
        {
            if (num % 2 == 1)
            {
                evenNumbersPrivate(num - 1);
                return;
            }
            evenNumbersPrivate(num - 2);
        }
        private static void evenNumbersPrivate(int num)
        {
            if (num < 0)
                return;
            Console.WriteLine("" + num);
            evenNumbersPrivate(num - 2);
        }

        //11
        public static int findMax(int[] array, int index)
        {
            if (index < array.Length - 1 && index >= 0)
            {
                return Math.Max(array[index], findMax(array, index + 1));
            }
            else if (index == array.Length - 1)
                return array[index];
            return int.MinValue;
        }

        //12
        public static int subtracEvenOdd(int num)
        {
            if (num == 0)
                return 0;
            int check = num % 10;
            if (check % 2 == 1)
                return subtracEvenOdd(num / 10) - check;
            return subtracEvenOdd(num / 10) + check;
        }

        //13
        public static bool sequence(int[] array)
        {
            if (array.Length <= 1)
                return true;
            return sequence(array, 2, array[1] - array[0]);
        }
        private static bool sequence(int[] array, int index, int diff)
        {
            if (index == array.Length)
                return true;
            if (array[index] - array[index - 1] != diff)
                return false;
            return sequence(array, index + 1, diff);
        }

        //14
        public static int diffFibo(int num)
        {
            if (num < 4)
            {
                if (num > 1)
                    return int.MinValue;
                return num;
            }
            if (num % 2 == 1)
                return diffFibo(num - 1) + diffFibo(num - 2) + diffFibo(num - 3);
            return Math.Abs(diffFibo(num - 1) - diffFibo(num - 2));
        }

        //15
        public static void permute(int[] array)
        {
            permute(array, "");
        }
        private static void permute(int[] array, string str)
        {
            bool NoMoreNumbers = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]!=int.MinValue)
                {
                    NoMoreNumbers=false;
                    int num= array[i];
                    array[i]=int.MinValue;
                    permute(array, str+" ,"+num);
                    array[i]=num;
                }
            }
            if (NoMoreNumbers)
                Console.WriteLine(str.Substring(2));
        }

        //16
        public static void solvHanoi(int n)
        {
            Stack<int> sourse = new Stack<int>();
            Stack<int> temp = new Stack<int>();
            Stack<int> dest = new Stack<int>();
            for (int i = n;i>0;i++)
                sourse.Push(i);
            solvHanoi(sourse, temp, dest);
        }
        private static void solvHanoi(Stack<int> sourse, Stack<int> temp, Stack<int> dest)
        {
            Console.WriteLine("I am tired  ):  ");
            return;
        }


        //17
        public static void solveMaze(int[][] array)
        {
            if (array[0][0] == 1 || solveMaze(array, 0, 0, "(0,0),") == false)
                Console.WriteLine("No way out;");
        }
        private static bool solveMaze(int[][] array, int row, int col, string solution)
        {
            int maxRow = array.Length - 1;
            int maxCol = array[row].Length - 1;
            if (row < 0 || row > maxRow || col < 0 || col > maxCol || array[row][col] != 0)
                return false;
            if (row == maxRow && col == maxCol)
            {
                Console.WriteLine("Start : " + solution + $" ({array.Length - 1},{array.Length - 1}) : End;");
                return true;
            }
            array[row][col] = 1;
            bool isWayOut = solveMaze(array, row + 1, col, solution + $" ({row},{col}),") ||
                            solveMaze(array, row - 1, col, solution + $" ({row},{col}),") ||
                            solveMaze(array, row, col + 1, solution + $" ({row},{col}),") ||
                            solveMaze(array, row, col - 1, solution + $" ({row},{col}),");
            array[row][col] = 0;
            return isWayOut;
        }

        //18
        public static int ChessKnight(int steps)
        {
            if (steps % 2 == 1) return 0;
            return ChessKnight(1, 1, steps);
        }
        private static int ChessKnight(int row, int col, int steps)
        {
            if (steps < 0 || row < 1 || row > 8 || col < 1 || col > 8)
                return 0;
            if (row == 8 && col == 8)
            {
                if (steps == 0)
                    return 1;
                return 0;
            }
            steps--;
            return ChessKnight(row + 2, col + 1, steps) +
                   ChessKnight(row + 2, col - 1, steps) +
                   ChessKnight(row - 2, col + 1, steps) +
                   ChessKnight(row - 2, col - 1, steps) +
                   ChessKnight(row + 1, col + 2, steps) +
                   ChessKnight(row + 1, col - 2, steps) +
                   ChessKnight(row - 1, col + 2, steps) +
                   ChessKnight(row - 1, col - 2, steps);
        }

        //19
        public static int num = 1;
        public static void ChessQueens()
        {
            bool[,] board = new bool[8, 8];
            ChessQueens(board, 0, 0, 8, "Solution:  ");
        }
        private static void ChessQueens(bool[,] array, int row, int col, int queensLeft, string str)
        {
            if (queensLeft == 0)
            {
                Console.WriteLine(str + "    solution number:" + num);
                num++;
                return;
            }
            if (row > 7)
                return;
            int currRow = row;
            int currCol = col;
            col++;
            if (col > 7)
            {
                col=0;
                row++;
            }
            if (AblePlace(array, currRow, currCol))
            {
                array[currRow, currCol] = true;
                ChessQueens(array, row, col, queensLeft - 1, str + $"({currRow+1},{currCol+1})   ");
                array[currRow, currCol] = false;
            }
            ChessQueens(array, row, col, queensLeft, str);
        }
        private static bool AblePlace(bool[,] array, int row, int col)
        {
            for (int i = 0; i < 8; i++)//בדיקת השורה הנוכחית
            {
                if (array[i, col])
                    return false;
            }
            for (int i = 0; i < 8; i++)//בדיקת העמודה הנוכחית
            {
                if (array[row, i])
                    return false;
            }
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)//בדיקת האלכסון הראשי ביחס למלכה הנוכחית
            {
                if (array[i, j])
                    return false;
            }
            for (int i = row, j = col; i >= 0 && j < 8; i--, j++)//בדיקת האלכסון המשני ביחס למלכה הנוכחית
            {
                if (array[i, j])
                    return false;
            }
            return true;
        }
    }

}
