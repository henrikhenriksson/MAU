namespace Assignment1HT24_HT2024_DA204E_AQ7150.Classes
{
    internal class Pet
    {
        private string name;
        private int age;
        private bool isFemale;

        public Pet(string name, int age, bool isFemale)
        {
            this.name = name;
            this.age = age;
            this.isFemale = isFemale;
        }

        public Pet()
        {
            age = -1;
            name = string.Empty;
            isFemale = false;
        }

        public void ReadAndSavePetData()
        {
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("What is the name of your pet?");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("The name cannot be empty or just whitespace. Please enter a valid name.");
                }
            }

            try
            {
                bool isValidInt = false;
                string ageInput = string.Empty;

                // Keep asking for age until a valid age is input ( >= 0 )
                while (age < 0)
                {
                    Console.WriteLine("What is the age of your pet?");
                    ageInput = Console.ReadLine();

                    isValidInt = int.TryParse(ageInput, out int parsedAge);

                    if (isValidInt && parsedAge >= 0)
                    {
                        // Valid input
                        age = parsedAge;
                    }
                    else if (!isValidInt)
                    {
                        Console.WriteLine($"Your input {ageInput} is not a valid number."
                            + $"\n Please enter your pet as a number");
                    }
                    else
                    {
                        Console.WriteLine("Age cannot be negative. Please enter a valid age");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            string genderInput = string.Empty;

            while (genderInput != "y" && genderInput != "n")
            {
                Console.WriteLine("Is your pet female? (y/n): ");
                genderInput = Console.ReadLine().Trim().ToLower();

                if (genderInput != "y" && genderInput != "n")
                {
                    Console.WriteLine("Invalid iput. Please enter either 'y' for female or 'n' for male\n");
                }
            }
            isFemale = genderInput == "y";
        }

        public void DisplayPetInfo()
        {
            string description = isFemale ? "she" : "he";

            Console.WriteLine($"\n+++++++++++++++++++++++++++++++" +
                   $"\nName: {name} Age: {age}\n" +
                   $"{name}: {description}'s such a wonderful pet!" +
                   $"\n+++++++++++++++++++++++++++++++\n");
        }

        public void Start()
        {
            Console.WriteLine("\nGreetings from the Pet class!\n");

            ReadAndSavePetData();
            DisplayPetInfo();
        }
    }
}