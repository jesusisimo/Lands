namespace Lands.ViewModels
{
	using Models;
	using System.Windows.Input;
	using GalaSoft.MvvmLight.Command;
	using Xamarin.Forms;
	using Views;
	public class LandItemViewModel : Land
	{
		#region Commandos
		public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
        }

		public async void SelectLand()
        {
			MainViewModel.GetInstance().Land=new LandViewModel(this);
			await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }
		#endregion
	}
}
