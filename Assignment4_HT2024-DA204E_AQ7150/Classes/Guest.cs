// written by Henrik Henriksson(AQ7150)


namespace Assignment4_HT2024_DA204E_AQ7150.Classes
{
    public class Guest
    {
        private string firstName;
        private string lastName;

        public Guest(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot be empty");
                }
            }
        }
        public string LastName
        {
            get { return LastName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot be empty");
                }
            }
        }
        public string GetFullName() { return $"{lastName.ToUpper()}, {firstName}"; }

    }
}
