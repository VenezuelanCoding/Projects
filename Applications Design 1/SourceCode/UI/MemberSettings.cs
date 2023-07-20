using Data;
using Domain;
using Logic.Implementations;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MemberSettings : UserControl
    {
        private Form1 _form;

        public MemberSettings(Form1 form)
        {
            _form = form;
            InitializeComponent();
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToAdmin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _form.changeToAddAMember();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _form.changeToModifyMember();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _form.changeToRemoveAMember();
        }
    }
}
