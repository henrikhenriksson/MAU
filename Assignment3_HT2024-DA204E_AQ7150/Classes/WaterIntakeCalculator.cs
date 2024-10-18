// Written by: Henrik Henriksson (AQ7150)
// Ignore Spelling: AQ

using Assignment3_HT2024_DA204E_AQ7150.Enums;


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
        /// i hope this deviation from the instructions (3.9) is all right.
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
        private const int AgeLow = 30;
        private const int AgeHigh = 55;

        private Person person;

        public WaterIntakeCalculator(Person person)
        {
            this.person = person;
        }

        public double CalculateIntake()
        {
            if (person == null) { throw new ArgumentNullException(nameof(person), "Person cannot be null"); }


            // Base intake = 33 ml / kg 
            double baseIntake = person.Weight * BaseIntakePerKG;
            baseIntake = AdjustForGender(baseIntake, person);
            baseIntake = AdjustForAge(baseIntake, person);
            baseIntake = AdjustForHeight(baseIntake, person);
            baseIntake = AdjustForActivityLevel(baseIntake, person);

            return baseIntake;
        }
        private double AdjustForGender(double intake, Person person)
        {
            return person.Gender == Enums.Gender.Male
                ? intake *= MaleAdjustment
                : intake *= FemaleAdjustment;
        }
        private double AdjustForActivityLevel(double intake, Person person)
        {
            return person.ActivityLevel switch
            {
                ActivityLevel.Low => intake,// no adjustment
                ActivityLevel.Medium => intake * ActivityMediumAdjustment,
                ActivityLevel.High => intake * ActivityHighAdjustment,
                _ => intake,
            };
        }
        private double AdjustForAge(double intake, Person person)
        {
            if (person.GetAge() < AgeLow)
            {
                return intake * AgeAdjustmentUnder30;
            }
            else if (person.GetAge() > AgeHigh)
            {
                return intake * AgeAdjustmentOver55;
            }
            return intake; // no adjustment



        }
        private int GetAge(Person person)
        {
            return DateTime.Now.Year - person.BirthYear;
        }

        private double AdjustForHeight(double intake, Person person)
        {
            if (person.Height > TallHeight)
            {
                return intake * TallHeightAdjustment;

            }
            else if (person.Height < ShortHeight)
            {
                return intake * ShortHeightAdjustment;
            }

            return intake; // no adjustment

        }

    }
}
