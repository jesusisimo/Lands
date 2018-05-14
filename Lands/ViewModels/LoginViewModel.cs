namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Propierties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }


        #endregion
        #region Constructrs
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;
            this.Email = "jesus@brb.com.mx";
            this.Password = "jesus";
        }
        #endregion


        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Your must enter an email", "Acept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Your must enter a password", "Acept");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            if (this.Email != "jesus@brb.com.mx" || this.Password != "jesus")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Email or password incorrect", "Acept");
                this.Password = string.Empty;
                return;
            }
            await Application.Current.MainPage.DisplayAlert("OK", "Correct", "Acept");
            this.IsRunning = false;
            this.IsEnabled = true;
            //await Application.Current.MainPage.DisplayAlert("OK", "Correct", "Acept");
            this.Email = string.Empty;
            this.Password = string.Empty;
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }
}
