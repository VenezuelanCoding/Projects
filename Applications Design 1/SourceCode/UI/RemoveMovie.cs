using Domain;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class RemoveMovie : UserControl
    {
        private IMovieLogic _movieLogic;
        private Form1 _form;
        private IAccountLogic _accountLogic;

        public RemoveMovie(Form1 form, IMovieLogic movieLogic, IAccountLogic accountLogic)
        {
            _form = form;
            _accountLogic = accountLogic;
            _movieLogic = movieLogic;
            InitializeComponent();
            PopulateFieldsBoxes();
        }

        private void PopulateFieldsBoxes()
        {
            if (_movieLogic.GetAllMovies().Count != 0)
            {
                Movie[] arrayMovies = _movieLogic.GetAllMovies().ToArray();

                foreach (Movie movie in arrayMovies)
                {
                    listBoxRemoveMovie.Items.Add(movie);
                }
            }
        }

        private void CleanScreen()
        {
            listBoxRemoveMovie.Items.Clear();
        }

        private void buttonRemoveMovie2_Click(object sender, EventArgs e)
        {
            if (listBoxRemoveMovie.SelectedItem != null)
            {
                Movie movie = (Movie)listBoxRemoveMovie.SelectedItem;
                _movieLogic.DeleteMovie(movie, _accountLogic.GetCurrentAccount());
                MessageBox.Show("Movie deleted correctly");
                CleanScreen();
                PopulateFieldsBoxes();
            }
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToMovieSettings();
        }
    }
}
