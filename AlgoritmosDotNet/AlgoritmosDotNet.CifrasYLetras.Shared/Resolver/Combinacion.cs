using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlgoritmosDotNet.CifrasYLetras.Resolver
{
    public class Combinacion
    {
        public ExpressionType Operaciones { get; set; }
        public int[,] Idxs { get; set; }
    }
}
