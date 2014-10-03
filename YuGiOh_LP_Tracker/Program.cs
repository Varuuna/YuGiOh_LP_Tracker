using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
	

namespace YuGiOh_LP_Tracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Program start. Introduces the program with 3 lines of text, asking the user
            // to enter the names of the 2 players.
            Console.WriteLine("\n" + "Life Points tracker for Yu-Gi-Oh!\n\n" +
				"This tracker assumes that you are playing with 8000 LP.\n" + 
				"Most combinations of <LP amount> +/- <Playername> should work.\n\n" +
				"If you manage to find a command which straight-out \ncrashes the program, do let me know!\n" +
				"Finally, remember that you can quit this program at any time by pressing Ctrl+C\n" +
				"Start by entering the names of the players:\n");
            
            // Name entry for both players.
			Start:
            Console.Write("Player 1: ");
            string Player1 = Console.ReadLine();
            Console.Write("Player 2: ");
            string Player2 = Console.ReadLine();

            // Initializes 2 int variables, holding the LP of each player.
            int Player1LP = 8000, Player2LP = 8000;
            
            // Prints the LP on screen with the player's names.
			LPRefresh.LP(Player1, Player2, Player1LP, Player2LP);

            // While-loop for allowing input of LP reduction/increase.
            while(Player1LP > 0 && Player2LP > 0)
			{
				// Takes input in the format: "LP +/- Player". Checks bools to see if it was + or -.
				// If the input format is invalid, the methods below catches the exceptions and
				// takes the player back to this input with no change in LP.
			
				string LPChange = Console.ReadLine();
				bool Plus = LPChange.Contains('+');
				bool Minus = LPChange.Contains('-');

				// Calculates the change in LP for Player1 and prints the update.
				if (Plus == true && LPChange.Contains(Player1.ToLower()))
				{
					Player1LP = AddLifePoints.Add(LPChange, Player1LP, Player1);
					LPRefresh.LP(Player1, Player2, Player1LP, Player2LP);
				}
				else if (Minus == true && LPChange.Contains(Player1.ToLower()))
				{
					Player1LP = RemoveLifePoints.Remove(LPChange, Player1LP, Player1);
					LPRefresh.LP(Player1, Player2, Player1LP, Player2LP);
				}
									
				// Calculates the change in LP for Player2 and prints the update.
				if (Plus == true && LPChange.Contains(Player2.ToLower()))
				{
					Player2LP = AddLifePoints.Add(LPChange, Player2LP, Player2);
					LPRefresh.LP(Player1, Player2, Player1LP, Player2LP);
				}
				else if (Minus == true && LPChange.Contains(Player2.ToLower()))
				{
					Player2LP = RemoveLifePoints.Remove(LPChange, Player2LP, Player2);
					LPRefresh.LP(Player1, Player2, Player1LP, Player2LP);
				}
				
				// If the user input neither + nor -.
				if(Plus == false && Minus == false)
				{
					Console.WriteLine("\nUnable to add/remove LP. Did you miss a + or -?");
				}
			}

			// Declares the winner of the duel by checking which Player landed at or
			// below 0 Life Points.
			if (Player1LP <= 0)
			{
				Console.WriteLine("\n" + Player2 + " is the winner of this duel!");
			}
			else
			{
				Console.WriteLine("\n" + Player1 + " is the winner of this duel!");
			}

			// Asks user if he/she wants to have a rematch. Checks for invalid inputs.
			Console.WriteLine("\nWant to have a rematch? (yes/no)");
			Rematch:
			string Again = Console.ReadLine();
			if(Again.ToLower() == "yes")
			{
				// TODO: Get rid of this shit.
				Console.Clear();
				goto Start;

			}
			else if(Again.ToLower() == "no")
			{
				Console.WriteLine("\nWell played!\n" + "Press any key to exit.");
				Console.ReadKey();
			}
			else if(Again.ToLower() != "no" && Again.ToLower() != "yes")
			{
				Console.WriteLine("\nPlease type \"yes\" or \"no\" only!");
				goto Rematch;
			}
        }
    }
}