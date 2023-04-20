using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_eindopdracht
{
    class Afspeellijst
    {
        private List<Nummer> nummers;

        public int Id { get; }
        public string Name { get; } // Add a Name property
        public List<Nummer> AfspeellijstNummers { get; } // Updated list name
        public int Duur { get; }

        public Afspeellijst(int id, string name, List<Nummer> nummers) // Update constructor to accept a name parameter
        {
            Id = id;
            Name = name; // Set the name property
            AfspeellijstNummers = nummers; // Updated list name
            Duur = CalculateAfspeellijstDuur();
        }

        public void PlayAfspeellijst()
        {
            // Play each song in the playlist
            foreach (Nummer nummer in AfspeellijstNummers) // Updated list name
            {
                nummer.PlayNummer();
            }
        }

        private int CalculateAfspeellijstDuur()
        {
            // Calculate the total duration of the playlist
            int totalDuur = 0;
            foreach (Nummer nummer in AfspeellijstNummers) // Updated list name
            {
                totalDuur += nummer.getDuur();
            }
            return totalDuur;
        }
    }
}