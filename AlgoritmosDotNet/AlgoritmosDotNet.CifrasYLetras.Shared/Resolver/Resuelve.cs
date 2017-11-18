using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosDotNet.CifrasYLetras.Resolver
{
    public class Resuelve : IResolver
    {
        private Solucion mSolucion;

        public Solucion Resolver(Enunciado argEnum)
        {
            var p = Problema.CrearProblema(argEnum);
            var c = p.CrearCombinaciones();

            mSolucion = new Solucion();
            Parallel.ForEach(c, ResolverNodo2);

            return null;
        }

        private void ResolverNodo2(Combinacion argComb)
        {

        }
    }
}
