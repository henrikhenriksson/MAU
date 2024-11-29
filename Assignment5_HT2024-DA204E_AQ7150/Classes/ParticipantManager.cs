// written by Henrik Henriksson(AQ7150)

using Assignment5_HT2024_DA204E_AQ7150.Classes;

namespace EventOrganizerApp.Classes.Managers
{
    internal class ParticipantManager
    {
        private List<Participant> participants;

        public ParticipantManager()
        {
            participants = new List<Participant>(); // we initialize the list directly in the constructor
        }


        public bool AddParticipant(Participant participant)
        {

            // make sure the participant isnt null
            if (participant == null)
            {
                return false;
            }

            if (ParticipantExists(participant.FirstName, participant.LastName, participant.Address.Street))
            {
                return false;
            }
                

            participants.Add(participant);
            return true;

        }

        public bool RemoveParticipant(int index)
        {
            if (CheckIndex(index))
            {
                participants.RemoveAt(index);
                return true;
            }

            return false;

        }

        public Participant GetParticipantAt(int index)
        {
            if (CheckIndex(index))
            {
                return participants[index];
            }
            throw new ArgumentOutOfRangeException($"Invalid index at : {index}");
        }

        public int GetNumberOfParticipants() { return participants.Count; }


        public string[] GetParticipantsInfo()
        {
            return participants.Select(p => p.ToString()).ToArray();
        }

        // check if valid index
        private bool CheckIndex(int index)
        {
            return index >= 0 && index < participants.Count;
        }

        public bool ParticipantExists(string firstName, string lastName, string street)
        {
            return participants.Any(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)
            && p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) && p.Address.Street.Equals(street, StringComparison.OrdinalIgnoreCase)); // i'll be damned if 2 persons with the same name live on addresses with the same street name in different cities or something. Can of course be expanded upon if one was inclined.
        }

    }
}
