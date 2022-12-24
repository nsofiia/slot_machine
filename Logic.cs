using System;
namespace slot_machine
{
    public static class Logic
    {
        public static Random randomNum = new Random(); //random

        /// <summary>
        /// provide matrix and top edge number to fill out matrix with random inegers from 0 to (max = topInt)
        /// </summary>
        /// /// <param name="dimension1"> how many columns in matrix </param>
        /// <param name="dimension2"> how many rows in matrix </param>
        /// <param name="topInt">randon numbers from 0 to topInt will fill out the matrix</param>
        /// <returns></returns>
        public static int[,] createMatrixOfRandomInts(int dimension1, int dimension2, int topInt)//takes in 2 
        {
            int[,] matrix = new int[dimension1, dimension2];

            for (int row = 0; row < matrix.GetLength(0); row++) //filling out 3x3 array with random numbers from 0 to 2
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = randomNum.Next(topInt);
                }
            }
            return matrix;
        }


        /// <summary>
        /// takes string list, selects a random member from it and returns it
        /// </summary>
        /// <returns></returns>
        public static string selectRandomFromList(List<string> list)
        {
            string compliment = list[randomNum.Next(list.Count)];//select random record from list with compliments
            return compliment;
        }


        /// <summary>
        /// get correct price for the line
        /// </summary>
        /// <param name="choise"></param> // choice that user selected
        /// <param name="prices"></param> // list of prices
        /// <returns></returns>
        public static double choiceCost(char choise, List<double> prices)
        {
            double price = 0.0;

            switch (choise)
            {
                case 'H':
                case 'V':
                    price = prices[1];
                    break;

                case 'M':
                case 'D':
                    price = prices[0];
                    break;

                default:
                    Console.WriteLine("Price is not defined for this choice");
                    break;
            }
            return price;
        }



        /// <summary>
        /// get playing combinations
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        public static List<int> getCombinations(int[,] grid, char choice)
        {
            List<int> listOfLines = new List<int>();

            switch (choice)
            {
                case 'D':

                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        int num = grid[i, i];
                        listOfLines.Add(num);
                    }

                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        int num = grid[i, (grid.GetLength(0) - 1) - i];
                        listOfLines.Add(num);
                    }
                    break;

                case 'H':

                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < grid.GetLength(0); j++)
                        {
                            int num = grid[i, j];
                            listOfLines.Add(num);
                        }
                    }
                    break;

                case 'M':

                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        int num = grid[grid.GetLength(0) % 2, i];
                        listOfLines.Add(num);
                    }

                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        int num = grid[i, grid.GetLength(0) % 2];
                        listOfLines.Add(num);
                    }
                    break;

                case 'V':

                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < grid.GetLength(0); j++)
                        {
                            int num = grid[j, i];
                            listOfLines.Add(num);
                        }
                    }
                    break;

                default:
                    Console.WriteLine("This choise is not suported");
                    break;
            }

            return listOfLines;
        }



        /// <summary>
        /// checks if each 3 sequences are equal in the list > returns count of equal sequences 
        /// </summary>
        /// <param name="matrixLength"></param> //const 3
        /// <param name="combos"></param> list of all combos
        /// <param name="choice"></param> determined weather it is 2 or 3 lines to check
        /// <returns></returns>
        public static int findWinCount(int matrixLength, List<int> combos, char choice)
        {
            int count = 0;

            switch (choice)
            {
                case 'V': // 3 lines
                case 'H':
                    if (combos[0] == combos[1] && combos[1] == combos[2])
                    {
                        count++;
                    }
                    if (combos[matrixLength] == combos[matrixLength + 1] && combos[matrixLength] == combos[matrixLength + 2])
                    {
                        count++;
                    }
                    if (combos[matrixLength * 2] == combos[(matrixLength * 2) + 1] && combos[matrixLength * 2] == combos[(matrixLength * 2) + 2])
                    {
                        count++;
                    }
                    break;

                case 'M':    //2 lines
                case 'D':
                    if (combos[0] == combos[1] && combos[1] == combos[2])
                    {
                        count++;
                    }
                    if (combos[matrixLength] == combos[matrixLength + 1] && combos[matrixLength] == combos[matrixLength + 2])
                    {
                        count++;
                    }
                    break;
            }
            return count;
        }

    }
}

