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
    public partial class DirectorSettings : UserControl
    {
        private Form1 _form;

        public DirectorSettings(Form1 form)
        {
            _form = form;
            InitializeComponent();
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToMovieSettings();
        }

        private void buttonAddDirectorToMovie_Click(object sender, EventArgs e)
        {
            _form.changeToAddDirectorToAMovie();
        }

        private void buttonDissociateDirector_Click(object sender, EventArgs e)
        {
            _form.changeToDissociateDirector();
        }
    }
}
