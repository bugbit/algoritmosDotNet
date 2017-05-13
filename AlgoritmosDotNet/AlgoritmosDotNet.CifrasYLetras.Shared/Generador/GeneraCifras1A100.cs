using System;
using AlgoritmosDotNet.Comun;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmosDotNet.CifrasYLetras.Generador
{
	public class GeneraCifras1A100: IGeneradorCifras
	{
		private RandomRNG mRandom = new RandomRNG ();

		#region IGeneradorCifras implementation

		public Enunciado Generar ()
		{
			var pNumeros = new List<int> ();

			return new Enunciado {
				Numeros = Enumerable.Range (1, 6).Aggregate (pNumeros, (l, n) => {
					l.Add (1 + mRandom.Next (100));
					return l;
				}).ToArray (),
				Objetivo = 100 + mRandom.Next (900)
			};
		}

		#endregion
	}
}

