using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using AlgoritmosDotNet.CifrasYLetras.Generador;
using AlgoritmosDotNet.Comun.Console;

namespace AlgoritmosDotNet.CifrasYLetras.Console
{
    class Program
    {		
		private void GenerarEnunciado(IGeneradorCifras argGenerador,int[] argNumeros)
		{
			var pGElegir = argGenerador as IGeneradorCifrasElegirGrupo;

			if (pGElegir != null)
				GenerarEnunciado (pGElegir, argNumeros);

			var pEnunciado = argGenerador.Generar ();

			if (pGElegir == null)
				System.Console.WriteLine (string.Join(" ", pEnunciado.Numeros.Select(n=>n.ToString())));
			System.Console.WriteLine ($"Objetivo: {pEnunciado.Objetivo}");
		}
		private void GenerarEnunciado(IGeneradorCifrasElegirGrupo argGenerador,int[] argNumeros)
		{
			var pArgs = new Queue<int> (argNumeros);

			while (argGenerador.MoveNext ()) {
				int pGrupo;

				System.Console.Write ("elija un grupo 1-4: ");
				do {
					if (pArgs.Any ()) {
						pGrupo = pArgs.Dequeue ();
						System.Console.WriteLine (pGrupo);
					} else
						pGrupo = HelperConsole.ReadInt ();
				} while (pGrupo < argGenerador.GrupoInicial || pGrupo > argGenerador.GrupoFinal);
				argGenerador.SetGrupo (pGrupo);
				System.Console.WriteLine($"Numero: {argGenerador.Current}");
			}
		}
        static void Main(string[] args)
        {
			var pPrg = new Program ();
//			var e1 = Expression.Constant (3);
//			var e2 = Expression.Constant (100);
//			var e3 = Expression.Multiply (e1, e2);
//			var e4 = Expression.Constant (5);
//			var e5 = Expression.Divide (e3, e4);
//			var el = Expression.Lambda<Func<int>> (e5);
//			var ec = el.Compile ();
//			var ee = ec.Invoke ();
//			var es = e5.ToString ();
			var g=new GeneraCifrasCanalSur() as IGeneradorCifras;

            //pPrg.GenerarEnunciado (g, args.Select(a=>int.Parse(a)).ToArray());

            var r = new Resolver.Resuelve();

            r.Resolver(g.Generar());
        }
    }
}
