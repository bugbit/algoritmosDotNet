using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosCore.Helpers
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
