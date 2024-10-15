// Ignore Spelling: AQ

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// height = height * 12.0 + inches; all in inch
// height *= 2.54; inches to cm
// weight = weightInLbs * 0.453592); //lbls -> kg
// double ounces = milliliters * 0.033814;

// glass holds 240ml


namespace Assignment3_HT2024_DA204E_AQ7150.Classes
{
    internal class WaterIntakeCalculator
    {

        /// <summary>
        /// We want to avoid magic numbers, this will hopefully increase scalability and modularity 
        /// whereas the values of the constants can be changed if needed in the future.
        /// </summary>
        private const double BaseIntakePerKG = 33;
        private const double MaleAdjustment = 1.1;
        private const double FemaleAdjustment = 0.9;
        private const double AgeAdjustmentUnder30 = 1.1;
        private const double AgeAdjustmentOver55 = 0.9;
        private const double TallHeightAdjustment = 1.05;
        private const double ShortHeightAdjustment = 0.95;
        private const double ActivityMediumAdjustment = 1.2;
        private const double ActivityHighAdjustment = 1.5;

        private const int TallHeight = 175;
        private const int ShortHeight = 160;
        private int AgeLow = 30;
        private int AgeHigh = 55;



        public double CalculateIntake(Person person)
        {
            // Base intake = 33 ml / kg 
            double baseIntake = person.Weight * BaseIntakePerKG;

            if (person.Gender == Enums.GenderEnum.Male) { 
            
                baseIntake *= MaleAdjustment;
          
            
            } else { baseIntake *= FemaleAdjustment; }

            baseIntake = AdjustForGender(baseIntake, person);
            baseIntake = AdjustForAge(baseIntake, person);
            baseIntake = AdjustForHeight(baseIntake, person);
            baseIntake = AdjustForActivityLevel(baseIntake, person);

            return baseIntake;





        }

        private double AdjustForActivityLevel(double baseIntake, Person person)
        {
            throw new NotImplementedException();
        }

        private double AdjustForHeight(double baseIntake, Person person)
        {
            throw new NotImplementedException();
        }

        private double AdjustForAge(double baseIntake, Person person)
        {
            throw new NotImplementedException();
        }

        private double AdjustForGender(double baseIntake, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
