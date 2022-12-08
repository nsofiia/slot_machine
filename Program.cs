using System.Data.Common;

namespace slot_machine;
class Program
{
    const int BET_MAX = 3;
    const int BET_MIN = 2;
    const double WIN_MAX = 6;
    const double WIN_MIN = 4;
    const double WIN_2_LINES_MAX = WIN_MAX * 2;
    const double WIN_3_LINES_MIN = WIN_MIN * 3;

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
        Random random_num = new Random();
        int[,] slot_machine = new int[3, 3];
        char[] PLAY_CHOICES = new char[4] { 'V', 'H', 'D', 'M' };
        //having "const" in front of the above line is thrwing error, moved to the bottom to have it accesible by the next loop
        char line_choise = '.';
        List<string> compliment = new List<string> { "Great choise!", "Awesome selection!", "Let's get to it!", "GOOD choise!" };
        double balance = 25;
        char playAgain;



        while (true)
        {
            string complimentAtTime = compliment[random_num.Next(compliment.Count)];
            Console.WriteLine(
                $"Slot machine has infinite ways for you to win ;) For 1 line you get double of your bet!\nFor each additionall line THE GAIN multiplies!\n");

            while (true) { 
            Console.WriteLine($"\n\nMake your bet:\n" +
                $"enter the letter\n" +
                $"V - 3 VERTICAL lines for ${BET_MAX}\n" +      //bet min
                $"H - 3 HORIZONTALlines for ${BET_MAX}\n" +   //bet min
                $"D - 2 DIAGONAL lines for ${BET_MIN}\n" +    //bet max
                $"M - 2 MIDDLE lines for ${BET_MIN}\n");     //bet max
            Console.WriteLine($"Current balance ${balance}");

            while (true)
            {
                line_choise = Char.ToUpper(Console.ReadKey().KeyChar);

                if (!PLAY_CHOICES.Contains(line_choise))
                {
                    Console.WriteLine("\nChoose one of the letters above\n");
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine(complimentAtTime + "\n"); //random encouragement for the user to keep interesting

            //printing 3x3 matrix with random number in each cell
            for (int row = 0; row < slot_machine.Rank + 1; row++)
            {
                for (int column = 0; column < slot_machine.Rank + 1; column++)
                {
                    slot_machine[row, column] = random_num.Next(3);//only including numbers from 0 to 2 
                    Console.Write(slot_machine[row, column] + " ");
                    if (column == 2)
                    {
                        Console.WriteLine();
                    }
                }
            }

            if (line_choise == 'D') //checking input to determine what lines to check - X
            {
                balance -= BET_MIN;
                //Console.WriteLine($"Your balance: ${balance}");

                if (slot_machine[0, 0] == slot_machine[0, 2]) // start check is it is 2 line win
                {
                    balance += WIN_2_LINES_MAX;
                    Console.WriteLine("\n***JACKPOT***\n");
                    Console.WriteLine($"Current balance ${balance}");
                    Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");

                    playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                    if (playAgain == 'Y')
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
                if (slot_machine[0, 0] == slot_machine[1, 1] & slot_machine[1, 1] == slot_machine[2, 2]) //left to right 1 line check
                {
                    balance += WIN_MIN;
                    Console.WriteLine("\n***WIN***\n");
                    Console.WriteLine($"Current balance ${balance}");
                    Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");

                    playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                    if (playAgain == 'Y')
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }


                }
                if (slot_machine[0, 2] == slot_machine[1, 1] & slot_machine[1, 1] == slot_machine[2, 0])
                {
                    balance += WIN_MIN;
                    Console.WriteLine("\n***WIN***\n");
                    Console.WriteLine($"Current balance ${balance}");
                    Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");

                    playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                    if (playAgain == 'Y')
                    {
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
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }

               


                //for (int row = 0; row < slot_machine.Rank + 1; row++)  //checking if right to left diagonal is equal
                //{
                //    for (int column = 0; column < slot_machine.Rank; column++)
                //    {
                //        if (slot_machine[row, column] == slot_machine[column, row])
                //        {
                //            Console.WriteLine(slot_machine[row, column] + " equals " + slot_machine[column, row] + " " + row);
                //        }
                //        else
                //        {




                //if (dRightLeft & dLeftRight) //check if both are true for 2 line win
                //{
                //    balance += WIN_2_LINES;
                //    Console.WriteLine("\n***JACKPOT***\n");
                //    Console.WriteLine($"Current balance ${balance}");
                //    Console.WriteLine("\ntry again?: y - to play, any other key to exit \n"); playAgain = Char.ToUpper(Console.ReadKey().KeyChar);
                //    if (playAgain == 'Y')
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}
                //if (dLeftRight || dRightLeft) // check if at least 1 line win
                //{
                //    balance += WIN_MAX;
                //    Console.WriteLine($"It's a win! you earned ${BET_MAX}");
                //    Console.WriteLine($"Current balance ${balance}");
                //    Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");
                //    playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                //    if (playAgain == 'Y')
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}
                //else
                //{
                //    Console.WriteLine($"it's a miss");
                //    Console.WriteLine($"Current balance ${balance}");
                //    Console.WriteLine("\ntry again?: y - to play, any other key to exit \n");
                //    playAgain = Char.ToUpper(Console.ReadKey().KeyChar);

                //    if (playAgain == 'Y')
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        return;
                //    }

                //}
            }
            if (line_choise == 'M')
            {


            }
            if (line_choise == 'V')
            {

            }
            if (line_choise == 'H')
            {

            }
            Console.ReadKey();
        }
    }

    }
}
