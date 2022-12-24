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
        public static int[,] CreateMatrixOfRandomInts(int dimension1, int dimension2, int topInt)//takes in 2 
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
        public static string SelectRandomFromList(List<string> list)
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
        public static double FindChoiceCost(char choise, List<double> prices)
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
        public static List<int> FindAllCombinations(int[,] grid, char choice)
        {
            List<int> listOfLines = new List<int>();

            switch (choice)
            {
                case 'D'://the 2 diagonal lines, gathering in 1 ordered list 

                    for (int i = 0; i < grid.GetLength(0); i++) //diagonal from left top to the right bottom
                    {
                        int num = grid[i, i];
                        listOfLines.Add(num);
                    }

                    for (int i = 0; i < grid.GetLength(1); i++) //diagonal from left bottom to the right top
                    {
                        int num = grid[i, (grid.GetLength(1) - 1) - i];
                        listOfLines.Add(num);
                    }
                    break;

                case 'H': // the 3 holizontl lines

                    for (int i = 0; i < grid.GetLength(0); i++) // getting all 3 lines in correct order in 1 list 
                    {
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            int num = grid[i, j];
                            listOfLines.Add(num);
                        }
                    }
                    break;

                case 'M': // 2 middle lines

                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        int num = grid[grid.GetLength(0) % 2, i];
                        listOfLines.Add(num);
                    }

                    for (int i = 0; i < grid.GetLength(1); i++)
                    {
                        int num = grid[i, grid.GetLength(1) % 2];
                        listOfLines.Add(num);
                    }
                    break;

                case 'V':// 3 vertical lines 

                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < grid.GetLength(1); j++)
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
        /// selecting correct 1 line win ammount for the choice 
        /// </summary>
        /// <param name="winAmountsList"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        public static double FindWinAmmount(List<double> winAmountsList, char choice)
        {
            double winAmount = 0.0;
            switch (choice)
            {
                case 'V':
                case 'H':
                    winAmount = winAmountsList[1];
                    break;
                case 'D':
                case 'M':
                    winAmount = winAmountsList[0];
                    break;
                default:
                    Console.WriteLine("Ammount is not defined for this choice");
                    break;
            }
            return winAmount;
        }




        /// <summary>
        /// checks if each 3 sequences are equal in the list > returns count of equal sequences 
        /// </summary>
        /// <param name="matrixLength"></param> //const 3
        /// <param name="combos"></param> list of all combos
        /// <param name="choice"></param> determined weather it is 2 or 3 lines to check
        /// <returns></returns>
        public static int FindWinCount(int matrixLength, List<int> combos, char choice)
        {
            int count = 0;

            switch (choice)
            {
                case 'V': // 3 lines
                case 'H':
                    if (combos[0] == combos[1] && combos[1] == combos[2]) //checking list with all wins: first 3 items
                    {
                        count++;
                    }
                    if (combos[matrixLength] == combos[matrixLength + 1] && combos[matrixLength] == combos[matrixLength + 2])// checking second 3 items
                    {
                        count++;
                    }


                    if (combos[matrixLength * 2] == combos[(matrixLength * 2) + 1] && combos[matrixLength * 2] == combos[(matrixLength * 2) + 2]) // checking last 3 items for list.length=9 elements 
                    {
                        count++;
                    }
                    break;

                case 'M':    //2 lines
                case 'D':
                    if (combos[0] == combos[1] && combos[1] == combos[2]) // checking 
                    {
                        count++;
                    }
                    if (combos[matrixLength] == combos[matrixLength + 1] && combos[matrixLength] == combos[matrixLength + 2])
                    {
                        count++;
                    }
                    break;

                default:
                    Console.WriteLine("Choise is not supported: Logic.FindWinCount");
                    break;
            }
            return count;
        }

    }
}

