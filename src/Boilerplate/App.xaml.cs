using System.Threading.Tasks;
using Boilerplate.Services.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Boilerplate
{
    public partial class App : Application
    {
        static App() => BuildDependencies();

        Task InitializeNavigation() => Bootstrap.Instance.Resolve<INavigationService>().InitializeAsync();

        public App()
        {
            InitializeComponent();
            InitializeNavigation();
        }

        static void BuildDependencies()
        {
            Preferences.UseFakes = true;

            Bootstrap.Instance.Build();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
