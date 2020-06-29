using Apprtist.PageModels;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Apprtist
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            Page page = FreshPageModelResolver.ResolvePageModel<IntroPageModel>();

            FreshNavigationContainer container = new FreshNavigationContainer(page)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#125aae")
            };

            MainPage = container;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
