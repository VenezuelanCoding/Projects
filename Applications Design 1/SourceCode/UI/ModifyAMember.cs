using Domain;
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
    public partial class ModifyAMember : UserControl
    {
        private Form1 _form;
        private IMemberLogic _memberLogic;
        private IAccountLogic _accountLogic;
        private string profileImagePath;

        public ModifyAMember(Form1 form, IMemberLogic memberLogic, IAccountLogic accountLogic)
        {
            _memberLogic = memberLogic;
            _form = form;
            _accountLogic = accountLogic;
            InitializeComponent();
            populateFieldsBoxes();
        }

        private void buttonLoadPoster_Click(object sender, EventArgs e)
        {
            if (listBoxMembers.SelectedItem != null)
            {
                Member selectedMember = (Member)listBoxMembers.SelectedItem;
                pictureBoxNewProfilePicture.Image = _form.ResizeImage(Image.FromFile(selectedMember.ProfilePicture), 150, 200);
            }
            else
            {
                MessageBox.Show("Select a member first");
            }
        }

        private void buttoNewProfilePicture_Click(object sender, EventArgs e)
        {
            if (listBoxMembers.SelectedItem != null)
            {
                string fileContent;
                string filePath = "";

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        filePath = openFileDialog.FileName;

                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                    }
                }
                if (profileImagePath != null)
                {
                    profileImagePath = null;
                }


                if (filePath != "")
                {
                    IList<String> nameArray = filePath.Split('\\');
                    String name = nameArray.Last();
                    try
                    {
                        File.Copy(filePath, @"./Images/" + name);
                        pictureBoxNewProfilePicture.Image = _form.ResizeImage(Image.FromFile(@"./Images/" + name), 150, 200);
                        profileImagePath = @"./Images/" + name;
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("An image with that name is already being use in a movie or member");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a member first");
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (pictureBoxNewProfilePicture.Image != null && profileImagePath != null)
            {
                Member selectedMember = (Member)listBoxMembers.SelectedItem;
                Account currentAccount = _accountLogic.GetCurrentAccount();
                _memberLogic.ModifyMemberProfileImage(selectedMember.Id, profileImagePath, currentAccount);
                pictureBoxNewProfilePicture.Image = null;
                profileImagePath = null;
                listBoxMembers.Items.Clear();
                populateFieldsBoxes();
                MessageBox.Show("Member modified correctly");
            }
        }

        private void populateFieldsBoxes()
        {
            if (_memberLogic.GetAllMembers().Count != 0)
            {
                Member[] arrayMembers = _memberLogic.GetAllMembers().ToArray();

                foreach (Member member in arrayMembers)
                {
                    listBoxMembers.Items.Add(member);
                }

            }
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToMemberSettings();
        }
    }
}
