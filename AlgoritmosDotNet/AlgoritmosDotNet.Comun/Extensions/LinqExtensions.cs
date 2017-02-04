using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmosDotNet.Comun.Extensions
{
	public static class LinqExtensions
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> argElems,IRandomInt argRandom=null)
		{
			T[] shuffled = original.ToArray();

			for (int index = shuffled.Length - 1; index > 0; index--)
			{
				int randomIndex = random.Next(index);

				T temp = shuffled[index];
				shuffled[index] = shuffled[randomIndex];
				shuffled[randomIndex] = temp;
			}

			return shuffled.ToArray();
		}
	}
}

