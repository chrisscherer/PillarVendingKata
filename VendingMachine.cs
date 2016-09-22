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

		Dictionary<int, KeyValuePair<string, decimal>> Products = new Dictionary<int, KeyValuePair<string,decimal>> () {
			{ 1, new KeyValuePair<string, decimal> ("Cola", 1.00M) },
			{ 2, new KeyValuePair<string, decimal> ("Chips", 0.50M) },
			{ 3, new KeyValuePair<string, decimal> ("Candy", 0.65M) },
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
			if (Products.ContainsKey (id) && this.Amount >= Products [id].Value) {
				this.AddAmount (Products [id].Value * -1);
				this.ReturnCoins ();
				Console.WriteLine ("THANK YOU");
				return true;
			} else if (Products.ContainsKey (id)) {
				Console.WriteLine ("PRICE: $" + this.Products [id]);
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
				Console.WriteLine ("Enter -h for help!");
				Console.WriteLine ("INSERT COIN");

				string[] input = Console.ReadLine ().Split (' ');

				if (input [0] == "q") {
					break;
				} else if (input [0] == "-h") {
					Console.WriteLine ("Usage: Basic Vending Machine App for vending things out of a machine! ");
					Console.WriteLine (" options:  ");
					Console.WriteLine ("   -cr, display coin return contents.");
					Console.WriteLine ("   -p, id List products and if given an id, attempt to purchase one.");
					Console.WriteLine ("   -i, size|weight, Entering a size and weight in this format will insert a coin.");
				} else if (input [0] == "-cr") {
					Console.WriteLine ("COIN RETURN AMOUNT: $" + v.CheckCoinReturn ());
				} else if (input [0] == "-p") {
					for (int i = 1; i <= v.Products.Count; i++) {
						Console.WriteLine (v.Products [i].Key + ": $" + v.Products [i].Value);
					}
				} else if (input [0] == "-i") {
					if (v.Insert (new Coin (input [1]))) {
						Console.WriteLine ("AMOUNT: $" + v.Amount);
					}
				} else {
					Console.WriteLine ("PLEASE CHECK COIN RETURN!");
				}
				Console.WriteLine (" ");
			}
		}
	}
}
