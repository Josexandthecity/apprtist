
using Apprtist.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Apprtist.PageModels
{
    public class IntroPageModel : BasePageModel
    {
        ObservableCollection<Intro> presentationData;
        public ObservableCollection<Intro> PresentationData
        {
            get { return presentationData; }
            set { presentationData = value; RaisePropertyChanged(); }
        }

        bool introButtonIsVisible;
        public bool IntroButtonIsVisible
        {
            get { return introButtonIsVisible; }
            set { introButtonIsVisible = value; RaisePropertyChanged(); }
        }

        string introText;
        public string IntroText
        {
            get { return introText; }
            set { introText = value; RaisePropertyChanged(); }
        }

        int position;
        public int Position
        {
            get { return position; }
            set {
                position = value;
                RaisePropertyChanged();
                OnPositionChanged();
            }
        }

        bool isAnArtist;
        public bool IsAnArtist
        {
            get { return isAnArtist; }
            set { isAnArtist = value; RaisePropertyChanged(); }
        }

        bool isAUser;
        public bool IsAUser
        {
            get { return isAUser; }
            set { isAUser = value; RaisePropertyChanged(); }
        }

        public Command ArtistButtonCommand => new Command(async () => await NavArtistButtonSelected());

        public Command UserButtonCommand => new Command(async () => await NavUserButtonSelected());

        public IntroPageModel()
        {
            LoadPresentationData();
        }

        private async Task NavArtistButtonSelected()
        {
            IsAnArtist = true;
            IsAUser = false;
            await PushAsync<LoginPageModel>();
        }
        private async Task NavUserButtonSelected()
        {
            IsAUser = true;
            IsAnArtist = false;
            await PushAsync<LoginPageModel>();
        }

        private void OnPositionChanged()
        {
            if (Position == 1)
            {
                IntroButtonIsVisible = true;
            }
            else
            {
                IntroButtonIsVisible = false;
            }
        }

        private void LoadPresentationData()
        {
            PresentationData = new ObservableCollection<Intro>
            {
                new Intro
                {
                    ImageUrl = "https://get.wallhere.com/photo/1920x1080-px-Minecraft-pixels-video-games-687863.jpg",
                },
                new Intro
                {
                    ImageUrl = "https://get.wallhere.com/photo/nature-landscape-pixel-art-pixelated-pixels-mountains-Wavestormed-trees-snowy-peak-forest-lake-grass-hill-reflection-pine-trees-sunset-clear-sky-1523669.jpg",
                }
            };
            IntroText = "Welcome to Apprtist the new form to choise the artist for your event";
        }
    }
}

