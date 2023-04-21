using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_eindopdracht
{
    class Nummer
    {
        private int Id { get; }
        public string Titel { get; }
        public int Duur { get; }
        public string Artiest { get; }
        private bool isPlaying;
        private bool isPaused;
        private CancellationTokenSource cts;
        private int currentPlaybackTime;

        public Nummer(int id, string titel, int duur, string artiest)
        {
            Id = id;
            Titel = titel;
            Duur = duur;
            Artiest = artiest;
        }

        public void PlayNummer()
        {
            isPlaying = true;
            isPaused = false;
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            currentPlaybackTime = 0;

            Console.WriteLine($"Playing '{Titel}' by {Artiest} ({Duur} seconds)");

            while (currentPlaybackTime < Duur)
            {
                if (isPaused)
                {
                    Console.WriteLine($"Paused '{Titel}'");
                    while (isPaused)
                    {
                        // Wait for resume command
                        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.P:
                                PauseNummer();
                                break;
                            case ConsoleKey.R:
                                ResumeNummer();
                                break;
                            case ConsoleKey.N:
                                SkipToNextNummer();
                                break;
                            case ConsoleKey.B:
                                SkipToPreviousNummer();
                                break;
                            case ConsoleKey.S:
                                StopNummer();
                                break;
                        }
                    }
                    Console.WriteLine($"Resumed '{Titel}'");
                }

                if (token.IsCancellationRequested)
                {
                    // Song is stopped
                    break;
                }

                Thread.Sleep(1000);
                currentPlaybackTime++;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"Playback time: {currentPlaybackTime} seconds");

                // Check for user input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.P:
                            PauseNummer();
                            break;
                        case ConsoleKey.R:
                            ResumeNummer();
                            break;
                        case ConsoleKey.N:
                            SkipToNextNummer();
                            break;
                        case ConsoleKey.B:
                            SkipToPreviousNummer();
                            break;
                        case ConsoleKey.S:
                            StopNummer();
                            break;
                    }
                }
            }

            if (!token.IsCancellationRequested)
            {
                StopNummer();
            }
        }

        private void PauseNummer()
        {
            if (isPlaying && !isPaused)
            {
                isPaused = true;
            }
        }

        private void ResumeNummer()
        {
            if (isPlaying && isPaused)
            {
                isPaused = false;
            }
        }

        private void SkipToNextNummer()
        {
            StopNummer();
            // Add logic to skip to the next song in the playlist
        }

        private void SkipToPreviousNummer()
        {
            StopNummer();
            // Add logic to skip to the previous song in the playlist
        }

        private void StopNummer()
        {
            if (isPlaying)
            {
                cts?.Cancel();
                isPlaying = false;
                isPaused = false;
                currentPlaybackTime = 0;
                Console.WriteLine($"Stopped '{Titel}'");
            }
        }
    }
}
