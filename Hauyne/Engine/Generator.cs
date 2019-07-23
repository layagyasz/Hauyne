using System;

namespace Hauyne.Engine
{
	interface Generator<T>
	{
		double Frequency { get; }
		Generated<T> Generate(Random Random);
	}
}
