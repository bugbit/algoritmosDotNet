using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgoritmosCore.Helpers.HelperLinq;

namespace AlgoritmosCore.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Aplicamos el algoritmo para mezcla de Fisher-Yates
        /// </summary>
        /// <param name="argElems">Argument elems.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> argElems)
        {
            var pShuffled = argElems.ToArray();
            var pRandom = new Random();

            for (int pIdx = pShuffled.Length - 1; pIdx > 0; pIdx--)
            {
                int pIdxSwap = pRandom.Next(pIdx);

                Swap(ref pShuffled[pIdx], ref pShuffled[pIdxSwap]);
            }

            return pShuffled.ToArray();
        }
    }
}
