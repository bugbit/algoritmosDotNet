using System;
using System.Linq;
using AlgoritmosDotNet.Comun.Extensions;
using System.Collections.Generic;
using AlgoritmosDotNet.Comun;

namespace AlgoritmosDotNet.CifrasYLetras.Generador
{
	public class GeneraCifrasTVE : IGeneradorCifrasElegirGrupo
	{
		protected readonly static int [][] mGruposInitial=
			new int[][]
		{
			new int[] { 1,2,3,4,5,6 },
			new int[] { 7,8,9,1,2,3 },
			new int[] { 4,5,6,7,8,9 },
			new int[] { 10,10,25,50,75,100 }
		};
			
		private RandomRNG mRandom=new RandomRNG();
		private Stack<int>[] mGrupos=null;
		private int mIdx=-1;
		private Enunciado mEnunciado=new Enunciado { Numeros=new int[6] };

		public int GrupoInicial=>1;

		public int GrupoFinal=>4;

		#region IGeneradorCifrasElegirGrupo implementation


		public void SetGrupo (int argGrupo)
		{
			var pGrIdx = argGrupo % mGrupos.Length;

			mEnunciado.Numeros[mIdx] = mGrupos [pGrIdx].Pop();
		}


		#endregion


		#region IEnumerator implementation


		public bool MoveNext ()
		{
			if (mGrupos == null)
				Reset ();
			if (mIdx >= mEnunciado.Numeros.Length)
				return false;
			if (++mIdx >= mEnunciado.Numeros.Length) {
				mEnunciado.Objetivo = 100 + mRandom.Next (900);

				return false;			
			}
			
			return true;
		}


		public void Reset ()
		{
			GenerarGrupos ();
			mIdx = -1;
		}


		public object Current {
			get {
				return mEnunciado.Numeros[mIdx];
			}
		}


		#endregion


		#region IGeneradorCifras implementation


		public Enunciado Generar ()
		{
			return mEnunciado;
		}


		#endregion

		void GenerarGrupos ()
		{
			var pNumeros = 
				mGruposInitial.Take (3).SelectMany(g=>g).Shuffle(mRandom).Concat
				(
					mGruposInitial.Skip (3).SelectMany(g=>g).Shuffle(mRandom)
				).ToArray().AsEnumerable();
			var pGrupos = new List<Stack<int>> ();

			while (pNumeros.Any ()) {
				pGrupos.Add (new Stack<int>(pNumeros.Take (6)));
				pNumeros = pNumeros.Skip (6);
			}

			mGrupos = pGrupos.ToArray ();
		}
	}
}

