using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace slot_machine
{
    public static class UI
    {
        /// <summary>
        /// is listing greeting and rules
        /// </summary>
        public static void printGreetingAndRules()
        {
            Console.WriteLine($"Slot machine has infinite ways for you to win ;)\nWinning will DOUBLE the bet!\n" +
            $"EACH additional winning line will bring even MORE!\n(minimum 2, maximum 3 lines per only! 1 bet)\n");
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
        /// is displaying the choices 
        /// </summary>
        /// <param name="option1"></param>first
        /// <param name="option2"></param>second
        /// <param name="option3"></param>third
        /// <param name="option4"></param>forth
        /// <param name="moneyMin"></param>small bet
        /// <param name="moneyMax"></param>biger bet
        public static void bettingChoicesDisplay(List<char> choices, string moneyMin, string moneyMax)
        {
            Console.WriteLine(
                $"Betting categories:\n" +
                $"{choices[0]} - all VERTICAL lines for {moneyMax}\n" +      //bet max
                $"{choices[1]} - all HORIZONTAL lines for {moneyMax}\n" +    //bet max
                $"{choices[0]} - all DIAGONAL lines for {moneyMin}\n" +    //bet min
                $"{choices[1]} - all MIDDLE lines for {moneyMin}\n"   //bet min
                );
        }



        /// <summary>
        /// lists expected choise entries
        /// </summary>
        public static void promptToMakeChoice(List<char> choices)
        {
            Console.Write($"Choose:");

            foreach (char item in choices)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }




        /// <summary>
        /// checks each entry choice untill correct one; return correct one
        /// </summary>
        /// <param name="input"></param>
        /// <param name="choices"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static char getCorrectValue(char input, List<char> choices, out char output)
        {
            while (!choices.Contains(input)) //checks if input is anything but a letter, if not, repeats
            {
                input = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine("\nAccepting only options above!\n");
            }
            return output = input;
        }

        /// <summary>
        /// clears the screen
        /// </summary>
        public static void newScreen()
        {
            Console.Clear();
        }


        /// <summary>
        /// exolaining the choice
        /// </summary>
        /// <param name="randomCompliment"></param>

        public static void explainingTheChoise(char choise)
        {
            Console.WriteLine($"Playing {choise}!\n");

            if (choise == 'M')
            {
                Console.WriteLine($"{choise} stands for \"Middle\" lines");
            }
            if (choise == 'D')
            {
                Console.WriteLine($"{choise} stands for \"Diagonal\" lines");
            }
            if (choise == 'H')
            {
                Console.WriteLine($"{choise} stands for all \"Horizontal\" lines");
            }
            if (choise == 'V')
            {
                Console.WriteLine($"{choise} stands for all \"Vertical\" lines");
            }
        }



        /// <summary>
        /// prints random compliment6 from provided list 
        /// </summary>
        /// <param name="randomCompliment"></param>
        public static void printRandomCompliment(string randomCompliment)
        {
            Console.WriteLine(randomCompliment + "\n"); //random encouragement for the user
        }

        public static void waitPrompt()
        {
            Console.WriteLine("Fetching the numbers"); //hint to wait
        }


        /// <summary>
        /// ptint 2D array, each sell with slight delay 
        /// </summary>
        /// <param name="machine"></param>
        public static void printArray(int[,] machine)
        {
            for (int row = 0; row < machine.GetLength(0); row++) //filling out 3x3 matrix with random number in each cell
            {
                for (int column = 0; column < machine.GetLength(1); column++)
                {
                    Console.Write(machine[row, column] + " ");
                    //print each cell
                    System.Threading.Thread.Sleep(500);
                    //wait before printing next one
                    if (column == machine.GetUpperBound(0))
                    //add new line when finished with a row -- when last column index == to last index in the first dimension add new line
                    {
                        Console.WriteLine();
                    }
                }
            }
        }



        /// <summary>
        /// displaying which line is under check
        /// </summary>
        /// <param name="line"></param>
        public static void printCheck(int line)
        {
            switch (line)
            {
                case 1: Console.WriteLine("First combination");
                    break;
                case 2:
                    Console.WriteLine("Second combination");
                    break;
                case 3:
                    Console.WriteLine("Third combination");
                    break;
            }

        }


        /// <summary>
        /// prints win message and ammount
        /// </summary>
        /// <param name="winningAmmount"></param>
        public static void winDisplay(double winningAmmount)
        { 
            Console.WriteLine("WIN");
            Console.Write($"+ {winningAmmount.ToString("C")}\n\n"); 
        }



        /// <summary>
        /// prints message that combination has no match
        /// </summary>
        public static void notWinText()
        {
            Console.WriteLine("nope\n");
        }


        /// <summary>
        /// prints message that all combinations has no match
        /// </summary>
        public static void lossDisplay()
        {
            Console.WriteLine("no winning combinations");
        }


        /// <summary>
        /// message for user who can not continue playing loss
        /// </summary>
        public static void endGameNoMoreCreditMessage()  
        {
            Console.WriteLine("All credit is used, press any key to exit");
            Console.ReadKey();
        }


        /// <summary>
        /// message for user who can not continue playing win
        /// </summary>
        public static void endGameTotalWinMessage()  
        {
            Console.WriteLine("You won, press any key to exit");
            Console.ReadKey();
        }


        /// <summary>
        /// get input 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static char tryAgainGetValue(char input)  
        {
            Console.WriteLine("Would you like to try again? press y to continue, any other key to exit");
            input = Char.ToUpper(Console.ReadKey().KeyChar);
            return input;
        }
    }
}

