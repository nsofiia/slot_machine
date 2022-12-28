using static slot_machine.UI;
using static slot_machine.Logic;

namespace slot_machine;
class Program
{
    const int MATRIX_LENGTH = 3; //used for both in 2d matrix
    const int FILL_MATRIX_MAX_INT = 3; //number used as cap value to fill matrix with random numbers 
    const double MIN_BALANCE = 0.0; //gave over
    const double MAX_BALANCE = 100.0;//total win

    static void Main(string[] args)
    {
        List<double> betPrices = new List<double>
        { 2.0, 3.0 }; //making it const - creating error -- bet
        List<double> winPrices = new List<double>
        {3.0, 4.0}; // winning ammount per 1 line
        List<char> choices = new List<char>
        { 'V', 'H', 'D', 'M' }; //making it const - creating error     -- playing choises                                                         
        List<string> compliments = new List<string>
        { "Great choise!", "Awesome selection!", "Let's get to it!", "GOOD choise!", "You are a player!" };
        //making list const - creating error -- encouragement
        double balance = 20.0; //initial ballance
        char play = 'Y'; //game restart option
        ShowGreetingAndRules();
 
        while (play == 'Y')
        //inside of the game after each bet
        {           
            ShowBettingChoices(choices, betPrices);
            ShowPresentBalance(balance);
            ShowAcceptedInputList(choices);//display list of accepted choices
            char lineChoise = AskToChooseUntillCorrect(choices);//asks user to input untill correct value is returned
            double price = FindChoiceCost(lineChoise, betPrices);
            balance -= price;
            Console.Clear();
            ShowPresentBalance(balance);
            ShowChoiseDetails(lineChoise);//shows more information about the choise selected 
            ShowString(SelectRandomFromList(compliments));//display random encouragement
            int[,] matrix = CreateMatrixOfRandomInts(MATRIX_LENGTH, MATRIX_LENGTH, FILL_MATRIX_MAX_INT);
            //create matrix[3,3] filled with random ints 0-2 
            ShowMatrixOfInts(matrix);
            List<int> playingCombinations = FindAllCombinations(matrix, lineChoise);
            int winCount = FindWinCount(MATRIX_LENGTH, playingCombinations, lineChoise);
            ShowHowManyWins(winCount);
            double winAmmount = FindWinAmmount(winPrices, lineChoise);
            ShowAmmount(winCount * winAmmount);
            balance += winCount * winAmmount;
            ShowPresentBalance(balance);

            bool totalWin = MAX_BALANCE <= balance;
            bool totalLoss = MIN_BALANCE >= balance;
            //having this 2 lines at the beggining of loop is not catching totleLoss outcome

            if (totalLoss || totalWin)
            {
                Console.WriteLine("Ballance is out of range, insert your banking card to continue\n");//pressing any key will close the app
                Console.ReadKey();
                return;
            }

            play = ShowContinueExitPrompt(play); //restart?

            if (play != 'Y') //app close
            {
                return;
            }
        }
    }
}

