using Data;
using Domain;
using Logic;
using Logic.Implementations;
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
    public partial class Login : UserControl
    {
        private IAccountLogic _accountLogic;
        private Form1 _form;

        public Login(Form1 form, IAccountLogic accountLogic)
        {
            _form = form;
            _accountLogic= accountLogic;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Account anAccount;
            if (textBoxUsernameEmail.Text != "")
            {
                if (textBoxPassword.Text != "")
                {
                    try
                    {
                        if (textBoxUsernameEmail.Text.Contains("@"))
                        {
                            anAccount = _accountLogic.SearchAccountByEmail(textBoxUsernameEmail.Text.Trim());
                        }
                        else
                        {
                            anAccount = _accountLogic.SearchAccountByUsername(textBoxUsernameEmail.Text.Trim());
                        }
                       
                        if (anAccount.Password == textBoxPassword.Text)
                        {
                            MessageBox.Show("Logged confirmed");
                            _accountLogic.SetCurrentAccount(anAccount);
                            _form.changeToLobby();
                        }
                        else
                        {
                            MessageBox.Show("Not the correct password for this user");
                        }
                        
                    }
                    catch (AccountLogicException err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    catch (AccountRepoException err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a password");
                }
            }
            else
            {
                MessageBox.Show("Please enter a username or email");
            }

        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            _form.changeToRegister();
        }
    }
}
