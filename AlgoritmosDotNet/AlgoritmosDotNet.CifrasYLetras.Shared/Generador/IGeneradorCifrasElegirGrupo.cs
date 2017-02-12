using System;
using System.Collections.Generic;
using System.Collections;

namespace AlgoritmosDotNet.CifrasYLetras.Generador
{
	public interface IGeneradorCifrasElegirGrupo : IGeneradorCifras,IEnumerator
	{
		int GrupoInicial { get; }
		int GrupoFinal { get; }
		void SetGrupo (int argGrupo);
	}
}

