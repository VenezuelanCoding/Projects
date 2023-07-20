using Domain;
using Logic.Implementations;
using LogicInterfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class AdminPanel : UserControl
    {
        private IMovieLogic _movieLogic;
        private IAccountLogic _accountLogic;
        private Form1 _form;

        public AdminPanel(Form1 form, IMovieLogic movieLogic, IAccountLogic accountLogic)
        {
            _form = form;
            _accountLogic = accountLogic;
            _movieLogic = movieLogic;
            InitializeComponent();
        }

        private void buttonMovieSettings_Click(object sender, EventArgs e)
        {
            _form.changeToMovieSettings();
        }

        private void buttonGenreSettings_Click(object sender, EventArgs e)
        {
            _form.changeToGenreSettings();
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToLobby();
        }

        private void buttonSorting_Click(object sender, EventArgs e)
        {
            _form.changeToSorting();
        }

        private void buttonExporter_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Enter the name of the file", "Exporter");
            if (input != "")
            {
                IExporter exporter = new ExporterToText(/*_accountLogic.GetCurrentAccount()*/);
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                exporter.Export(_movieLogic, desktopPath + "/"+input+".txt", _accountLogic.GetCurrentAccount());
                MessageBox.Show("Movies has been exported to your desktop sucesfully!");
            }
        }

        private void buttonMemberSettings_Click(object sender, EventArgs e)
        {
            _form.changeToMemberSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _form.changeToActingRoleSettings();
        }
    }
}