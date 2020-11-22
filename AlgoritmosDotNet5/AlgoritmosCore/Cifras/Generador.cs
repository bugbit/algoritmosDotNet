using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmosCore.Extensions;

namespace AlgoritmosCore.Cifras
{
    /// <summary>
    ///Genmerador tv2:
    ///.    los concursantes elegían de entre los 4 grupos de 6 fichas, conteniendo los 3 primeros dos juegos de números del 1 al 9, y en el cuarto grupo los números 10, 10, 25, 50, 75 y 100
    ///
    ///Generador Canal Sur:
    ///.    los generaba un ordenador, probablemente dando el doble de probabilidad a los números del 1 al 9. En este caso pueden salir más de 2 fichas del 1-9 y más de 1 ficha del 10-100
    /// </summary>
    public class Generador
    {
        private readonly static int[][] mGruposInitial =
            new int[][]
            {
                new int[] { 1,2,3,4,5,6 },
                new int[] { 7,8,9,1,2,3 },
                new int[] { 4,5,6,7,8,9 },
                new int[] { 10,10,25,50,75,100 }
            };
        private Random mRandom = new Random();

        public static readonly int[] NumerosTVE = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 25, 50, 75, 100 };

        public Enunciado Generar(ICollection<int?> argCifras, int? argObjetivo)
        {
            if (argCifras.Any(c => !c.HasValue))
                throw new ApplicationException("Se tienen que definir las 6 cifras");
            if (!argObjetivo.HasValue)
                throw new ApplicationException("El objetivo es obligatorio");

            return new Enunciado
            {
                Numeros = (from c in argCifras select c.Value).ToArray(),
                Objetivo = argObjetivo.Value
            };
        }

        public Enunciado GenerarTv2()
        {
            var pGrupos =
            (
                from n in mGruposInitial
                select new Stack<int>(n.Shuffle())
            ).ToArray();
            var pNumeros = new List<int>();

            for (int i = 0; i < 6; i++)
                pNumeros.Add(pGrupos[mRandom.Next(pGrupos.Length)].Pop());

            var pEnun = new Enunciado
            {
                Numeros = pNumeros.ToArray()
            };

            AddObjetivo(pEnun);

            return pEnun;
        }

        private void AddObjetivo(Enunciado argEnum) => argEnum.Objetivo = mRandom.Next(100, 1000);
    }
}
