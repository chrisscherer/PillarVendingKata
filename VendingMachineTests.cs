﻿using System;
using NUnit.Framework;

namespace VendingMachineKata
{
	[TestFixture]
	public class VendingMachineTests
	{
		VendingMachine v;

		[SetUp] public void Init ()
		{
			v = new VendingMachine ();
		}

		[TearDown] public void Dispose ()
		{
			v = null;
		}

		[Test]
		public void InsertValidCoin ()
		{
			Coin c = new Coin (5, 5);

			Assert.AreEqual (true, v.Insert (c));
		}

		[Test]
		public void InsertInvalidCoin ()
		{
			Coin c = new Coin (1, 1);

			Assert.AreEqual (false, v.Insert (c));
		}

		[Test]
		public void AmountOnInsertQuarter ()
		{
			Coin c = new Coin (5, 5);
			v.Insert (c);

			Assert.AreEqual (.25M, v.Amount);
		}

		[Test]
		public void OnCheckingCoinReturn ()
		{
			decimal d = v.CheckCoinReturn ();

			Assert.AreEqual (0.0M, d);
		}

		[Test]
		public void CoinReturnContainsCorrectAmount ()
		{
			Coin c = new Coin (5, 5);
			v.Insert (c);
			v.ReturnCoins ();
			decimal d = v.CheckCoinReturn ();
			Assert.AreEqual (.25M, d);
		}

		[Test]
		public void TakeCoinsFromReturn ()
		{
			Coin c = new Coin (5, 5);
			v.Insert (c);
			v.ReturnCoins ();
			v.TakeReturnedCoins ();
			decimal d = v.CheckCoinReturn ();

			Assert.AreEqual (0.0M, d);
		}

		[Test]
		public void InsufficientAmountForPurchase ()
		{
			bool success = v.Purchase (1);
			Assert.AreEqual (false, success);
		}

		[Test]
		public void SuccessfulItemPurchase ()
		{
			Coin c = new Coin (5, 5);

			v.Insert (c);
			v.Insert (c);
			v.Insert (c);
			v.Insert (c);

			bool success = v.Purchase (1);
			Assert.AreEqual (true, success);
		}

		[Test]
		public void SuccessfulItemPurchaseAmountUpdated ()
		{
			Coin c = new Coin (5, 5);

			v.Insert (c);
			v.Insert (c);
			v.Insert (c);
			v.Insert (c);

			Assert.AreEqual (1.00M, v.Amount);

			v.Purchase (1);
			Assert.AreEqual (0.00M, v.Amount);
		}

		//I saw the previous format of test naming on the nunit site, but it's getting hard to write descriptive test names
		//and I'm going back to the way I originally learned how to write them.
		//This is partially due to the lack (or my percieved lack of) a Given, When, Then test structure.
		[Test]
		public void OnSuccessfulItemPurchaseLeftoverCoinsAreReturned ()
		{
			Coin c = new Coin (5, 5);

			v.Insert (c);
			v.Insert (c);
			v.Insert (c);

			v.Purchase (3);
			Assert.AreEqual (0.10M, v.ReturnAmount);
		}
	}
}