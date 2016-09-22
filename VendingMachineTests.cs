using System;
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
	}
}