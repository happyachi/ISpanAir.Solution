using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpanAir.Entities
{
	public static class Cheertest
	{
		public static string GenerateRandomLetters(int length)
		{
			Random random = new Random();
			const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

			char[] letters = new char[length];

			for (int i = 0; i < length; i++)
			{
				int index = random.Next(alphabet.Length);
				letters[i] = alphabet[index];
			}

			return new string(letters);
		}
	}
}
