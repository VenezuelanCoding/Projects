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
    public partial class AddDirectorToMovie : UserControl
    {
        private IMovieLogic _movieLogic;
        private Form1 _form;
        private IAccountLogic _accountLogic;
        private IMemberLogic _memberLogic;

        public AddDirectorToMovie(Form1 form, IMovieLogic movieLogic, IAccountLogic accountLogic, IMemberLogic memberLogic)
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
            listBoxFinalDirectors.Items.Clear();
            listBoxPossibleDirectors.Items.Clear();
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

            IList<Member> members = _memberLogic.GetAllMembers().ToArray();
            IList<Member> directors = new List<Member>();
            foreach (var possibleDirector in members)
            {
                if (possibleDirector.Type == MemberType.Director || possibleDirector.Type == MemberType.ActorAndDirector)
                {
                    directors.Add(possibleDirector);
                }
            }

            if (directors.Count != 0)
            {
                foreach (Member director in directors)
                {
                    listBoxPossibleDirectors.Items.Add(director);
                }
            }

        }

        private void buttonAddDirector_Click(object sender, EventArgs e)
        {
            if (listBoxPossibleDirectors.SelectedItem != null)
            {
                Member selectedDirector = (Member)listBoxPossibleDirectors.SelectedItem;
                listBoxFinalDirectors.Items.Add(selectedDirector);
                listBoxPossibleDirectors.Items.Remove(selectedDirector);
            }
        }

        private void buttonRemoveDirector_Click(object sender, EventArgs e)
        {
            if (listBoxFinalDirectors.SelectedItem != null)
            {
                Member selectedDirector = (Member)listBoxFinalDirectors.SelectedItem;
                listBoxPossibleDirectors.Items.Add(selectedDirector);
                listBoxFinalDirectors.Items.Remove(selectedDirector);
            }
        }

        private void buttonAddDirectors_Click(object sender, EventArgs e)
        {
            try
            {
                List<Member> finalDirectors = listBoxFinalDirectors.Items.Cast<Member>().ToList();
                Movie possibleMovie = (Movie)listBoxMovies.SelectedItem;
                Account currentAccount = _accountLogic.GetCurrentAccount();
                if (finalDirectors.Count != 0)
                {
                    if (listBoxMovies.SelectedItem != null)
                    {
                        foreach (var director in finalDirectors)
                        {
                            _movieLogic.AddDirectorToMovie(director, currentAccount, possibleMovie);
                        }
                        CleanScreen();
                        PopulateFieldsBoxes();
                        MessageBox.Show("Director/s added correctly to the movie!");
                    }
                    else
                    {
                        MessageBox.Show("Please select a movie to add the director/ to");
                    }
                }
                else
                {
                    MessageBox.Show("Please add at least one director to the movie");

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToDirectorSettings();
        }
    }
}
