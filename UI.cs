using System;

namespace slot_machine
{
    public static class UI
    {
        /// <summary>
        /// is listing greeting and rules
        /// </summary>
        public static void displayGreetingAndRules()
        {
            Console.WriteLine($"Slot machine has infinite ways for you to win ;)\n\nWinning will DOUBLE the bet!\n" +
            $"EACH additional winning line is bringing even MORE!\n(minimum 2, maximum 3 lines per only! 1 bet)\n");
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
        public static void displayChoicesPrices(List<char> choices, List<double> prices)
        {
            string moneyMax = prices[1].ToString("C");
            string moneyMin = prices[0].ToString("C");

            Console.WriteLine(
                $"Betting categories:\n" +
                $"{choices[0]} - all VERTICAL lines for {moneyMax}\n" +      //bet max
                $"{choices[1]} - all HORIZONTAL lines for {moneyMax}\n" +    //bet max
                $"{choices[2]} - all DIAGONAL lines for {moneyMin}\n" +    //bet min
                $"{choices[3]} - all MIDDLE lines for {moneyMin}\n"   //bet min
                );
        }



        /// <summary>
        /// is displaying current balance
        /// </summary>
        /// <param name="balance"></param>
        public static void displayBalance(double money)
        {
            Console.WriteLine($"Balance {money.ToString("C")}");

        }


        /// <summary>
        /// lists expected choise entries
        /// </summary>
        public static void displayAcceptedInputs(List<char> choices)
        {
            Console.Write($"Choose:");

            foreach (char item in choices)
            {
                Console.Write(" " + item);
            }
            System.Threading.Thread.Sleep(500);
            Console.Write(" >");
            Console.WriteLine();
        }


        /// <summary>
        /// checks each entry choice untill correct one; return correct one
        /// </summary>
        /// <param name="input"></param>
        /// <param name="choices"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static char getCorrectValue(List<char> choices)
        {
            char input = Char.ToUpper(Console.ReadKey().KeyChar);

            while (!choices.Contains(input)) //checks if input is anything but a letter, if not, repeats
            {
                Console.WriteLine("\nselect option\n");
                input = Char.ToUpper(Console.ReadKey().KeyChar);
            }
            return input;
        }


        /// <summary>
        /// prints more details about the choice
        /// </summary>
        /// <param name="choise"></param>

        public static void displayChoiseDetail(char choise)
        {
            switch (choise)
            {
                case 'M':
                    Console.WriteLine($"{choise} - 2 middle lines are selected as winning combo");
                    break;
                case 'D':
                    Console.WriteLine($"{choise} - 2 diagonal lines are selected as winning combo");
                    break;
                case 'H':
                    Console.WriteLine($"{choise} - all 3 horizontal lines are selected as winning combo");
                    break;
                case 'V':
                    Console.WriteLine($"{choise} - all 3 vertical lines are selected as winning combo");
                    break;
                default:
                    Console.WriteLine($"not defined choise");
                    break;
            }
        }



        /// <summary>
        /// prints string 
        /// </summary>
        /// <param name="randomCompliment"></param>
        public static void displayRandomCompliment(string randomCompliment)
        {
            Console.WriteLine("\n" + randomCompliment + "\n"); //random encouragement for the user
        }

        /// <summary>
        /// ux for user to wait
        /// </summary>
        public static void displayWaitPrompt()
        {
            Console.WriteLine("Fetching:"); //hint to wait
        }


        /// <summary>
        /// ptint 2D array, each sell with slight delay to build anticipation
        /// </summary>
        /// <param name="machine"></param>
        public static void displayMatrix(int[,] machine)
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
        /// prints win/loss message and ammount
        /// </summary>
        /// <param name="winningAmmount"></param>
        public static void displayWinAmmount(double ammount)
        {
            Console.Write($"+{ammount.ToString("C")}\n-------\n");
        }


        /// <summary>
        /// is showing int (ammount of winning lines)
        /// </summary>
        /// <param name="winCount"></param>
        public static void displayHowManyWins(int winCount)
        {
            Console.WriteLine($"\n{winCount} wins");
        }


        /// <summary>
        /// get input 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static char displayTryAgain(char input)
        {
            Console.WriteLine("\nWould you like to continue?\npress y to continue, any other key to exit");
            input = Char.ToUpper(Console.ReadKey().KeyChar);
            return input;
        }
    }
}

