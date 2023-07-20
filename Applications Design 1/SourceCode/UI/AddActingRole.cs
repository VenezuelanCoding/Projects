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
    public partial class AddActingRole : UserControl
    {
        private Form1 _form;
        private IMemberLogic _memberLogic;
        private IMovieLogic _movieLogic;
        private IAccountLogic _accountLogic;
        private Account currentAccount;


        public AddActingRole(Form1 form, IMemberLogic memberLogic, IMovieLogic movieLogic, IAccountLogic accountLogic)
        {
            _memberLogic = memberLogic;
            _form = form;
            _movieLogic = movieLogic;
            _accountLogic = accountLogic;

            currentAccount = _accountLogic.GetCurrentAccount();

            InitializeComponent();

            populateFieldsBoxes();
        }


        private void CleanUp()
        {
            listBoxMembers.Items.Clear();
            listBoxMovies.Items.Clear();
            textBoxName.Text = "";
        }

        private void populateFieldsBoxes()
        {
            if (_memberLogic.GetAllMembers().Count != 0)
            {
                Member[] arrayMembers = _memberLogic.GetAllMembers().ToArray();

                foreach (Member member in arrayMembers)
                {
                    if (member.Type != MemberType.Director)
                    {
                        listBoxMembers.Items.Add(member);
                    }
                }

            }

            if (_movieLogic.GetAllMovies().Count != 0)
            {
                Movie[] arrayMovies = _movieLogic.GetAllMovies().ToArray();

                foreach (Movie movie in arrayMovies)
                {
                    listBoxMovies.Items.Add(movie);
                }

            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() != "")
            {
                if (listBoxMembers.SelectedItem != null)
                {
                    if (listBoxMovies.SelectedItems != null)
                    {
                        Member possibleMember = (Member)listBoxMembers.SelectedItem;
                        Movie possibleMovie = (Movie)listBoxMovies.SelectedItem;

                        ActingRole actingRole = new ActingRole()
                        {
                            Name = textBoxName.Text,
                            Member = possibleMember,
                        };
                        try
                        {
                            _movieLogic.AddActingRoleToMovie(actingRole, currentAccount, possibleMovie);
                            MessageBox.Show("Acting role added correctly");
                        }
                        catch (MovieRepoException err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        CleanUp();
                        populateFieldsBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Please select a movie for the acting role");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a member for the acting role");
                }
            }
            else
            {
                MessageBox.Show("Please enter a name for the acting role");
            }
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToActingRoleSettings();
        }
    }
}
