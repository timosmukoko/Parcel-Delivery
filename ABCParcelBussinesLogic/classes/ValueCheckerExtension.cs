using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCParcelBussinesLogic
{
    internal static class ValueCheckerExtension
    {
        internal static double CheckForPositiveValue(this double inputValue) {
            if (inputValue > 0) {
                return inputValue;
            }

            throw new ArgumentOutOfRangeException($"Value of: {inputValue} is less or equal 0");
        }
    }
}
