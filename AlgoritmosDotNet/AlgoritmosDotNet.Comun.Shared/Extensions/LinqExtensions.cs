using System;
using System.Collections.Generic;
using System.Linq;
using static AlgoritmosDotNet.Comun;

namespace AlgoritmosDotNet.Comun.Extensions
{
	public static class LinqExtensions
	{
		/// <summary>
		/// Aplicamos el algoritmo para mezcla de Fisher-Yates
		/// </summary>
		/// <param name="argElems">Argument elems.</param>
		/// <param name="argRandom">Argument random.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> argElems,IRandomInt argRandom=null)
		{			
			T[] pShuffled = original.ToArray();
			var pRandom = argRandom ?? RandomDefault.GetRandomByVelocityMax (pShuffled.Lenght);

			for (int pIdx = pShuffled.Length - 1; pIdx > 0; pIdx--)
			{
				int pIdxSwap = pRandom.Next(pIdx);

				Swap (ref pShuffled [pIdx], ref pShuffled [pIdxSwap]);
			}

			return pShuffled.ToArray();
		}
	}
}

