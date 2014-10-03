using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_LP_Tracker
{
	public class RemoveLifePoints
	{
		public static int Remove(string LPChange, int Player1LP, string Player)
		{
			// TODO: Comments.
			string LPValue;
			int Position = LPChange.IndexOf(' ');
			if (Position == -1)
			{
				Position = LPChange.IndexOf('-');
				LPChange = LPChange.Replace("-", null);
				Position = LPChange.IndexOf(Player.ToLower());
				LPValue = LPChange.Remove(Position);
			}
			else
			{
				LPChange = LPChange.Replace("-", null);
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

			LP = int.Parse(LPValue);
			int PlayerLP = (Player1LP -= LP);
			return PlayerLP;
		}
	}
}
