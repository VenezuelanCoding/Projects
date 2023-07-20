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
    public partial class MovieSettings : UserControl
    {
        private Form1 _form;

        public MovieSettings(Form1 form)
        {
            _form = form;
            InitializeComponent();
        }

        private void buttonAddMovie_Click(object sender, EventArgs e)
        {
            _form.changeToAddMovie();
        }

        private void buttonRemoveMovie_Click(object sender, EventArgs e)
        {
            _form.changeToRemoveMovie();
        }

        private void buttonDirectorSettings_Click(object sender, EventArgs e)
        {
            _form.changeToDirectorSettings();
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToAdmin();
        }
    }
}
