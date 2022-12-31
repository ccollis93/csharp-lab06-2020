using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_1
{
    class Program
    {
        //global constants 
        const int SIZE = 6;
        const int MIN = 1;
        const int MAX = 69;
        const int PB_INDEX = 5;
        const int PB_MIN = 1;
        const int PB_MAX = 26;

        static void Main(string[] args)
        {

           

            Console.WriteLine("Welcome to the 'Not a scam' lottery.");
            Console.WriteLine("You will pick five numbers between 1 and 69, and a sixth number between 1 and 16 for the Powerball");
            int num1, num2, num3, num4, num5, num6;
            num1 = GetInt();
            num2 = GetInt();
            num3 = GetInt();
            num4 = GetInt();
            num5 = GetInt();
            num6 = GetPB();

            //populates the player's ticket array with the numbers they entered
            int[] playerTicket = GetTicket(num1, num2, num3, num4, num5, num6);
            //shows the player's ticket
            DisplayTicket(playerTicket);

            //this stores the array from the winning ticket generator
            int[] winningTicket = GetWinningTicket();

            //checks for matches in the player's ticket and the winning ticket
            bool matchCheck = HasMatches(playerTicket, winningTicket);

            //excecutes if the player has matches
            if (matchCheck == true)
            {
                int matchCount = CountMatches(playerTicket, winningTicket);
                Console.WriteLine("You had " + matchCount + " matches");

            }
            else
                Console.WriteLine("Sorry, none of your numbers matched. Better luck next time! :(");




            

            Console.ReadLine();
        }

        //generates the random numbers for the winning ticket
        static int[] GetWinningTicket()
        {
            Random rnd = new Random();
            int[] winTicket = new int[SIZE] {
                rnd.Next(MIN, MAX), rnd.Next(MIN, MAX),
                rnd.Next(MIN, MAX), rnd.Next(MIN, MAX),
                rnd.Next(MIN, MAX), rnd.Next(PB_MIN, PB_MAX)
            };

            return winTicket;
        }

        //getter for the first 5 numbers on the player's ticket
        static int GetInt()
        {
            bool isInt = false;
            int num;

            do
            {
                Console.WriteLine("Enter a number: ");
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out num);
            }
            while (!(isInt && num >= 1 && num <= 69));

            return num;

        }

        //getter for the player's powerball number
        static int GetPB()
        {
            bool isInt = false;
            int num;

            do
            {
                Console.WriteLine("Enter a number: ");
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out num);
            }
            while (!(isInt && num >= 1 && num <= 26));

            return num;
        }

        //takes in the 6 numbers the player chooses, puts them in an array
        static int[] GetTicket(int num1, int num2, int num3, int num4, int num5, int num6)
        {
            int[] usrTicket = new int[SIZE]
            {
             num1, num2, num3, num4, num5, num6
            };

            return usrTicket;
        }

        //prints the player's ticket to the console
        static void DisplayTicket(int[] playerTicket)
        {
            Console.WriteLine("Your Ticket is ");
            for (int i = 0; i < SIZE; i++) {
                Console.Write(playerTicket[i] +" ");
            }

        }

        //checks to see if they player's ticket matches any of the winning values
        static bool HasMatches(int[] playerTicket, int[] winTicket)
        {
            if (playerTicket.Intersect(winTicket).Count() > 0)
                return true;
            else
                return false;
        }

        //if they player's ticket has matching values, counts how many of them there are
        static int CountMatches(int[] playerTicket, int[] winTicket )
        {
            int[] matchingNum = playerTicket.Intersect(winTicket).ToArray();
            int matches = matchingNum.GetLength(0);

            return matches;
        }

       // static int GetTicketValue()
        //{

        //}

        static void DisplayResults()
        {

        }
    }
}
