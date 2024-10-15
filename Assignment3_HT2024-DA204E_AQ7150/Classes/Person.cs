// Ignore Spelling: AQ

using Assignment3_HT2024_DA204E_AQ7150.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_HT2024_DA204E_AQ7150.Classes
{

    /// <summary>
    /// This class utilizes private instance variables and public properties to ensure better controll of access to the properties of the class.
    /// </summary>
    public class Person
    {
        private double _height;
        private double _weight;
        private GenderEnum _gender;
        private ActivityLevel _activityLevel;
        private int _birthYear;
        private string _name = "NoName"; // default value

        public string Name
        {
            get => _name;
            set => _name = value;  

        }

        public int BirthYear
        {
            get => _birthYear;
            set
            {
                if (value < 1900 || value >= DateTime.Now.Year)
                {
                    throw new ArgumentException("Year of birth must be a valid year between 1900 and now.");
                }
                _birthYear = value;
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be greater than zero.");
                }

                _height = value;

            }


        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be greater than zero.");
                }

                _weight = value;

            }


        }

        public GenderEnum Gender
        {
            get => _gender;
            set => Gender = value;
        }

        public ActivityLevel ActivityLevel
        {
            get => _activityLevel;
            set => _activityLevel = value;
        }





        public Person(double height,
                      double width,
                      GenderEnum gender,
                      ActivityLevel activityLevel)
        {
            this._height = height;
            this._weight = width;
            this._gender = gender;
            this._activityLevel = activityLevel;
        }



    }
}
