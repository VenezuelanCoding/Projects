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
    public partial class DissociateAnActingRole : UserControl
    {
        private IMovieLogic _movieLogic;
        private Form1 _form;
        private IAccountLogic _accountLogic;
        private IMemberLogic _memberLogic;

        public DissociateAnActingRole(Form1 form, IMovieLogic movieLogic, IAccountLogic accountLogic, IMemberLogic memberLogic)
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
            listBoxActors.Items.Clear();
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

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToActingRoleSettings();
        }

        private void buttonLoadActors_Click(object sender, EventArgs e)
        {
            listBoxActors.Items.Clear();
            if (listBoxMovies.SelectedItem != null)
            {
                Movie selectedMovie = (Movie)listBoxMovies.SelectedItem;
                Movie selectedmovieDB = _movieLogic.GetMovieById(selectedMovie.Id);
                IList<ActingRole> actors = selectedmovieDB.ActingRoles;
                foreach (var actor in actors)
                {
                    listBoxActors.Items.Add(actor);
                }
            }
            else
            {
                MessageBox.Show("Please select a movie");
            }
        }

        private void buttonAddDirectors_Click(object sender, EventArgs e)
        {
            if (listBoxActors.SelectedItem != null && listBoxMovies.SelectedItems != null)
            {
                ActingRole actor = (ActingRole)listBoxActors.SelectedItem;
                Account currentAccount = _accountLogic.GetCurrentAccount();
                Movie movie = (Movie)listBoxMovies.SelectedItem;

                _movieLogic.DetachActingRole(actor, currentAccount, movie);
                CleanScreen();
                PopulateFieldsBoxes();
                MessageBox.Show("Actor dissociated correctly from movie");
            }
            else
            {
                MessageBox.Show("Please select an actor to dissociate");
            }
        }
    }
}
