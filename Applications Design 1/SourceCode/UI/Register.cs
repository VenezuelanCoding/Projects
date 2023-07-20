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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    public partial class Register : UserControl
    {
        private IAccountLogic _accountLogic;
        private Form1 _form;
        public Register(Form1 form, IAccountLogic accountLogic)
        {
            _form = form;
            _accountLogic = accountLogic;
            InitializeComponent();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
         
                if (textBoxPassword.Text == textBoxConfirmPassword.Text)
                {
                    try
                    {
                        Account account = new Account()
                        {
                            Email = textBoxEmail.Text.Trim(),
                            UserName = textBoxUsername.Text.Trim(),
                            Password = textBoxPassword.Text.Trim()
                        };
                        _accountLogic.AddNewAccount(account);

                        _form.changeToLogin();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }


            }
                else
                {
                    MessageBox.Show("Password and Confirm Password don't coincide");
                }
            }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToLogin();
        }
    }
}
