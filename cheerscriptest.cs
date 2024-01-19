using System;

public class Class1
{
	public Class1()
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
