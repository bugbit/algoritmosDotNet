using System;
using System.Linq.Expressions;

namespace AlgoritmosDotNet.CifrasYLetras
{
    /// <summary>
    /// 25, 50, 75, 100, 3, 6 => 952
    /// 
    /// 75/25=3
    /// 3*3=9
    /// 100+6=106
    /// 106*9=954
    /// 
    /// 954=(100+6)*3*75:25
    /// 
    /// Diff:2
    /// 
    /// 50/25=2
    /// 
    /// Factor Comun
    /// 
    /// 954=(100+6)*3*75:25
    /// 952=(100+6)*3*75:25-50:25=[(100+6)*3*75-50]:25
    /// 
    /// </summary>
	public class NumeroExpression : IEquatable<NumeroExpression>
    {
        private Expression mExpresion;
        private int? mNumero;

        public Expression Expresion
        {
            get
            {
                return mExpresion;
            }
            set
            {
                mExpresion = value;
                mNumero = null;
            }
        }

        public int Numero
        {
            get
            {
                if (!mNumero.HasValue)
                    EjecuteExpression();

                return mNumero.Value;
            }
        }

        public bool Equals(NumeroExpression other)
        {
            return Numero == other.Numero;
        }

        public override bool Equals(object obj)
        {
            var pCls = obj as NumeroExpression;

            if (pCls == null)
                return false;

            return Equals(pCls);
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }

        public static NumeroExpression Crear(int argNum)
        {
            return new NumeroExpression { Expresion = Expression.Constant(argNum) };
        }

        public NumeroExpression Operacion(NumeroExpression argNum, ExpressionType argOpe)
        {
            return new NumeroExpression { Expresion = Expression.MakeBinary(argOpe, Expresion, argNum.Expresion) };
        }

        private void EjecuteExpression()
        {
            var pLamda = Expression.Lambda<Func<int>>(mExpresion);
            var pCompile = pLamda.Compile();

            mNumero = pCompile.Invoke();
        }
    }
}

