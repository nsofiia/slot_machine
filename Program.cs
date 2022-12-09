using System.Data.Common;
using System.Numerics;

namespace slot_machine;
class Program
{
    const int BET_MIN = 2;
    const int BET_MAX = 3;
    const double BET_MIN_WIN = 4;
    const double BET_MAX_WIN = 6;
    const double WIN_MAX_2LINES = BET_MIN_WIN * 2;
    const double WIN_MIN_3LINES = BET_MAX_WIN * 3;


    static void Main(string[] args)
    {
        /*
         1. array 3x3 (2 dimentions) to display random matrix
        2. random value for each cell
        3. player has ballance
        4. when ballance is $0 - player looses gane
        5. ballance > $0 player can choose to continue playing or quit
        6. user can select winning combination (to check)
        6. check if combination is winning
         */
        Random randomNum = new Random();
        int[,] slotMachine = new int[3, 3];
        char[] playChoices = new char[4] { 'V', 'H', 'D', 'M' };
        //having "const" in front of the above line is thrwing error, moved to the bottom to have it accesible by the next loop
        char line_choise = '.';
        List<string> compliment = new List<string> { "Great choise!", "Awesome selection!", "Let's get to it!", "GOOD choise!" };
        double balance = 25;
        char playAgain;



        while (true)
        {
            string complimentAtTime = compliment[randomNum.Next(compliment.Count)];
            Console.WriteLine(
                $"Slot machine has infinite ways for you to win ;) For 1 line you get double of your bet!\nFor each additionall line THE GAIN multiplies!\n");

            while (true)
            {
                Console.WriteLine($"Make your bet:\n" +
                $"enter the letter\n" +
                $"V - 3 VERTICAL lines for ${BET_MAX}\n" +      //bet min
                $"H - 3 HORIZONTALlines for ${BET_MAX}\n" +   //bet min
                $"D - 2 DIAGONAL lines for ${BET_MIN}\n" +    //bet max
                $"M - 2 MIDDLE lines for ${BET_MIN}\n");     //bet max
                Console.WriteLine($"Current balance ${balance}");

                while (true)
                {
                    line_choise = Char.ToUpper(Console.ReadKey().KeyChar);

                    if (!playChoices.Contains(line_choise))
                    {
                        Console.WriteLine("\nChoose one of the letters above\n");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine(complimentAtTime + "\n"); //random encouragement for the user to keep interesting

                //printing 3x3 matrix with random number in each cell
                for (int row = 0; row < slotMachine.Rank + 1; row++)
                {
                    for (int column = 0; column < slotMachine.Rank + 1; column++)
                    {
                        slotMachine[row, column] = randomNum.Next(3);//only including numbers from 0 to 2 
                        Console.Write(slotMachine[row, column] + " ");
                        if (column == 2)
                        {
                            Console.WriteLine();
                        }
                    }
                }

                if (line_choise == 'D') //checking input to determine what lines to check - X
                {
                    balance -= BET_MIN;
                    Console.WriteLine($"New balance: ${balance}");

                    if (slotMachine[0, 0] == slotMachine[1, 1]) //are right top and middle cells equal?
                    {
                        if (slotMachine[1, 1] == slotMachine[2, 2]) //are right bottom and middle cells equal?
                        {
                            balance += BET_MIN_WIN;
                            Console.WriteLine("\n***WIN***\n");
                            Console.WriteLine($"Current balance ${balance}");
                            Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");

                            playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                            if (playAgain == 'Y')
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"it's a miss");
                            Console.WriteLine($"Current balance ${balance}");
                            Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");

                            playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                            if (playAgain == 'Y')
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                return;
                            }

                        }

                    }
                    if (slotMachine[0, 2] == slotMachine[1, 1]) //are right bottom and middle cells equall?
                    {
                        if (slotMachine[1, 1] == slotMachine[2, 0]) //are middle and left bottom selles equal?
                        {
                            balance += BET_MAX_WIN;
                            Console.WriteLine("\n***WIN***\n");
                            Console.WriteLine($"Current balance ${balance}");
                            Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");

                            playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                            if (playAgain == 'Y')
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                return;
                            }

                        }
                        else // no 3 in a row matches for diagonals 
                        {
                            Console.WriteLine($"it's a miss");
                            Console.WriteLine($"Current balance ${balance}");
                            Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");

                            playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                            if (playAgain == 'Y')
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                return;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine($"it's a miss");
                        Console.WriteLine($"Current balance ${balance}");
                        Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");

                        playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                        if (playAgain == 'Y')
                        {
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            return;
                        }

                    }
                }
                if (line_choise == 'M')
                {
                    balance -= BET_MIN;
                    if (slotMachine[0, 1] == slotMachine[1, 1])
                    {
                        if (slotMachine[1, 1] == slotMachine[2, 1])
                        {

                        }
                    }

                }
                if (line_choise == 'V')
                {
                    balance -= BET_MAX;

                }
                if (line_choise == 'H')
                {
                    balance -= BET_MAX;
                }
                Console.ReadKey();
            }
        }

    }
}
