// Written by: Henrik Henriksson(AQ7150)
// Ignore Spelling: AQ




using System.Drawing.Text;

namespace Assignment3_HT2024_DA204E_AQ7150.Classes
{



    // this class will use alternative 2 for manual calculation.
    internal class RetirementCalculator
    {
        private double balance;
        private double fees;
        private double initialBalance;
        private double interest;
        private double monthlySaving;
        private int periodInYears;
        private double totalFees;
        private double totalInterestEarned;
        private Person person;

        public RetirementCalculator(Person person,
                                    double initialBalance,
                                    double monthlySaving,
                                    double annualInterestRate,
                                    double monthlyFees,
                                    int retirementAge)
        {
            this.person = person;
            InitialBalance = initialBalance;
            MonthlySaving = monthlySaving;
            Interest = annualInterestRate;
            Fees = monthlyFees;
            PeriodInYears = retirementAge - person.GetAge();
        }

        // Algorithm:
        /*
         1. Balance = initial deposit + monthly saving amount (this is the starting balance at the end
            of the first month).
         2. Months = period (years) × 12.
         3. Monthly interest = (annual interest rate in % / 100) ÷ 12.
         4. Monthly fees = (fees in % / 100) ÷ 12.
         */
        public bool Calculate(Person person, int retirementAge)
        {

            Balance = InitialBalance;
            TotalInterestEarned = 0;
            TotalFees = 0;
            
            double monthlyInterestRate = (Interest / 100) / 12; // interest should be in %
            double monthlyFeeRate = (Fees / 100) / 12;
            int periodInMonths = PeriodInYears * 12;

            // Main calculation
            for (int month = 1; month < periodInMonths; month++)
            {
                double monthlyInterestEarned = monthlyInterestRate * Balance;
                double monthlyFeesCharged = monthlyFeeRate * Balance;
                // update balance
                Balance += monthlyInterestEarned - monthlyFeesCharged + MonthlySaving;
                TotalInterestEarned += monthlyInterestEarned;
                totalFees += monthlyFeesCharged;

            }

            return true;

        }

        // Properties with validation to keep values within reasonable ranges.
        // They don't work very well when used in the Form, i will however keep them as a safety backup validation
        public double Balance
        {
            get { return balance; }
            set { balance = value > 0 ? value : throw new ArgumentException("Balance must be greater than zero."); }
        }

        public double Fees
        {
            get { return fees; }
            set { fees = value >= 0 && value <= 20 ? value : throw new ArgumentException("Fees must be between 0% and 20%."); }
        }

        public double InitialBalance
        {
            get { return initialBalance; }
            set { initialBalance = value >= 0 && value <= 1000000 ? value : throw new ArgumentException("Initial balance must be between 0 and 1,000,000."); }
        }

        public double Interest
        {
            get { return interest; }
            set { interest = value >= 0 && value <= 100 ? value : throw new ArgumentException("Interest rate must be between 0% and 100%."); }
        }

        public double MonthlySaving
        {
            get { return monthlySaving; }
            set { monthlySaving = value >= 0 && value <= 50000 ? value : throw new ArgumentException("Monthly saving must be between 0 and 50,000."); }
        }

        public int PeriodInYears
        {
            get { return periodInYears; }
            set { periodInYears = value > 0 && value <= 52 ? value : throw new ArgumentException("Period in years must be between 1 and 52."); }
        }

        public double TotalFees
        {
            get { return totalFees; }
            set { totalFees = value >= 0 ? value : throw new ArgumentException("Total fees cannot be negative."); }
        }

        public double TotalInterestEarned
        {
            get { return totalInterestEarned; }
            set { totalInterestEarned = value >= 0 ? value : throw new ArgumentException("Total interest earned cannot be negative."); }
        }

        public Person Person
        {
            get { return person; }
            set { person = value ?? throw new ArgumentNullException("Person cannot be null."); }
        }




    




    }
}
