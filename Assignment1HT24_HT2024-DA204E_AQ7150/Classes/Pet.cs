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
            try
            {
                name = Utility.ReadInput("What is the name of your pet?");
                age = Utility.GetIntInput("What is the age of your pet?", 0, 1000); // We assume no pet is older than 1000 years (how long do turtles live?)

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            string genderInput = string.Empty;

            // Loop for as long as input is neither 'y' or 'n'
            while (genderInput != "y" && genderInput != "n")
            {
                Console.Write("Is your pet female? (y/n): ");
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