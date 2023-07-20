using Data;
using Domain;
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
    public partial class RemoveAMember : UserControl
    {
        private IMemberLogic _memberLogic;
        private Form1 _form;
        private IAccountLogic _accountLogic;

        public RemoveAMember(Form1 form, IMemberLogic memberLogic, IAccountLogic accountLogic)
        {
            _form = form;
            _accountLogic = accountLogic;
            _memberLogic = memberLogic;
            InitializeComponent();
            PopulateFieldsBoxes();
        }

        private void PopulateFieldsBoxes()
        {
            if (_memberLogic.GetAllMembers().Count != 0)
            {
                Member[] arrayMembers = _memberLogic.GetAllMembers().ToArray();

                foreach (Member member in arrayMembers)
                {
                    listBoxRemoveMember.Items.Add(member);
                }
            }
        }

        private void buttonRemoveMember_Click(object sender, EventArgs e)
        {
            if (listBoxRemoveMember.SelectedItem != null)
            {
                Member member = (Member)listBoxRemoveMember.SelectedItem;
                try
                {
                    _memberLogic.DeleteMember(member.Id, _accountLogic.GetCurrentAccount());
                    MessageBox.Show("Member deleted correctly");
                }
                catch (MemberRepoException err)
                {
                    MessageBox.Show(err.Message);
                }
                CleanScreen();
                PopulateFieldsBoxes();
            }
        }

        private void CleanScreen()
        {
            listBoxRemoveMember.Items.Clear();
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToMemberSettings();
        }
    }
}
