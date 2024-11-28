using Assignment4_HT2024_DA204E_AQ7150.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (participant != null)
            {
                participants.Add(participant);
                return true;
            }

            return false;

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


        // check if valid index
        private bool CheckIndex(int index)
        {
            return index >= 0 && index < participants.Count;
        }

    }
}
