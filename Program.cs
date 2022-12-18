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
        int[,] matrix = new int[3, 3]; //empty 2D array (3 rows,3 columns)
        double balance = 20.0; //initial ballance
        char playAgain = ' '; //restart option
        List<char> choices = new List<char> { 'V', 'H', 'D', 'M' };//betting choices; having "const" is thrwing error - moved to the bottom
        List<string> compliment = new List<string> { "Great choise!", "Awesome selection!",
            "Let's get to it!", "GOOD choise!", "You are a player!" };//list of encouragements

        displayGreetingAndRules();

        while (true)
        //inside of the game after each bet
        {
            char lineChoise = ' '; //!letter - resets previous choice  
            string selectCompliment = compliment[randomNum.Next(compliment.Count)];//select random record from list with encouragements
            int winCount = 0; //for gain display

            displayBalance(balance);
            displayChoicesPrices(choices, BET_MIN.ToString("C"), BET_MAX.ToString("C"));
            displayAcceptedInputs(choices);
            lineChoise = getCorrectValue(lineChoise, choices, out lineChoise);
            displayNewScreen();
            displayChoiseDetail(lineChoise);
            displayRandomCompliment(selectCompliment);
            displayWaitPrompt();

            for (int row = 0; row < matrix.GetLength(0); row++) //filling out 3x3 array with random numbers from 0 to 2
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = randomNum.Next(3);
                }
            }

            displayMatrix(matrix);

            if (lineChoise == 'D') //checking input to determine what lines to check for winning
            {
                balance -= BET_MIN; //removing betting cost
                displayBalance(balance);

                displaySystemChecks(1);
                if (matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2]) //are 3 diagonal cells equal
                {
                    balance += WIN_MIN;
                    displayWinCase(WIN_MIN);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }

                displaySystemChecks(2);
                if (matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0]) //are another 3 diagonal cells equal
                {
                    balance += WIN_MIN;
                    displayWinCase(WIN_MIN);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }
            }

            if (lineChoise == 'M')
            {
                balance -= BET_MIN;
                displayBalance(balance);

                displaySystemChecks(1);
                if (matrix[0, 1] == matrix[1, 1] && matrix[1, 1] == matrix[2, 1]) //are 3 middle cells equal
                {
                    balance += WIN_MIN;
                    displayWinCase(WIN_MIN);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }

                displaySystemChecks(2);
                if (matrix[1, 0] == matrix[1, 1] && matrix[1, 0] == matrix[1, 2]) //are 3 middle cells equal
                {
                    balance += WIN_MIN;
                    displayWinCase(WIN_MIN);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }
            }

            if (lineChoise == 'V')
            {
                balance -= BET_MAX;
                displayBalance(balance);

                displaySystemChecks(1);
                if (matrix[0, 0] == matrix[1, 0] && matrix[1, 0] == matrix[2, 0]) //are 3 middle cells equal
                {
                    balance += WIN_MAX;
                    displayWinCase(WIN_MAX);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }

                displaySystemChecks(2);
                if (matrix[0, 1] == matrix[1, 1] && matrix[1, 1] == matrix[2, 1]) //are 3 middle cells equal
                {
                    balance += WIN_MAX;
                    displayWinCase(WIN_MAX);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }

                displaySystemChecks(3);
                if (matrix[0, 2] == matrix[1, 2] && matrix[1, 2] == matrix[2, 2]) //are 3 middle cells equal
                {
                    balance += WIN_MAX;
                    displayWinCase(WIN_MAX);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }
            }

            if (lineChoise == 'H')
            {
                balance -= BET_MAX;
                displayBalance(balance);

                displaySystemChecks(1);
                if (matrix[0, 0] == matrix[0, 1] && matrix[0, 1] == matrix[0, 2]) //are 3 horizontal cells equal
                {
                    balance += WIN_MAX;
                    displayWinCase(WIN_MAX);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }

                displaySystemChecks(2);
                if (matrix[1, 0] == matrix[1, 1] && matrix[1, 1] == matrix[1, 2]) //are 3 horizontal cells equal
                {
                    balance += WIN_MAX;
                    displayWinCase(WIN_MAX);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }

                displaySystemChecks(3);
                if (matrix[2, 0] == matrix[2, 1] && matrix[2, 1] == matrix[2, 2]) //are 3 horizontal cells equal
                {
                    balance += WIN_MAX;
                    displayWinCase(WIN_MAX);
                    winCount++;
                }
                else
                {
                    displayNotWinCase();
                }
            }

            if (winCount < 1) //no winning combinations in this game
            {
                displayNotWinCase();
            }

            if (balance <= 0) //exit - total loss
            {
                displayGameOverFailCase();
                return;
            }

            if (balance > 100) //exit - total win
            {
                displayGameOverWinCase();
                return;
            }

            displayBalance(balance);

            playAgain = displayTryAgain(playAgain);

            if (playAgain == 'Y') // restart
            {
                displayNewScreen();
                continue;
            }
            else
            {
                return; // exit
            }
        }
    }

}

