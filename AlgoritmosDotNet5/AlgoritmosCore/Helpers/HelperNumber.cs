using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosCore.Helpers
{
    public static class HelperNumber
    {
        public static int? ParseIntNullable(string argStr) => (string.IsNullOrWhiteSpace(argStr)) ? (int?)null : int.Parse(argStr);
    }
}
