using Data;
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
    public partial class AddAMember : UserControl
    {
        private Form1 _form;
        private IMemberLogic _memberLogic;
        private IAccountLogic _accountLogic;
        private string profileImagePath;

        public AddAMember(Form1 form, IMemberLogic memberLogic, IAccountLogic accountLogic)
        {
            _memberLogic = memberLogic;
            _form = form;
            _accountLogic = accountLogic;
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonProfilePicture_Click(object sender, EventArgs e)
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
                    pictureBoxProfilePicture.Image = _form.ResizeImage(Image.FromFile(@"./Images/" + name), 150, 200);
                    profileImagePath = @"./Images/" + name;
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("An image with that name is already being use in a movie or member");
                }
            }
        }

        public void CleanUp()
        {
            textBoxName.Text = "";
            pictureBoxProfilePicture.Image = null;
            profileImagePath = "";
        }

        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() != "")
            {
                if (pictureBoxProfilePicture.Image != null)
                {
                    try
                    {
                        MemberType aType;
                        if (!MemberType.TryParse(comboBoxType.Text, out aType))
                        {
                            comboBoxType.SelectedIndex = 0;
                            MessageBox.Show("Please use a correct member type");
                        }
                        else
                        {

                            Member aMember = new Member()
                            {
                                Name = textBoxName.Text,
                                BirthDate = dateTimePickerBirthDate.Value,
                                ProfilePicture = profileImagePath,
                                Type = aType
                            };
                            try
                            {
                                _memberLogic.AddNewMember(aMember, _accountLogic.GetCurrentAccount());
                                MessageBox.Show("Member added correctly");
                                CleanUp();
                            }
                            catch (MemberRepoException err)
                            {
                                MessageBox.Show(err.Message);
                            }
                        }

                    }
                    catch (MemberException err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a profile image for the member");
                }
            }
            else
            {
                MessageBox.Show("Please enter a name for the member");
            }
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToMemberSettings();
        }
    }
}
