namespace LogroconTestApp.WPFMasterDetails.Interface
{
    public interface IModalDialog
    {
        void BindViewModel<TViewModel>(TViewModel viewModel);

        void ShowDialog();

        void Close();
    }
}