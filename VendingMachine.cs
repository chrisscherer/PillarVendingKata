using System;
using System.Collections.Generic;

namespace VendingMachineKata
{
	class VendingMachine
	{
		public decimal Amount { get; private set; }

		Dictionary<string, decimal> ValidCoins = new Dictionary<string, decimal> () {
			{ "2|2", .10M },
			{ "3|3", .05M },
			{ "5|5", .25M },
		};

		public VendingMachine ()
		{
			this.Amount = 0.0M;
		}

		public bool Insert (Coin c)
		{
			if (ValidCoins.ContainsKey (c.Size + "|" + c.Weight)) {
				AddAmount (ValidCoins [c.Size + "|" + c.Weight]);
				return true;
			}
			
			return false;
		}

		private void AddAmount (decimal d)
		{
			Amount += d;
		}

		static void Main (string[] args)
		{
			VendingMachine v = new VendingMachine ();
			while (true) {
				Console.WriteLine ("INSERT COIN (format: size|weight)");
				string input = Console.ReadLine ();
				if (input == "q") {
					break;
				}

				if (v.Insert (new Coin (input))) {
					Console.WriteLine ("Amount: $" + v.Amount);
				} else {
					Console.WriteLine (new Coin (input));
				}
			}
		}
	}
}
