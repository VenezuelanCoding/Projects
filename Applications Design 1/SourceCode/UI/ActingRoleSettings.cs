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
    public partial class ActingRoleSettings : UserControl
    {
        private Form1 _form;

        public ActingRoleSettings(Form1 form)
        {
            _form = form;
            InitializeComponent();
        }

  
        private void buttonAddActingRole_Click(object sender, EventArgs e)
        {
            _form.changeToAddActingRole();
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToAdmin();
        }

        private void buttonDissociateActingRole_Click(object sender, EventArgs e)
        {
            _form.changeToDissociateActingRole();
        }
    }
}
