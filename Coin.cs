using System;

namespace VendingMachineKata
{
	public class Coin
	{
		public int Size { get; private set; }

		public int Weight { get; private set; }

		public Coin (int size, int weight)
		{
			this.Size = size;
			this.Weight = weight;
		}
	}
}

