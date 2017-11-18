using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using AlgoritmosDotNet.CifrasYLetras.Resolver;

namespace AlgoritmosDotNet.CifrasYLetras
{
    public class Problema
    {
        public Enunciado ElEnunciado { get; }
        public NumeroExpression[] Numeros { get; }
        public bool IsSolAprox { get; }
        public int Count { get; }

        private static readonly Dictionary<bool, ExpressionType[]> mOpesAprox =
        new Dictionary<bool, ExpressionType[]>
        {
            [true] = new[] { ExpressionType.Multiply, ExpressionType.Add },
            [false] = new[] { ExpressionType.Multiply, ExpressionType.Add, ExpressionType.Subtract, ExpressionType.Divide }
        };

        public Problema(Enunciado argE, NumeroExpression[] argNums)
        {
            ElEnunciado = argE;
            Numeros = argNums;

            var pSum = (from n in Numeros select n.Numero).Sum();

            // comparar si el cuadrado del sumatorio de las pistas es menor que el doble del número a hallar
            IsSolAprox = pSum * pSum < 2 * ElEnunciado.Objetivo;
            Count = Numeros.Length;
        }

        public static Problema CrearProblema(Enunciado argE)
        {
            var pNums = (from n in argE.Numeros orderby n descending select NumeroExpression.Crear(n)).ToArray();

            return new Problema(argE, pNums);
        }

        public ExpressionType[] CalcOpes()
        {
            return mOpesAprox[IsSolAprox];
        }

        public int[][,] CalcIdxs()
        {
            var ij = Enumerable.Range(0, Count - 1).Select(i => Enumerable.Range(i + 1, Count - 1 - i).Select(j => new int[i, j])).SelectMany(ij2 => ij2).ToArray();

            return ij;
        }

        public Combinacion[] CrearCombinaciones()
        {
            var c = CalcOpes().Select(o => CalcIdxs().Select(i => new Combinacion { Operaciones = o, Idxs = i })).SelectMany(c2 => c2).ToArray();

            return c;
        }

        public NumeroExpression CrearOperacion(int argIdx1, int argIdx2, ExpressionType argOpe)
        {
            return Numeros[argIdx1].Operacion(Numeros[argIdx2], argOpe);
        }
    }
}
