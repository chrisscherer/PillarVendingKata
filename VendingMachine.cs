using System;
using System.Collections.Generic;

namespace VendingMachineKata
{
	class VendingMachine
	{
		Dictionary<KeyValuePair<int,int>, decimal> ValidCoins = new Dictionary<KeyValuePair<int, int>, decimal> () {
			{ new KeyValuePair<int, int> (2, 2), .10M },
			{ new KeyValuePair<int, int> (3, 3), .05M },
			{ new KeyValuePair<int, int> (5, 5), .25M },
		};

		public bool Insert (Coin c)
		{
			if (ValidCoins.ContainsKey (new KeyValuePair<int,int> (c.Size, c.Weight)))
				return true;
			
			return false;
		}

		static void Main (string[] args)
		{
			Console.WriteLine ("YAY");
		}
	}
}
