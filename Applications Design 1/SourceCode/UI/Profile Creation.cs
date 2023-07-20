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
    public partial class Profile_Creation : UserControl
    {
        private IAccountLogic _accountLogic;
        private Form1 _form;

        public Profile_Creation(Form1 form, IAccountLogic accountLogic)
        {
            _form = form;
            _accountLogic = accountLogic;
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if(textBoxAlias.Text.Length > 1 && textBoxAlias.Text.Length < 16)
            {
                try
                {
                    Profile profile = new Profile()
                    {
                        Alias = textBoxAlias.Text.Trim(),
                        Pin = numericUpDown1.Value.ToString(),
                        IsOwner = false,
                        IsChildren = false,

                    };
              

                    if (_accountLogic.GetCurrentAccount().Profiles.Count == 0)
                    {
                        profile.IsOwner = true;
                    }

                    _accountLogic.AddProfile(profile, _accountLogic.GetCurrentAccount());

                    _accountLogic.SetCurrentAccount(_accountLogic.SearchAccountByEmail(_accountLogic.GetCurrentAccount().Email));

                    _form.changeToLobby();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                };

            }
            else
            {
                MessageBox.Show("Please enter a valid alias (between 1 and 15 characters)");
            }
        }

        private void linkLabelCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_accountLogic.GetCurrentAccount().Profiles.Count() == 0)
            {
                _form.changeToLogin();
            }
            else
            {
                _form.changeToLobby();
            }
        }
    }
}
