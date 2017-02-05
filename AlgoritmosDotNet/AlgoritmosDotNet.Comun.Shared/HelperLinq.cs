using System;

namespace AlgoritmosDotNet.Comun
{
	public static class HelperLinq
	{
		public static void Swap<T>(ref T argFirst, ref T argSecond)
		{
			var pTmp = argFirst;

			argFirst = argSecond;
			argSecond = pTmp;
		}
	}
}

