using static slot_machine.UI;
using static slot_machine.Logic;

namespace slot_machine;
class Program
{
    const int MATRIX_LENGTH = 3; //used for both in 2d matrix
    const int FILL_MATRIX_MAX_INT = 3; //number used as cap value to fill matrix with random numbers 
    const double MIN_BALANCE = 0.0; //gave over
    const double MAX_BALANCE = 100.0;//total win
    const double WIN_MIN = 4.0;
    const double WIN_MAX = 6.0;

    static void Main(string[] args)
    {
        List<double> betPrices = new List<double> { 2.0, 3.0 }; //making it const - creating error 
        List<char> choices = new List<char> { 'V', 'H', 'D', 'M' }; //making it const - creating error                                                              
        List<string> compliments = new List<string>
        { "Great choise!", "Awesome selection!", "Let's get to it!", "GOOD choise!", "You are a player!" };
        //making list const - creating error 
        double balance = 3.0; //initial ballance
        char play = 'Y'; //game restart option
        displayGreetingAndRules();
        play = displayTryAgain(play); //continue playing or exit

        while (play == 'Y')
        //inside of the game after each bet
        {
            int winCount = 0; //for gain display***
            char lineChoise = ' '; //!letter - resets choice from previous loop, if user played before            
            Console.Clear();
            displayChoicesPrices(choices, betPrices);
            displayBalance(balance);
            displayAcceptedInputs(choices);//display list of accepted choices
            lineChoise = getCorrectValue(choices);//asks user to input untill correct value is returned
            double price = choiceCost(lineChoise, betPrices);
            balance -= price;
            Console.Clear();
            displayBalance(balance);
            displayChoiseDetail(lineChoise);//shows more information about the choise selected 
            displayRandomCompliment(selectRandomFromList(compliments));//display random encouragement
            displayWaitPrompt();
            int[,] matrix = createMatrixOfRandomInts(MATRIX_LENGTH, MATRIX_LENGTH, FILL_MATRIX_MAX_INT);
            //create matrix[3,3] filled with random ints 0-2 
            displayMatrix(matrix);
            List<int> playingCombinations = getCombinations(matrix, lineChoise);
            winCount = findWinCount(MATRIX_LENGTH, playingCombinations, lineChoise);
            displayHowManyWins(winCount);
            displayWinAmmount(price * winCount);
            balance += price * winCount;
            displayBalance(balance);

            bool totalWin = MAX_BALANCE <= balance;
            bool totalLoss = MIN_BALANCE >= balance;
            //having this 2 lines at the beggining of loop is not catching totleLoss outcome 

            if (totalLoss || totalWin)
            {
                Console.WriteLine("Ballance is out of accepted range, more bets is not accepted. Press any key to exit");
                Console.ReadKey();
                return;
            }

            play = displayTryAgain(play); //restart?

            if (play != 'Y') //app close
            {
                return;
            }
        }
    }
}

