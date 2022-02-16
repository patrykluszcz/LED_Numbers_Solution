using System;
using System.Collections.Generic;

namespace DIGNUM_LED__Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] input = ReadJaggedArrayFromStdInput();
            for (var i = 0; i < input.GetLength(0); i += 3)
            {
                char[][] tab = new char[3][];
                tab[0] = input[i];
                tab[1] = input[i + 1];
                tab[2] = input[i + 2];
                char[][] input_ = TransposeJaggedArray(tab);
                PrintJaggedArrayToStdOutput(input_);
                Console.WriteLine();
            }
        }
        static char[][] ReadJaggedArrayFromStdInput()
        {
            List<char[]> tab = new List<char[]>();
            do
            {
                string input = Console.ReadLine();
                if (input == null || input == "")
                {
                    break;
                }
                char[] tes = input.ToCharArray();
                tab.Add(tes);
            }
            while (true);

            return tab.ToArray();
        }

        static void PrintJaggedArrayToStdOutput(char[][] tab)
        {
           var numberLED = "";

            for (var i = 0; i < tab.Length; i++)
            {

                for (var j = 0; j < tab[i].Length; j++)
                {
                    numberLED += tab[i][j].ToString();
                }

            }

            var zero = " ||_ _ ||";

            var one = "      ||";

            var two = "  |___ | ";

            var three = "   ___ ||";

            var four = " |  _  ||";

            var five = " | ___  |";

            var six = " ||___  |";

            var seven = "   _   ||";

            var eight = " ||___ ||";

            var nine = " | __  ||";

            List<int> numbers_output = new List<int>();

            for (int i = 0; i < numberLED.Length; i += 9)
            {            
                string test = numberLED.Substring(i, 9);

                if (test.Contains(zero)) numbers_output.Add(0);               
                if (test.Contains(one)) numbers_output.Add(1);               
                if (test.Contains(two)) numbers_output.Add(2);               
                if (test.Contains(three)) numbers_output.Add(3);                
                if (test.Contains(four)) numbers_output.Add(4);               
                if (test.Contains(five)) numbers_output.Add(5);               
                if (test.Contains(six)) numbers_output.Add(6);                
                if (test.Contains(seven)) numbers_output.Add(7);               
                if (test.Contains(eight)) numbers_output.Add(8);              
                if (test.Contains(nine)) numbers_output.Add(9);               
            }

            foreach (int x in numbers_output)
            {
                Console.Write(x);
            }
        }
        static char[][] TransposeJaggedArray(char[][] tab)
        {
            int[] columnLength = new int[tab.GetLength(0)];

            for (var i = 0; i < tab.GetLength(0); i++)
            {
                columnLength[i] = tab[i].Length;
            }

            Array.Sort(columnLength);
            Array.Reverse(columnLength);

            int numberOfRows = columnLength[0];

            char[][] transposed = new char[numberOfRows][];

            for (var i = 0; i < numberOfRows; i++)
            {
                transposed[i] = new char[tab.GetLength(0)];

                for (var j = 0; j < tab.GetLength(0); j++)
                {
                    transposed[i][j] = ' ';

                    if (i > tab[j].Length - 1)
                        continue;

                    transposed[i][j] = tab[j][i];
                }
            }
            return transposed;
        }
    }
}