namespace Lands.Infrastructure
{
    using ViewModels;
    public class InstanceLocator
    {
        #region Propierties
        public object Main
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
