using static slot_machine.UI;

namespace slot_machine;
class Program
{
    const double BET_MIN = 2.0;    //bets and wins initialized as constants
    const double BET_MAX = 3.0;
    const double WIN_MIN = 4.0;
    const double WIN_MAX = 6.0;



    static void Main(string[] args)
    {
        Random randomNum = new Random(); //random
        int[,] slotMachine = new int[3, 3]; //empty 2D array (3 rows,3 columns)
        List<char> playChoices = new List<char> { 'V', 'H', 'D', 'M' };//betting choices; having "const" is thrwing error - moved to the bottom
        List<string> compliment = new List<string> { "Great choise!", "Awesome selection!",
            "Let's get to it!", "GOOD choise!", "You are a player!" };//list of encouragements
        double balance = 20.0; //initial ballance
        char playAgain = ' ';//restart option

        printGreetingAndRules();

        while (true)
        //inside of the game after each bet
        {
            char lineChoise = ' '; //line choice not a letter - placed inside the main to reset the value for each new game 
            string complimentAtTime = compliment[randomNum.Next(compliment.Count)];//select random number for a compliment list with encouragements
            int winCount = 0; //for gain display
            balanceDisplay(balance);
            bettingChoicesDisplay(playChoices[0], playChoices[1], playChoices[2], playChoices[3], BET_MIN, BET_MAX);
            promptToMakeChoice(playChoices);
            lineChoise = getCorrectValue(lineChoise, playChoices, out lineChoise);
            newScreen();
            explainingTheChoise(lineChoise);
            printRandomCompliment(complimentAtTime);
            waitPrompt();

            for (int row = 0; row < slotMachine.GetLength(0); row++) //filling out 3x3 array with random numbers from 0 to 2
            {
                for (int column = 0; column < slotMachine.GetLength(1); column++)
                {
                    slotMachine[row, column] = randomNum.Next(3);
                }
            }

            printArray(slotMachine);

            if (lineChoise == 'D') //checking input to determine what lines to check for winning
            {
                balance -= BET_MIN; //removing betting cost
                balanceDisplay(balance);

                printCheck(1);
                if (slotMachine[0, 0] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 2]) //are 3 diagonal cells equal
                {
                    balance += WIN_MIN;
                    winDisplay(WIN_MIN);
                    winCount++;
                }
                else
                {
                    notWinText();
                }

                printCheck(2);
                if (slotMachine[0, 2] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 0]) //are another 3 diagonal cells equal
                {
                    balance += WIN_MIN;
                    winDisplay(WIN_MIN);
                    winCount++;
                }
                else
                {
                    notWinText();
                }
            }

            if (lineChoise == 'M')
            {
                balance -= BET_MIN;
                balanceDisplay(balance);

                printCheck(1);
                if (slotMachine[0, 1] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 1]) //are 3 middle cells equal
                {
                    balance += WIN_MIN;
                    winDisplay(WIN_MIN);
                    winCount++;
                }
                else
                {
                    notWinText();
                }

                printCheck(2);
                if (slotMachine[1, 0] == slotMachine[1, 1] && slotMachine[1, 0] == slotMachine[1, 2]) //are 3 middle cells equal
                {
                    balance += WIN_MIN;
                    winDisplay(WIN_MIN);
                    winCount++;
                }
                else
                {
                    notWinText();
                }
            }

            if (lineChoise == 'V')
            {
                balance -= BET_MAX;
                balanceDisplay(balance);

                printCheck(1);
                if (slotMachine[0, 0] == slotMachine[1, 0] && slotMachine[1, 0] == slotMachine[2, 0]) //are 3 middle cells equal
                {
                    balance += WIN_MAX;
                    winDisplay(WIN_MAX);
                    winCount++;
                }
                else
                {
                    notWinText();
                }

                printCheck(2);
                if (slotMachine[0, 1] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 1]) //are 3 middle cells equal
                {
                    balance += WIN_MAX;
                    winDisplay(WIN_MAX);
                    winCount++;
                }
                else
                {
                    notWinText();
                }

                printCheck(3);
                if (slotMachine[0, 2] == slotMachine[1, 2] && slotMachine[1, 2] == slotMachine[2, 2]) //are 3 middle cells equal
                {
                    balance += WIN_MAX;
                    winDisplay(WIN_MAX);
                    winCount++;
                }
                else
                {
                    notWinText();
                }
            }

            if (lineChoise == 'H')
            {
                balance -= BET_MAX;
                balanceDisplay(balance);

                printCheck(1);
                if (slotMachine[0, 0] == slotMachine[0, 1] && slotMachine[0, 1] == slotMachine[0, 2]) //are 3 horizontal cells equal
                {
                    balance += WIN_MAX;
                    winDisplay(WIN_MAX);
                    winCount++;
                }
                else
                {
                    notWinText();
                }

                printCheck(2);
                if (slotMachine[1, 0] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[1, 2]) //are 3 horizontal cells equal
                {
                    balance += WIN_MAX;
                    winDisplay(WIN_MAX);
                    winCount++;
                }
                else
                {
                    notWinText();
                }

                printCheck(3);
                if (slotMachine[2, 0] == slotMachine[2, 1] && slotMachine[2, 1] == slotMachine[2, 2]) //are 3 horizontal cells equal
                {
                    balance += WIN_MAX;
                    winDisplay(WIN_MAX);
                    winCount++;
                }
                else
                {
                    notWinText();
                }
            }

            if (winCount < 1) //no winning combinations in this game
            {
                lossDisplay();
            }

            if (balance <= 0) //exit - total loss
            {
                endGameNoMoreCreditMessage();
                return;
            }

            if (balance > 100) //exit - total win
            {
                endGameTotalWinMessage();
                return;
            }

            balanceDisplay(balance);

            playAgain = tryAgainGetValue(playAgain);

            if (playAgain == 'Y') // restart
            {
                newScreen();
                continue;
            }
            else
            {
                return; // exit
            }
        }
    }

}

