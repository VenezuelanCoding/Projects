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
    public partial class DissociateADirector : UserControl
    {
        private IMovieLogic _movieLogic;
        private Form1 _form;
        private IAccountLogic _accountLogic;
        private IMemberLogic _memberLogic;

        public DissociateADirector(Form1 form, IMovieLogic movieLogic, IAccountLogic accountLogic, IMemberLogic memberLogic)
        {
            _form = form;
            _accountLogic = accountLogic;
            _movieLogic = movieLogic;
            _memberLogic = memberLogic;
            InitializeComponent();
            PopulateFieldsBoxes();
        }

        private void CleanScreen()
        {
            listBoxMovies.Items.Clear();
            listBoxDirectors.Items.Clear();
        }

        private void PopulateFieldsBoxes()
        {
            if (_movieLogic.GetAllMovies().Count != 0)
            {
                Movie[] arrayMovies = _movieLogic.GetAllMovies().ToArray();

                foreach (Movie movie in arrayMovies)
                {
                    listBoxMovies.Items.Add(movie);
                }
            } 
        }

        private void buttonLoadDirectors_Click(object sender, EventArgs e)
        {

            listBoxDirectors.Items.Clear();
            if (listBoxMovies.SelectedItem != null)
            {
                Movie selectedMovie = (Movie)listBoxMovies.SelectedItem;
                IList<Member> directors = selectedMovie.Directors;
                foreach (var director in directors)
                {                 
                    listBoxDirectors.Items.Add(director);
                }
            }
            else
            {
                MessageBox.Show("Please select a movie");
            }
        }

        private void buttonAddDirectors_Click(object sender, EventArgs e)
        {
            if (listBoxDirectors.SelectedItem != null && listBoxMovies.SelectedItems != null)
            {
                Member director = (Member)listBoxDirectors.SelectedItem;
                Account currentAccount = _accountLogic.GetCurrentAccount();
                Movie movie = (Movie)listBoxMovies.SelectedItem;

                _movieLogic.DetachDirector(director, currentAccount, movie);
                CleanScreen();
                PopulateFieldsBoxes();
                MessageBox.Show("Director dissociated correctly from movie");
            }
            else
            {
                MessageBox.Show("Please select a director to dissociate");
            }

        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToDirectorSettings();
        }
    }
}
