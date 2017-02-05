using System;

namespace AlgoritmosDotNet.Comun.Extensions
{
	public static class RandomIntExtensions
	{
		public static int Next(this IRandomInt argRandom,int argMin,int argMax)
		{
			return argMin+argRandom.Next (argMax-argMin);
		}
	}
}

