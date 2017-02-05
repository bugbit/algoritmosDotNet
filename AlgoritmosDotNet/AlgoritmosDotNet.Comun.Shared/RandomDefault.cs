using System;

namespace AlgoritmosDotNet.Comun
{
	public class RandomDefault : Random, IRandomInt
	{	
		public static IRandomInt GetRandomByVelocityMax(int argMax)
		{
			/*
			 * http://sleeplessmonkey.blogspot.com.es/2009/03/difference-in-random-number-generation.html
			 * So I guess the bottom line in the System.Random vs. RNGCryptoServiceProvider argument over slowness is in small numbers 
			 * it doesn't greatly matter. Now if you're going to be generating more than 100,000 numbers in a very tight loop, 
			 * it might be worth sacrificing "true" randomness with speed.

			 */

			if (argMax > 10000)
				return new RandomDefault ();

			return new RandomRNG ();
		}
	}
}

