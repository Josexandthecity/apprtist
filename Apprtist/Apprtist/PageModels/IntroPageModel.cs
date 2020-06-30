
using Apprtist.Models;
using System.Collections.ObjectModel;

namespace Apprtist.PageModels
{
    public class IntroPageModel : BasePageModel
    {
        ObservableCollection<IntroModel> presentationData;
        public ObservableCollection<IntroModel> PresentationData
        {
            get { return presentationData; }
            set { presentationData = value; RaisePropertyChanged(); }
        }

        public IntroPageModel()
        {
            LoadPresentationData();
        }

        private void LoadPresentationData()
        {
            PresentationData = new ObservableCollection<IntroModel>
            {
                new IntroModel
                {
                    ImageUrl = "https://picsum.photos/250?image=9",
                    Name = "First Presentation"
                },
                new IntroModel
                {
                    ImageUrl = "https://aka.ms/campus.jpg",
                    Name = "Second Presentation"
                }
            };
        }
    }
}

