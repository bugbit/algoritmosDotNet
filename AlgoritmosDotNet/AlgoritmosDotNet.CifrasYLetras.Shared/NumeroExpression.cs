using System;
using System.Linq.Expressions;

namespace AlgoritmosDotNet.CifrasYLetras
{
	public class NumeroExpression
	{
		private Expression<int> mExpresion;
		private int? mNumero;

		public Expression<int> Expresion {
			get {
				return mExpresion;
			}
			set {
				mExpresion = value;
				mNumero = null;
			}
		}

		public int Numero
		{
			get
			{
				if (!mNumero.HasValue)
					EjecuteExpression ();

				return mNumero.Value;
			}
		}

		private void EjecuteExpression()
		{
			var pLamda = Expression.Lambda<Func<int>> (mExpresion);
			var pCompile = pLamda.Compile ();

			mNumero = pCompile.Invoke ();
		}
	}
}

