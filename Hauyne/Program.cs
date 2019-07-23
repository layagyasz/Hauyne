using System;

namespace Hauyne
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string file = args[0];
			string generator = args[1];
			int number = Convert.ToInt32(args[2]);

			Random random = new Random();
			Language language = new Language(file);
			for (int i = 0; i < number; ++i)
			{
				Word word = language.Generate(generator, random);
				Console.WriteLine("{0} ({1})", word.Orthography, word);
			}
		}
	}
}
