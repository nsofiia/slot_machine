using static slot_machine.UI;
using static slot_machine.Logic;

namespace slot_machine;
class Program
{    
    const int FILL_MATRIX_MAX_INT = 3; //number used as cap value to fill matrix with random numbers 
    const double MIN_BALANCE = 0.0; //constants
    const double BET_MIN = 2.0;
    const double BET_MAX = 3.0;
    const double WIN_MIN = 4.0;
    const double WIN_MAX = 6.0;
    const double MAX_BALANCE = 100.0;
    
    static void Main(string[] args)
    {
        List<char> choices = new List<char> { 'V', 'H', 'D', 'M' }; //making it const - creating error                                                              
        List<string> compliments = new List<string> { "Great choise!", "Awesome selection!", "Let's get to it!", "GOOD choise!", "You are a player!" };
        double balance = 20.0; //initial ballance
        char play = 'Y'; //game restart option
        displayGreetingAndRules();
        play = displayTryAgain(play); //continue playing?

        while (play == 'Y')
        //inside of the game after each bet
        {
            bool win = false; //for gain display
            char lineChoise = ' '; //!letter - resets choice from previous loop, if user played before            
            displayBalance(balance);
            displayChoicesPrices(choices, BET_MIN.ToString("C"), BET_MAX.ToString("C"));
            displayAcceptedInputs(choices);
            lineChoise = getCorrectValue(choices);
            displayChoiseDetail(lineChoise);
            displayRandomCompliment(selectRandomFromList(compliments));
            displayWaitPrompt();
            int[,] matrix = createMatrixOfRandomInts(3,3,FILL_MATRIX_MAX_INT);
            displayMatrix(matrix);

            if (lineChoise == 'D') //checking input to determine what lines to check for winning
            {
                removeMoney(balance, BET_MIN);
                displayBalance(balance);

                displaySystemChecks(1);
                if (matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2]) //are 3 diagonal cells equal
                {
                    balance = addMoney(balance, WIN_MIN);
                    displayWinAmmount(WIN_MIN);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }

                displaySystemChecks(2);
                if (matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0]) //are another 3 diagonal cells equal
                {
                    balance = addMoney(balance, WIN_MIN);
                    displayWinAmmount(WIN_MIN);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }
            }

            if (lineChoise == 'M')
            {
                balance = removeMoney(balance, BET_MIN);
                displayBalance(balance);

                displaySystemChecks(1);
                if (matrix[0, 1] == matrix[1, 1] && matrix[1, 1] == matrix[2, 1]) //are 3 middle cells equal
                {
                    balance = addMoney(balance, WIN_MIN);
                    displayWinAmmount(WIN_MIN);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }

                displaySystemChecks(2);
                if (matrix[1, 0] == matrix[1, 1] && matrix[1, 0] == matrix[1, 2]) //are 3 middle cells equal
                {
                    balance = addMoney(balance, WIN_MIN);
                    displayWinAmmount(WIN_MIN);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }
            }

            if (lineChoise == 'V')
            {
                balance = removeMoney(balance, BET_MAX);
                displayBalance(balance);

                displaySystemChecks(1);
                if (matrix[0, 0] == matrix[1, 0] && matrix[1, 0] == matrix[2, 0]) //are 3 middle cells equal
                {
                    balance = addMoney(balance, WIN_MAX);
                    displayWinAmmount(WIN_MAX);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }

                displaySystemChecks(2);
                if (matrix[0, 1] == matrix[1, 1] && matrix[1, 1] == matrix[2, 1]) //are 3 middle cells equal
                {
                    balance = addMoney(balance, WIN_MAX);
                    displayWinAmmount(WIN_MAX);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }

                displaySystemChecks(3);
                if (matrix[0, 2] == matrix[1, 2] && matrix[1, 2] == matrix[2, 2]) //are 3 middle cells equal
                {
                    balance = addMoney(balance, WIN_MAX);
                    displayWinAmmount(WIN_MAX);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }
            }

            if (lineChoise == 'H')
            {
                balance = removeMoney(balance, BET_MAX);
                displayBalance(balance);

                displaySystemChecks(1);
                if (matrix[0, 0] == matrix[0, 1] && matrix[0, 1] == matrix[0, 2]) //are 3 horizontal cells equal
                {
                    balance = addMoney(balance, WIN_MAX);
                    displayWinAmmount(WIN_MAX);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }

                displaySystemChecks(2);
                if (matrix[1, 0] == matrix[1, 1] && matrix[1, 1] == matrix[1, 2]) //are 3 horizontal cells equal
                {
                    balance = addMoney(balance, WIN_MAX);
                    displayWinAmmount(WIN_MAX);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }

                displaySystemChecks(3);
                if (matrix[2, 0] == matrix[2, 1] && matrix[2, 1] == matrix[2, 2]) //are 3 horizontal cells equal
                {
                    balance = addMoney(balance, WIN_MAX);
                    displayWinAmmount(WIN_MAX);
                    win = true;
                }
                else
                {
                    displayWinAmmount(MIN_BALANCE);
                }
            }

            if (!win) //no winning combinations in this game
            {
                displayAllLoss();
            }

            if (balance <= MIN_BALANCE) //exit - total loss
            {
                displayGameOverFailCase();
                return;
            }

            if (balance > MAX_BALANCE) //exit - total win
            {
                displayGameOverWinCase();
                return;
            }

            displayBalance(balance);

            play = displayTryAgain(play); //restart?

            if (play != 'Y') //app close
            {
                return;
            }
        }
    }
}