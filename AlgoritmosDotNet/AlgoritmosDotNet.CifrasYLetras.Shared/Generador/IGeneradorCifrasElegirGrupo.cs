using System;
using System.Collections.Generic;

namespace AlgoritmosDotNet.CifrasYLetras.Generador
{
	public interface IGeneradorCifrasElegirGrupo : IGeneradorCifras,IEnumerator<int>
	{
		void SetGrupo(int argGrupo);
	}
}

