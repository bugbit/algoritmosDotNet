using System;
using static System.Console;

namespace AlgoritmosDotNet.Comun.Console
{
	public static class HelperConsole
	{
		public static int ReadInt()
		{
			int pNumero;
			string pStr;

			do
				pStr=ReadLine();
			while(!int.TryParse(pStr,out pNumero));

			return pNumero;
		}
	}
}

