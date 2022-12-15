using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace slot_machine
{
    public static class UI
    {
        /// <summary>
        /// is listing greeting and rules
        /// </summary>
        public static void printGreetingAndRules()
        {
            Console.WriteLine($"Slot machine has infinite ways for you to win ;)\nWINNING gets you a DOUBLE of the bet!\n" +
            $"EACH additional winning line is geting you even MORE! (min2-max3 lines per 1 bet)\n");
        }


        /// <summary>
        /// is displaying current balance
        /// </summary>
        /// <param name="balance"></param>
        public static void balanceDisplay(double balance)
        {
            Console.WriteLine($"\nBalance {balance.ToString("C")}\n");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option1"></param>first
        /// <param name="option2"></param>second
        /// <param name="option3"></param>third
        /// <param name="option4"></param>forth
        /// <param name="moneyMin"></param>small bet
        /// <param name="moneyMax"></param>biger bet
        public static void bettingChoicesDisplay(char option1, char option2, char option3, char option4, double moneyMin, double moneyMax)
        {
            Console.WriteLine($"Betting categories:\n" +
                    $"{option1} - 3 VERTICAL lines for {moneyMax.ToString("C")}\n" +      //bet max
                    $"{option2} - 3 HORIZONTALlines for {moneyMax.ToString("C")}\n" +    //bet max
                    $"{option3} - 2 DIAGONAL lines for {moneyMin.ToString("C")}\n" +    //bet min
                    $"{option4} - 2 MIDDLE lines for {moneyMin.ToString("C")}\n" +     //bet min
                    $"\nenter your betting choice V, H, D or M\n");
        }




        //public static char getValueUntilIsCorrect(char input, List<char> choices, out char output)
        //{
        //    while (!choices.Contains(input)) //checks if input is anything but a letter, if not, repeats
        //    {
        //        Console.WriteLine("\nChoose one of the letters above.\n");
        //        input = Char.ToUpper(Console.ReadKey().KeyChar);
        //        return output = input;
        //    }
        //}

        /// <summary>
        /// taking in random compliment, prints it and additional text
        /// </summary>
        /// <param name="randomCompliment"></param>
        public static void complimentPlusWaitPrompt(string randomCompliment)
        {
            Console.WriteLine(randomCompliment + "\n"); //random encouragement for the user
            Console.WriteLine("Fetching the numbers"); //hint to wait



        }

        public static void printMatrix(int slotMachine[row, column])
        {
            Console.Write(slotMachine[row, column] + " ");
        }







        public static void firstCheck()
        {
            Console.WriteLine("First combination");
        }

        public static void secondCheck()
        {
            Console.WriteLine("Second combination");
        }

        public static void thirdCheck()
        {
            Console.WriteLine("Third combination");
        }

        public static void win()
        {
            System.Threading.Thread.Sleep(500); //all match in 1 combination
            Console.WriteLine("WIN");
        }

        public static void notWin()  //combination has no match
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("nope\n");
        }

    }
}

