using System;
using System.Collections.Generic;

namespace VendingMachineKata
{
	class VendingMachine
	{
		public decimal Amount { get; private set; }

		public decimal ReturnAmount { get; private set; }

		Dictionary<string, decimal> ValidCoins = new Dictionary<string, decimal> () {
			{ "2|2", .10M },
			{ "3|3", .05M },
			{ "5|5", .25M },
		};

		public VendingMachine ()
		{
			this.Amount = 0.0M;
			this.ReturnAmount = 0.0M;
		}

		public bool Insert (Coin c)
		{
			if (ValidCoins.ContainsKey (c.Size + "|" + c.Weight)) {
				AddAmount (ValidCoins [c.Size + "|" + c.Weight]);
				return true;
			}
			return false;
		}

		public void ReturnCoins ()
		{
			this.ReturnAmount = this.Amount;
			this.Amount = 0.0M;
		}

		public decimal CheckCoinReturn ()
		{
			return this.ReturnAmount;
		}

		public decimal TakeReturnedCoins ()
		{
			//Called moneyToReturn for clarification against ReturnAmount
			decimal moneyToReturn = this.ReturnAmount;
			this.ReturnAmount = 0.0M;
			return moneyToReturn;
		}

		public bool Purchase (int id)
		{
			return false;
		}

		private void AddAmount (decimal d)
		{
			Amount += d;
		}

		static void Main (string[] args)
		{
			VendingMachine v = new VendingMachine ();

			Console.WriteLine ("Enter -h for help!");

			while (true) {
				Console.WriteLine ("INSERT COIN (format: size|weight)");

				string input = Console.ReadLine ();

				if (input == "q") {
					break;
				} else if (input == "-h") {
					Console.WriteLine ("Usage:  ");
					Console.WriteLine (" options:  ");
					Console.WriteLine ("   -cr, display coin return contents.");
					Console.WriteLine ("   -p, --id List products and if given an id, attempt to purchase one.");
					Console.WriteLine ("   size|weight, Entering a size and weight in this format will insert a coin.");
				} else if (v.Insert (new Coin (input))) {
					Console.WriteLine ("AMOUNT: $" + v.Amount);
				} else {
					Console.WriteLine ("PLEASE CHECK COIN RETURN!");
				}
			}
		}
	}
}
