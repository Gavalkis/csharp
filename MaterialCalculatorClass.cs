using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masterAndFloorApp
{
    internal class MaterialCalculatorClass
    {
        public static int CalculateRequiredMaterial(int productQuantity, double coefficient, double defectRate)
        {
            if (productQuantity <= 0 || coefficient <= 0 || defectRate < 0)
                return -1;

            double total = productQuantity * coefficient;
            double withDefect = total * (1 + defectRate / 100.0);

            return (int)Math.Ceiling(withDefect);
        }

    }
}
