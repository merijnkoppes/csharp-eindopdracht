using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_eindopdracht
{
    class Album
    {
        public int Id { get; }
        public List<Nummer> AlbumNummers { get; } // Updated list name
        public int Duur { get; }

        public Album(int id, List<Nummer> nummers)
        {
            Id = id;
            AlbumNummers = nummers; // Updated list name
            Duur = CalculateAlbumDuur();
        }

        public void PlayAlbum()
        {
            // Play each song in the album
            foreach (Nummer nummer in AlbumNummers) // Updated list name
            {
                nummer.PlayNummer();
            }
        }

        private int CalculateAlbumDuur()
        {
            // Calculate the total duration of the album
            int totalDuur = 0;
            foreach (Nummer nummer in AlbumNummers) // Updated list name
            {
                totalDuur += nummer.getDuur();
            }
            return totalDuur;
        }
    }
}