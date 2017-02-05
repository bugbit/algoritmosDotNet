using System;
using System.Security.Cryptography;

namespace AlgoritmosDotNet.Comun
{
	public class RandomRNG : IRandomInt
	{
		private static RNGCryptoServiceProvider mRNG = new RNGCryptoServiceProvider();

		#region IRandomInt implementation
		public int Next (int argMax)
		{
			var pData = new byte[4];

			mRNG.GetBytes(pData); // thread-safe; no lock necessary

			return (int)(BitConverter.ToUInt32(pData, 0) % max);
		}
		#endregion
	}
}

