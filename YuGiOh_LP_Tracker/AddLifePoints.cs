using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_LP_Tracker
{
	public class AddLifePoints
	{
		public static int Add(string LPChange, int Player1LP, string Player)
		{
			// Inits a string.
			string LPValue;
			// Tries to find any spaces in the entered command. Adds them to 'Position'.
			int Position = LPChange.IndexOf(' ');
			// If no spaces are found, 'Position' equals -1. Don't know why.
			if (Position == -1)
			{
				/* These next 3 lines aren't very pretty, but this is how it works:
				 * Line 1: Replaces the '+' with null and saves the new string.
				 * Line 2: Takes the index of the player's name and saves it to 'Position'
				 * Line 3: Removes everything starting with the player's name and after. */

				// TODO: More comments.
				LPChange = LPChange.Replace("+", null);
				Position = LPChange.IndexOf(Player.ToLower());
				LPValue = LPChange.Remove(Position);
			}
			else
			{
				LPChange = LPChange.Replace("+", null);
				LPValue = LPChange.Remove(Position);
			}

			int LP = 0;
			try
			{
				LP = int.Parse(LPValue);
			}
			catch (FormatException)
			{
				Console.WriteLine("\nThe program tried to pass a null to an int. \nWas your command formatted incorrectly?");
				return Player1LP;
			}
					
			int PlayerLP = (Player1LP += LP);
			return PlayerLP;
		}

	}
}
