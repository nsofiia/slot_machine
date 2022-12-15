using System.Security.Cryptography;
using static slot_machine.UI;

namespace slot_machine;
class Program
{
    const double BET_MIN = 2.0;    //bets and wins initialized as constants
    const double BET_MAX = 3.0;
    const double BET_MIN_WIN = 4.0;
    const double BET_MAX_WIN = 6.0;

    static void Main(string[] args)
    {
        Random randomNum = new Random();
        //random
        int[,] slotMachine = new int[3, 3];
        //creating empty 2D array with 3 rows and 3 columns
        char[] playChoices = new char[4] { 'V', 'H', 'D', 'M' };
        // creating betting choices for player to bet on; having "const" in front of the above line is thrwing error, moved to the bottom to have it accesible by the next loop
        char lineChoise;
        //line choice have no value, expected to have input
        List<string> compliment = new List<string> { "Great choise!", "Awesome selection!", "Let's get to it!", "GOOD choise!", "You are a player!" };
        //list of encouragements for the user 
        double balance = 20.0;
        //initial ballance of the player
        char playAgain;
        //restart option
        

        while (true)
        //start of the game
        {
            printGreetingAndRules();
            
            while (true)
            //inside of the game after each bet
            {
                string complimentAtTime = compliment[randomNum.Next(compliment.Count)];
                //select random number for a compliment list string
                int winCount = 0;
                //for gain calculation
                balanceDisplay(balance);
                bettingChoicesDisplay(playChoices[0], playChoices[1], playChoices[2], playChoices[3], BET_MIN, BET_MAX);

                lineChoise = //getValueUntilIsCorrect(lineChoise, playChoices, lineChoise);

                Console.Clear();
                complimentPlusWaitPrompt(complimentAtTime);

                for (int row = 0; row < slotMachine.GetLength(0); row++) //printing 3x3 matrix with random number in each cell
                {
                    for (int column = 0; column < slotMachine.GetLength(1); column++)
                    {
                        slotMachine[row, column] = randomNum.Next(3);
                        //only including numbers from 0 to 2 
                        Console.Write(slotMachine[row, column] + " ");
                        //print each cell
                        System.Threading.Thread.Sleep(500);
                        //wait before printing next one
                        if (column == slotMachine.GetUpperBound(0))
                        //add new line when finished with a row -- when last column index == to last index in the first dimension add new line
                        {
                            Console.WriteLine();
                        }
                    }
                }

                if (lineChoise == 'D') //checking input to determine what lines to check 
                {

                    balance -= BET_MIN; //removing betting cost
                    balanceDisplay(balance);

                    firstCheck();
                    if (slotMachine[0, 0] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 2]) //are right top and middle cells equal?
                    {
                        balance += BET_MIN_WIN;
                        win();
                        Console.Write($"+ {BET_MIN_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }

                    secondCheck();
                    if (slotMachine[0, 2] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 0]) //are right bottom and middle cells equall?
                    {
                        balance += BET_MIN_WIN;
                        win();
                        Console.Write($"+ {BET_MIN_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }
                }

                if (lineChoise == 'M')
                {
                    balance -= BET_MIN;
                    balanceDisplay(balance);

                    firstCheck();
                    if (slotMachine[0, 1] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 1])
                    {
                        balance += BET_MIN_WIN;
                        win();
                        Console.Write($"+ {BET_MIN_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }

                    secondCheck();
                    if (slotMachine[1, 0] == slotMachine[1, 1] && slotMachine[1, 0] == slotMachine[1, 2])
                    {
                        balance += BET_MIN_WIN;
                        win();
                        Console.Write($"+ {BET_MIN_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }
                }

                if (lineChoise == 'V')
                {
                    balance -= BET_MAX;
                    balanceDisplay(balance);

                    firstCheck();
                    if (slotMachine[0, 0] == slotMachine[1, 0] && slotMachine[1, 0] == slotMachine[2, 0])
                    {
                        balance += BET_MAX_WIN;
                        win();
                        Console.Write($"+ {BET_MAX_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }

                    secondCheck();
                    if (slotMachine[0, 1] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 1])
                    {
                        balance += BET_MAX_WIN;
                        win();
                        Console.Write($"+ {BET_MAX_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }

                    thirdCheck();
                    if (slotMachine[0, 2] == slotMachine[1, 2] && slotMachine[1, 2] == slotMachine[2, 2])
                    {
                        balance += BET_MAX_WIN;
                        win();
                        Console.Write($"+ {BET_MAX_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }
                }

                if (lineChoise == 'H')
                {
                    balance -= BET_MAX;
                    balanceDisplay(balance);

                    firstCheck();
                    if (slotMachine[0, 0] == slotMachine[0, 1] && slotMachine[0, 1] == slotMachine[0, 2])
                    {
                        balance += BET_MAX_WIN;
                        win();
                        Console.Write($"+ {BET_MAX_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }

                    secondCheck();
                    if (slotMachine[1, 0] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[1, 2])
                    {
                        balance += BET_MAX_WIN;
                        win();
                        Console.Write($"+ {BET_MAX_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }

                    thirdCheck();
                    if (slotMachine[2, 0] == slotMachine[2, 1] && slotMachine[2, 1] == slotMachine[2, 2])
                    {
                        balance += BET_MAX_WIN;
                        win();
                        Console.Write($"+ {BET_MAX_WIN.ToString("C")}\n\n");
                        winCount++;
                    }
                    else
                    {
                        notWin();
                    }
                }

                if (balance <= 0) //exit - total loss
                {
                    Console.WriteLine("You have used all the credit, press any key to exit");
                    Console.ReadKey();
                    return;
                }

                if (balance > 100) //exit - total win
                {
                    Console.WriteLine("You won, press any key to exit");
                    Console.ReadKey();
                    return;
                }

                if (winCount < 1) //no winning combinations in this try
                {
                    Console.WriteLine("no winning combinations");
                }

                balanceDisplay(balance);
                Console.WriteLine("\nTry again?:\ny - to play, \nany other key to exit \n");

                playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                if (playAgain == 'Y') // restart
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    return; // exit
                }
            }
        }

    }
}
