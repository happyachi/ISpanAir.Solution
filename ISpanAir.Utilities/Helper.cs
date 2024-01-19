using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpanAir.Utilities
{
	internal class Helper
	{
		public void GreetInCzech()
		{
			Console.WriteLine("Jak se jmenujes?");
			string myName = Console.ReadLine();
			Console.WriteLine("Ahoj!" + myName);
		}
	}
}
