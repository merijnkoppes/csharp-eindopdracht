using System;
using System.Collections.Generic;

namespace C_eindopdracht
{
    class Program
    {
        public static List<Album> albums = new List<Album> {
            new Album(1, new List<Nummer> {
                new Nummer(1, "Song 1", 180, "Artist 1"),
                new Nummer(2, "Song 2", 240, "Artist 1"),
                new Nummer(3, "Song 3", 300, "Artist 2")
            }),
            new Album(2, new List<Nummer> {
                new Nummer(4, "Song 4", 200, "Artist 3"),
                new Nummer(5, "Song 5", 260, "Artist 4"),
                new Nummer(6, "Song 6", 220, "Artist 5")
            })
        };
        static void Main(string[] args)
            {
                // Create some sample users, albums, playlists, and songs
                var users = new List<Gebruiker> {
                new Gebruiker(1, "Alice"),
                new Gebruiker(2, "Bob")
            };
                var playlists = new List<Afspeellijst> {
                new Afspeellijst(1, "afspeellijst1",new List<Nummer> {
                    albums[0].AlbumNummers[0],
                    albums[1].AlbumNummers[1],
                    albums[0].AlbumNummers[2]
                }),
                new Afspeellijst(2, "afspeellijst1", new List<Nummer> {
                    albums[1].AlbumNummers[0],
                    albums[0].AlbumNummers[1],
                    albums[1].AlbumNummers[2]
                })
            };

                // Assign the playlists to the users' accounts
                users[0].Afspeellijsten = new List<Afspeellijst> { playlists[0], playlists[1] };
                users[1].Afspeellijsten = new List<Afspeellijst> { playlists[1] };

                // Make users friends with each other
                users[0].Vriendenlijst = new List<Gebruiker> { users[1] };
                users[1].Vriendenlijst = new List<Gebruiker> { users[0] };

                // Display a menu to the user
                Console.WriteLine("Welcome to the Spotify-like CLI program!");
                Console.WriteLine("Please enter your user ID:");
                int userId = int.Parse(Console.ReadLine());
                Gebruiker user = users.Find(u => u.Id == userId);

                if (user != null)
                {
                    Console.WriteLine($"Hello, {user.Gebruikersnaam}!");

                // TODO: Implement the user interface and interaction with the other classes here


                }
                else
                {
                    Console.WriteLine("Invalid user ID. Exiting program.");
                }
                Console.WriteLine("Your playlists:");
                foreach (var afspeellijst in user.Afspeellijsten)
                {
                    Console.WriteLine(afspeellijst.Id);
                }
                foreach (Album album in albums)
                {
                    Console.WriteLine($"Album {album.Id}:");
                    foreach (Nummer song in album.AlbumNummers)
                    {
                        Console.WriteLine($"- {song.Artiest} - {song.Titel} ({song.Duur} seconds)");
                    }
                }
            // Let the user select a playlist to play
            Console.WriteLine("Please enter the ID of the playlist you want to play:");
                int playlistId = int.Parse(Console.ReadLine());

                Afspeellijst selectedPlaylist = user.Afspeellijsten.Find(p => p.Id == playlistId);

                if (selectedPlaylist != null)
                {
                    Console.WriteLine($"Now playing playlist: {selectedPlaylist.Id}");
                    selectedPlaylist.PlayAfspeellijst();
                }
                else
                {
                    Console.WriteLine("Invalid playlist ID.");
                }
            }
        }
    }
