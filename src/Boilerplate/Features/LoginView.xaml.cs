using Xamarin.Forms;

namespace Boilerplate.Features
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            UsernameEntry.Completed += (sender, e) => PasswordEntry.Focus();
        }
    }
}
