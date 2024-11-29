// written by Henrik Henriksson(AQ7150)

using EventOrganizerApp.Classes;
using EventOrganizerApp.Classes.Managers;

namespace Assignment5_HT2024_DA204E_AQ7150.Classes
{
    public class EventManager
    {

        private ParticipantManager participantManager;

        private decimal costPerPerson;
        private decimal feePerPerson;


        public EventManager(decimal costPerPerson, decimal feePerPerson)
        {
            CostPerPerson = costPerPerson;
            FeePerPerson = feePerPerson;
            participantManager = new ParticipantManager();

        }

        public EventManager()
        {
            CostPerPerson = 0;
            FeePerPerson = 0;
            participantManager = new ParticipantManager();

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


        public bool AddParticipant(string firstName, string lastName, Address address)
        {
            Participant participant = new Participant(firstName, lastName, address);
            return participantManager.AddParticipant(participant);
        }

        public bool RemoveParticipant(int index)
        {
            return (participantManager.RemoveParticipant(index));
        }
        public bool UpdateParticipant(int index, string newFirstName, string newLastName, Address newAddress)
        {


            try
            {
                Participant participant = participantManager.GetParticipantAt(index);

                // In case the user only chooses to update one of the three values, we want only that/those values to be changed, the if checks will prevent argumentException in the Property validation
                if (!string.IsNullOrEmpty(newFirstName))
                {
                    participant.FirstName = newFirstName;
                }
                if (!string.IsNullOrEmpty(newLastName))
                {
                    participant.LastName = newLastName;
                }

                if (newAddress != null)
                {
                    participant.Address = newAddress;
                }
                return true;


            }
            catch (ArgumentOutOfRangeException)
            { // index out of range check

                return false;
            }
            catch (ArgumentException)
            { // Validation failed

                return false;
            }

        }


        public Participant GetParticipantAt(int index)
        {
            return participantManager.GetParticipantAt(index);
        }
        public decimal GetTotalCost()
        {
            return participantManager.GetNumberOfParticipants() * CostPerPerson;
        }

        public decimal GetTotalRevenue()
        {
            return participantManager.GetNumberOfParticipants() * FeePerPerson;
        }

        public decimal GetSurplusOrDeficit()
        {

            return GetTotalRevenue() - GetTotalCost();
        }

        public string[] GetParticipantList()
        {
            return participantManager.GetParticipantsInfo();
        }


    }
}



