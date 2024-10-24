// written by Henrik Henriksson(AQ7150)

namespace Assignment4_HT2024_DA204E_AQ7150.Classes
{
    public class EventManager
    {


        private Guest[] guestList;
        private int numOfElems;

        // https://learn.microsoft.com/en-us/answers/questions/709941/double-or-decimal-for-amount
        // decimal seems to be preferred over double for currency amounts.
        private decimal costPerPerson;
        private decimal feePerPerson;


        public EventManager(int Size)
        {
            guestList = new Guest[Size];
            numOfElems = 0;
        }

        public decimal CostPerPerson
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

        public decimal FeePerPerson
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
                    guestList[numOfElems] = new Guest(firstName, lastName);
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

        public decimal GetTotalCost()
        {
            return numOfElems * CostPerPerson;
        }

        public decimal GetTotalRevenue()
        {
            return numOfElems * FeePerPerson;
        }

        public decimal GetSurplusOrDeficit()
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
        // check to make sure no duplicate guests are added.
        // if there are 2 people with the same name, middle names can be used do differentiate them.
        public bool GuestExists(string firstName, string lastName)
        {

            if(guestList == null || guestList.Count() == 0) { return false; } // no guests can be duplicates if no guests have been added.

            foreach (Guest guest in guestList)
            {
                if (guest == null) continue;
                
                if (guest.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    guest.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }


    }
}



