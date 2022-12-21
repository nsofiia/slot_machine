using System;
namespace slot_machine
{
    public static class Logic
    {
        public static Random randomNum = new Random(); //random




        /// <summary>
        /// provide matrix and top edge number to fill out matrix with random inegers till topInt
        /// </summary>
        /// /// <param name="dimension1"> how many columns in matrix </param>
        /// <param name="dimension2"> how many rows in matrix </param>
        /// <param name="topInt">randon numbers from 0 to topInt will fill out the matrix</param>
        /// <returns></returns>
        public static int[,] createMatrixOfRandomInts(int dimension1, int dimension2, int topInt)
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
        /// adds 2 ammounts
        /// </summary>
        /// <param name="money"></param>
        /// <param name="removeAmmount"></param>
        /// <returns></returns>
        public static double removeMoney(double money, double removeAmmount)
        {
            double newBalance = money - removeAmmount;
            return newBalance;
        }


        /// <summary>
        /// subtracts 2 ammounts
        /// </summary>
        /// <param name="money"></param>
        /// <param name="addAmmount"></param>
        /// <returns></returns>
        public static double addMoney(double money, double addAmmount)
        {
            double newBalance = money + addAmmount;
            return newBalance;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string selectRandomFromList(List<string> list)
        {
            string compliment = list[randomNum.Next(list.Count)];//select random record from list with compliments
            return compliment;
        }



        
    }
}

