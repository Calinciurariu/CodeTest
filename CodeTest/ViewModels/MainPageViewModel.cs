using CodeTest.Interfaces;
using CodeTest.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.ViewModels
{
    public partial class MainPageViewModel : BaseTestViewModel
    {
        #region Properties
        [ObservableProperty]
        private ObservableCollection<Song> _songs;

        [ObservableProperty]
        private Song _currentSong;

        [ObservableProperty]
        private int _currentPosition;

        [ObservableProperty]
        private bool _isPlaying = true;

        [ObservableProperty]
        private string _playPauseIcon = Helpers.FontAwesomeIcons.FaPause;
        #endregion

        public MainPageViewModel(INavigationPageService navigation) : base(navigation)
        {
            LoadSongs();
            CurrentSong = Songs.FirstOrDefault();
        }

        private void LoadSongs()
        {
            Songs = new ObservableCollection<Song>
            {
                new Song
                {
                    Title = "The Night We Met Under The Stars Of A Thousand Skies",
                    Artist = "Lord Huron & The Interstellar Orchestra",
                    AlbumArt = "song1.png"
                },
                new Song
                {
                    Title = "Echoes in the Grand Canyon of a Billion Forgotten Dreams",
                    Artist = "The Celestial Harmonies Philharmonic",
                    AlbumArt = "song2.png"
                },
                new Song
                {
                    Title = "A Long and Winding Road to Nowhere in Particular",
                    Artist = "The Philosophical Troubadours",
                    AlbumArt = "song3.png"
                }
            };
        }

        partial void OnCurrentPositionChanged(int value)
        {
            CurrentSong = Songs[value];
        }

        [RelayCommand]
        private void PlayPause()
        {
            IsPlaying = !IsPlaying;
            PlayPauseIcon = IsPlaying ? Helpers.FontAwesomeIcons.FaPause : Helpers.FontAwesomeIcons.FaPlay;
        }

        [RelayCommand]
        private void NextTrack()
        {
            if (CurrentPosition < Songs.Count - 1)
            {
                CurrentPosition++;
            }
            else
            {
                CurrentPosition = 0; // Loop back to the start
            }
        }

        [RelayCommand]
        private void PreviousTrack()
        {
            if (CurrentPosition > 0)
            {
                CurrentPosition--;
            }
            else
            {
                CurrentPosition = Songs.Count - 1; // Loop to the end
            }
        }
    }
}