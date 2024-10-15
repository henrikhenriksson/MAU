// Written by: Henrik Henriksson (AQ7150)
// Ignore Spelling: AQ Mlto

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_HT2024_DA204E_AQ7150.Classes
{
    public static class Conversions
    {
        // imperial to metric
        public static double InchesToCm(double inches) => inches * 2.54;
        public static double PoundsToKg(double pounds) => pounds * 0.453592;
        public static double OuncesToMl(double ounces) => ounces / 0.033814;

        // metric to imperial
        public static double CmToInches(double cm) => cm / 2.54;
        public static double KgToPounds(double kg) => kg / 0.453592;
        public static double MlToOunces(double ml) => ml * 0.033814;
    }
}
