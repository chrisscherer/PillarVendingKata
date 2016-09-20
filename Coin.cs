using System;

namespace VendingMachineKata
{
	public class Coin
	{
		public int Size { get; private set; }

		public int Weight { get; private set; }

		public Coin (string s)
		{
			int size;
			int weight;

			string[] sw = s.Split ('|');
			if (int.TryParse (sw [0], out size)) {
				if (int.TryParse (sw [1], out weight)) {
					Initialize (size, weight);
				}
			}

			Initialize (0, 0);
		}

		public Coin (int size, int weight)
		{
			Initialize (size, weight);
		}

		private void Initialize (int size, int weight)
		{
			Size = size;
			Weight = weight;
		}
	}
}

