using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmosDotNet.CifrasYLetras.Resolver
{
    public interface IResolver
    {
        Solucion Resolver(Enunciado argEnum);
    }
}
