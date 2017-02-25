using System;
using AlgoritmosDotNet.Comun;
using AlgoritmosDotNet.Comun.Extensions;

namespace AlgoritmosDotNet.CifrasYLetras.Generador
{
	public class GeneraCifrasCanalSur : IGeneradorCifras
	{
		private RandomRNG mRandom=new RandomRNG();

		#region IGeneradorCifras implementation
		public Enunciado Generar ()
		{
			var pGenerador = new GeneraCifrasTVE ();
			int pn123=0;
			int i=1;

			while (pGenerador.MoveNext ()) {
				var grupo=randomgrupo(pn123,i++);
				pGenerador.SetGrupo (grupo);
				if (grupo<4)
					pn123++;
			}

			var pEnunciado = pGenerador.Generar ();

			return pEnunciado;
		}
		#endregion

		private int randomgrupo(int n123,int num)
		{
			int p=mRandom.Next(100);
			int p123=(num!=0) ? 100*n123/num : 0;
			int p100123=(100-p123)/2;
			int g=(p<=p100123) ? mRandom.Next(1,4) : 4;

			return g;
		}
	}

}

