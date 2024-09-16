using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1HT24_HT2024_DA204E_AQ7150.Classes
{
    internal class Album
    {
        private string albumName;
        private string artistName;
        private int numberOfTracks;

        public Album()
        {
            albumName = string.Empty;
            artistName = string.Empty;
            numberOfTracks = -1;
        }

        public void Start()
        {
            
            ReadAlbumName();
            ReadArtistName();
            ReadTracks();
            DisplayAlbumInfo();
        }

        private void ReadTracks()
        {
            numberOfTracks = GetNumberInput($"How many tracks does {albumName} have?");
        }

        private void ReadArtistName()
        {
            artistName = ReadInput($"What is the name of the Artist or band for {albumName}?");
        }

        private void ReadAlbumName()
        {
            albumName = ReadInput("What is the name of your favorite music album?");
        }

        private void DisplayAlbumInfo()
        {

            Console.WriteLine($"\nAlbum Name: {albumName}" +
                $"\nArtist/Band: {artistName}" +
                $"\nNumberOfTracks: {numberOfTracks}" +
                $"\nEnjoy Listening!");

        }

        private string ReadInput(string message)
        {
            string userInput = string.Empty;

            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(message);
                userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Input cannot be empty or just whitespace. Please enter a valid name.");
                }
            }

            return userInput;

        }

        private int GetNumberInput(string message)
        {

            int parsedNumber = -1;
            bool isValidInt = false;
            string input = string.Empty;

            while (parsedNumber < 0)
            {

                Console.WriteLine(message);
                input = Console.ReadLine();

                isValidInt = int.TryParse(input, out parsedNumber);

                if (isValidInt && parsedNumber >= 0)
                {
                    // Valid input
                    return parsedNumber;
                }
                else if (!isValidInt)
                {

                    Console.WriteLine($"Your input {input} is not a valid number."
                        + $"\n Please enter your pet as a number");

                }
                else
                {
                    Console.WriteLine("Age cannot be negative. Please enter a valid age");
                }
            }
            return parsedNumber;
        }

    }
}
