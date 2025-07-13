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
                    Title = "Rock that CancellationTokenSource (Asynchronous ballad)",
                    Artist = "Gerald and the CancellationTokens",
                    AlbumArt = "song1.png"
                },
                new Song
                {
                    Title = "Till' I collapse the Azure instance",
                    Artist = "David Ortinau ft Eminem",
                    AlbumArt = "song2.png"
                },
                new Song
                {
                    Title = "Why Matt Believes a Man Can Fly",
                    Artist = "The Beer Driven Devs",
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