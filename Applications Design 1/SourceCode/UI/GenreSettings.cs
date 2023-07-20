using Data;
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
    public partial class GenreSettings : UserControl
    {
        private IGenreLogic _genreLogic;
        private IMovieLogic _movieLogic;
        private Form1 _form;
        private IAccountLogic _accountLogic;

        public GenreSettings(Form1 form, IGenreLogic genreLogic, IMovieLogic movieLogic, IAccountLogic accountLogic)
        {
            _form = form;
            _genreLogic = genreLogic;
            _movieLogic = movieLogic;
            _accountLogic = accountLogic;
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            if (_genreLogic.GetAllGenres().Count != 0)
            {
                listBoxRemoveGenre.Items.Clear();
                Genre[] arrayGenre = _genreLogic.GetAllGenres().ToArray();

                foreach (Genre genre in arrayGenre)
                {
                    listBoxRemoveGenre.Items.Add(genre);
                }
            }
            else {
                listBoxRemoveGenre.Items.Clear();
            }
        }

        private void buttonAddGenre_Click(object sender, EventArgs e)
        {
            if (_genreLogic.SearchGenre(textBoxGenreName.Text.Trim()) == null)
            {
                if (textBoxGenreName.Text.Trim() != "")
                {
                    Genre genre = new Genre()
                    {
                        Name = textBoxGenreName.Text.Trim(),
                        Description = textBoxGenreDescription.Text.Trim(),
                    };
                    _genreLogic.AddNewGenre(genre,_accountLogic.GetCurrentAccount());
                    MessageBox.Show("Genre created correctly");
                    CleanScreen();
                    PopulateListBox();
                }
                else {
                    MessageBox.Show("A Genre must have a name");
                }
                
            }
            else
            {
                MessageBox.Show("A genre with that name already exists");
            }
            
        }

        private void buttonRemoveGenre_Click(object sender, EventArgs e)
        {
            if (listBoxRemoveGenre.SelectedItem != null)
            {
                if ((string)listBoxRemoveGenre.SelectedItem.ToString() != "") {
                    Genre genre = (Genre)listBoxRemoveGenre.SelectedItem;
                    try
                    {
                        _genreLogic.DeleteGenre(genre.ToString(), _accountLogic.GetCurrentAccount());
                        PopulateListBox();

                    }
                    catch(GenreRepoException error) {
                        MessageBox.Show(error.Message);
                    }


                } 

            }
        }

        private void CleanScreen()
        {
            textBoxGenreName.Text = "";
            textBoxGenreDescription.Text = "";
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToAdmin();
        }
    }
}
