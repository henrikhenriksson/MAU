using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_HT2024_DA204E_AQ7150.Classes
{
    internal class EventManager
    {


        private Guest[] guestList;
        private int numOfElems;
        private double costPerPerson;
        private double feePerPerson;

        public EventManager(int Size)
        {
            guestList = new Guest[Size];
            numOfElems = 0;
        }

        public double CostPerPerson
        {
            get => costPerPerson;

            set
            {
                if (value >= 0) // add additional validation?
                {
                    costPerPerson = value;
                }
            }
        }

        public double FeePerPerson
        {
            get { return feePerPerson; }
            set
            {
                if (value >= 0) { feePerPerson = value; }
            }
        }


        public bool AddGuest(string firstName, string lastName)
        {
            try
            {
                if (numOfElems < guestList.Length)
                {
                    Guest newGuest = new Guest(firstName, lastName);

                    guestList[numOfElems] = newGuest;
                    numOfElems++;
                    return true;

                }
            }
            catch (ArgumentException ex)
            {
                throw; // rethrow the ex to be handled in the mainform class.
            }
            return false; // guestList is full.

        }

        public bool RemoveGuest(int index)
        {
            if (index > 0 && index < numOfElems)
            {
                guestList[index] = null;
                MoveElementsOneStepLeft(index);
                numOfElems--;
                return true;

            }
            return false;

        }
        public bool UpdateGuest(int index, string newFirstName, string newLastName)
        {
            if (index >= 0 && index < numOfElems)
            {
                try
                {

                    guestList[index].FirstName = newFirstName;
                    guestList[index].LastName = newLastName;
                    return true;
                }
                catch (ArgumentException ex)
                {
                    throw; // rethrow exception to be handled in GUI class
                }

            }
            return false;
        }


        // as an entry is removed, the others will need to be adjusted accordingly.
        private void MoveElementsOneStepLeft(int guestEntryIndex)
        {
            for (int i = guestEntryIndex; i < numOfElems; i++)
            {
                guestList[i] = guestList[i + 1];
            }

            guestList[numOfElems - 1] = null; // remove the last element.


        }

        public double GetTotalCost()
        {
            return numOfElems * CostPerPerson;
        }

        public double GetTotalRevenue()
        {
            return numOfElems * FeePerPerson;
        }

        public double GetSurplusOrDeficit()
        {

            return GetTotalRevenue() - GetTotalCost();
        }

        public string[] GetGuestList() // to ensure capsulation, we return only the names of the Guest object
        {

            return GenerateGuestList();


        }

        private string[] GenerateGuestList()
        {
            string[] guestNames = new string[numOfElems];

            for (int i = 0; i < numOfElems; i++)
            {
                guestNames[i] = guestList[i].GetFullName();
            }
            return guestNames;

        }

    }
}



