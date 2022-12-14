namespace slot_machine;
class Program
{
    const double BET_MIN = 2.0;    //bets and wins initialized as constants
    const double BET_MAX = 3.0;
    const double BET_MIN_WIN = 4.0;
    const double BET_MAX_WIN = 6.0;

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

    static void Main(string[] args)
    {
        Random randomNum = new Random();  //random 
        int[,] slotMachine = new int[3, 3]; //creating empty 2D array with 3 rows and 3 columns
        char[] playChoices = new char[4] { 'V', 'H', 'D', 'M' }; // creating betting choices for player to bet on; having "const" in front of the above line is thrwing error, moved to the bottom to have it accesible by the next loop
        char lineChoise; //line choice have no value, expected to have input
        List<string> compliment = new List<string> { "Great choise!", "Awesome selection!", "Let's get to it!", "GOOD choise!", "You are a player!" }; //list of encouragements added 
        double balance = 20.0; //initial ballance of the player
        char playAgain; //restart option



        while (true) //start of the game
        {
            Console.WriteLine($"Slot machine has infinite ways for you to win ;)\nWINNING gets you a DOUBLE of the bet!\n" +
            $"EACH additional winning line is geting you even MORE! (min2-max3 lines per 1 bet)\n");

            while (true) //inside of the game after each bet
            {
                string complimentAtTime = compliment[randomNum.Next(compliment.Count)];
                int winCount = 0;
                Console.WriteLine($"Current balance {balance.ToString("C")}\n");
                Console.WriteLine($"Betting categories:\n" +
                    $"{playChoices[0]} - 3 VERTICAL lines for {BET_MAX.ToString("C")}\n" +      //bet min
                    $"{playChoices[1]} - 3 HORIZONTALlines for {BET_MAX.ToString("C")}\n" +    //bet min
                    $"{playChoices[2]} - 2 DIAGONAL lines for {BET_MIN.ToString("C")}\n" +    //bet max
                    $"{playChoices[3]} - 2 MIDDLE lines for {BET_MIN.ToString("C")}\n" +     //bet max
                    $"\nenter your betting choice V, H, D or M\n");


                lineChoise = Char.ToUpper(Console.ReadKey().KeyChar);

                while (!playChoices.Contains(lineChoise)) //checks if input is anything but a letter, if not, repeats
                {
                    Console.WriteLine("\nChoose one of the letters above.\n");
                    lineChoise = Char.ToUpper(Console.ReadKey().KeyChar);
                }

                Console.Clear();
                Console.WriteLine(complimentAtTime + "\n"); //random encouragement for the user
                Console.WriteLine("Fetching the numbers"); //hint to wait


                for (int row = 0; row < slotMachine.GetLength(0); row++) //printing 3x3 matrix with random number in each cell
                {
                    for (int column = 0; column < slotMachine.GetLength(1); column++)
                    {
                        slotMachine[row, column] = randomNum.Next(3);    //only including numbers from 0 to 2 
                        Console.Write(slotMachine[row, column] + " "); //print each cell
                        System.Threading.Thread.Sleep(500);  //wait before printing next one

                        if (column == 2) // add new line when finished with a row
                        {
                            Console.WriteLine();
                        }
                    }
                }

                if (lineChoise == 'D') //checking input to determine what lines to check 
                {

                    balance -= BET_MIN; //removing betting cost
                    Console.WriteLine($"Balance {balance.ToString("C")}\n");

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
                    Console.WriteLine($"\nBalance {balance.ToString("C")}\n");

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
                    Console.WriteLine($"Balance {balance.ToString("C")}\n");

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
                    Console.WriteLine($"Balance {balance.ToString("C")}\n");

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

                Console.WriteLine($"New balance {balance.ToString("C")}");
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
