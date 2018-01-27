using System;
using LogroconTestApp.WPFMasterDetails.Interface;

namespace LogroconTestApp.WPFMasterDetails.View
{
    public class CitiesViewDialog : IModalDialog
    {
        private CitiesView view;

        void IModalDialog.BindViewModel<TViewModel>(TViewModel viewModel)
        {
            GetDialog().DataContext = viewModel;
        }

        void IModalDialog.ShowDialog()
        {
            GetDialog().ShowDialog();
        }

        void IModalDialog.Close()
        {
            GetDialog().Close();
        }

        private CitiesView GetDialog()
        {
            if (view == null)
            {
                view = new CitiesView();
                view.Closed += view_Closed;
            }
            return view;
        }

        void view_Closed(object sender, EventArgs e)
        {
            view = null;
        }

    }
}

