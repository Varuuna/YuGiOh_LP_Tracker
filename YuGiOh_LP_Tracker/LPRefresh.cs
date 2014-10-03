using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_LP_Tracker
{
	public class LPRefresh
	{
		public static void LP(string Player1, string Player2, int Player1LP, int Player2LP)
		{
			Console.WriteLine("\n\t\t" + Player1 + "'s LP: " + Player1LP + "  " + Player2 + "'s LP: " + Player2LP);
		}
	}
}
