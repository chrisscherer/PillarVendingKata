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
	}
}