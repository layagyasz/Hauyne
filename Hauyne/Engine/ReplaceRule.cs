﻿using System;
using System.Collections.Generic;

using Cardamom.Serialization;

using Hauyne.Parsing;

namespace Hauyne.Engine
{
	class ReplaceRule<T> where T : Generator<T>
	{
		MatchRule<T> _Match;
		SingleGenerator<T> _Replacement;

		public ReplaceRule(ParseBlock Block, List<Operator<T>> Operators, Dictionary<string, Generator<T>> Generators)
		{
			string[] def = Block.String.Split(new string[] { "=>" }, StringSplitOptions.None);
			_Match = new MatchRule<T>(def[0], Operators, Generators);
			_Replacement = new SingleGenerator<T>(def[1], Operators, Generators);
		}

		public void Replace(Random Random, Generated<T> ReplaceIn, int Index)
		{
			if (_Match.Match(ReplaceIn, Index))
			{
				ReplaceIn.Remove(Index, _Match.Length);
				List<T> New = new List<T>();
				Generated<T> R = _Replacement.Generate(Random);
				foreach (T S in R) New.Add(S);
				ReplaceIn.Insert(Index, New);
			}
		}


	}
}
