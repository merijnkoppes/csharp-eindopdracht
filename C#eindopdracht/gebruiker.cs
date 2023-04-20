using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_eindopdracht
{

    class Gebruiker
    {
        public int Id { get; }
        public string Gebruikersnaam { get; }
        public List<Afspeellijst> Afspeellijsten { get; set; }
        public List<Gebruiker> Vriendenlijst { get; set; }

        public Gebruiker(int id, string gebruikersnaam)
        {
            Id = id;
            Gebruikersnaam = gebruikersnaam;
            Afspeellijsten = new List<Afspeellijst>();
            Vriendenlijst = new List<Gebruiker>();
        }

        public void CallNummer(int nummerId)
        {
            // Find the song with the specified ID in the user's playlists
            Nummer nummer = null;
            foreach (Afspeellijst afspeellijst in Afspeellijsten)
            {
                nummer = afspeellijst.AfspeellijstNummers.Find(n => n.getId() == nummerId);
                if (nummer != null)
                {
                    break;
                }
            }

            if (nummer != null)
            {
                // Play the song
                nummer.PlayNummer();
            }
            else
            {
                // Song not found
                System.Console.WriteLine("Song not found in any playlist.");
            }
        }

        public void CallAlbum(int albumId)
        {
            // Find the album with the specified ID
            Album album = null;
            foreach (Album a in Program.albums)
            {
                if (a.Id == albumId)
                {
                    album = a;
                    break;
                }
            }

            if (album != null)
            {
                // Play the album
                album.PlayAlbum();
            }
            else
            {
                // Album not found
                System.Console.WriteLine("Album not found.");
            }
        }

        public void CallAfspeellijst(int afspeellijstId)
        {
            // Find the playlist with the specified ID
            Afspeellijst afspeellijst = Afspeellijsten.Find(a => a.Id == afspeellijstId);

            if (afspeellijst != null)
            {
                // Play the playlist
                afspeellijst.PlayAfspeellijst();
            }
            else
            {
                // Playlist not found
                System.Console.WriteLine("Playlist not found.");
            }
        }
    }
}
