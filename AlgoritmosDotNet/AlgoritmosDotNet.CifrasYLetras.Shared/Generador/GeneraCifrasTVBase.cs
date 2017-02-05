﻿using System;

namespace AlgoritmosDotNet.CifrasYLetras.Generador
{
	public abstract class GeneraCifrasTVBase : IGeneradorCifras
	{
		protected readonly int [][] mgrupos=
			new int[][]
		{
			{ 1,2,3,4,5,6 },
			{ 7,8,9,1,2,3 },
			{ 4,5,6,7,8,9 },
			{ 10,10,25,50,75,100 }
		};
	}
}
