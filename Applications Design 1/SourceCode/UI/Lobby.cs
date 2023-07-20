using Domain;
using LogicInterfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace UI
{
    public partial class Lobby : UserControl
    {
        private IAccountLogic _accountLogic;
        private Form1 _form;
        private FlowLayoutPanel flowLayoutPanel1;

        public Lobby(Form1 form, IAccountLogic accountLogic, FlowLayoutPanel flowLayoutPanel1)
        {
            _form = form;
            _accountLogic = accountLogic;
            this.flowLayoutPanel1 = flowLayoutPanel1;

            UpdateLobbyScreen();
            InitializeComponent();
        }

        private void DeleteProfile(Profile profile)
        {

            string input = Interaction.InputBox("Enter password of this account", "Delete Profile");
            if (input != "")
            {
                if (_accountLogic.GetCurrentAccount().Password == input)
                {
                    _accountLogic.RemoveProfile(profile, _accountLogic.GetCurrentAccount());

                    MessageBox.Show("Profile deleted sucesfully");
                    UpdateLobbyScreen();
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                }

            }

        }




        private void UpdateLobbyScreen()
        {
            _accountLogic.SetCurrentAccount(_accountLogic.SearchAccountByEmail(_accountLogic.GetCurrentAccount().Email));
            int profileQuantity = _accountLogic.GetCurrentAccount().Profiles.Count;
            if (profileQuantity == 0)
            {
                _form.changeToAddProfile();
            }
            else
            {
                this.flowLayoutPanel1.Controls.Clear();

                Account currentAccount = _accountLogic.GetCurrentAccount();

                LinkLabel CloseSesion = new LinkLabel();
                CloseSesion.Text = "Logout";
                CloseSesion.Location = new Point(100, 200);
                CloseSesion.MouseClick += new MouseEventHandler((o, a) => { _accountLogic.SetCurrentAccount(null); _form.changeToLogin(); });
                this.flowLayoutPanel1.Controls.Add(CloseSesion);

                bool isAdmin = _accountLogic.GetCurrentAccount().isAdmin;

                if (isAdmin)
                {
                    Button Settings = new Button();
                    Settings.Text = "Admin Settings";
                    Settings.Location = new Point(300, 200);
                    Settings.MouseClick += new MouseEventHandler((o, a) => { _form.changeToAdmin(); });
                    this.flowLayoutPanel1.Controls.Add(Settings);
                }


                renderProfiles(currentAccount,profileQuantity);

            }
        }


        private void renderProfiles(Account currentAccount, int profileQuantity)
        { 
            List<Profile> profiles = currentAccount.Profiles;

            bool addPlusButton = true;
            int x = 0;
            int y = 250;
            switch (profileQuantity)
            {
                case 1:
                    x = 320;
                    break;
                case 2:
                    x = 220;
                    break;
                case 3:
                    x = 80;
                    break;
                case 4:
                    x = 50;
                    addPlusButton = false;
                    break;
                default:
                    break;
            }



            int delta = 25;
            Panel panel = new Panel();
            Size sizePanel = new Size(1024, 768);
            panel.Size = sizePanel;
            this.flowLayoutPanel1.Controls.Add(panel);


            for (int i = 0; i < profiles.Count; i++)
            {

                var pictureProfile = new PictureBox();
                pictureProfile.Image = Image.FromFile("./Images/lobbyUser.png");
                pictureProfile.Location = new Point(x, y);
                pictureProfile.Size = new Size(pictureProfile.Image.Width, pictureProfile.Image.Height);


                int dy = pictureProfile.Height + delta;

                var labelName = new Label();
                labelName.Name = "labelName" + profiles[i].Id;
                labelName.AutoSize = true;
                labelName.Location = new Point(x, y + dy);
                labelName.Font = new Font(labelName.Font, FontStyle.Bold);
                labelName.Text = profiles[i].Alias;

                var profileID = profiles[i].Id;


                if (i != 0)
                {
                    var labelIsChildren = new Label();
                    labelIsChildren.AutoSize = true;
                    labelIsChildren.Location = new Point(x, y + dy + 15);
                    labelIsChildren.Font = new Font(labelName.Font, FontStyle.Bold);
                    labelIsChildren.Text = "Is Children?: ";

                    var checkBoxChildren = new CheckBox();
                    checkBoxChildren.AutoSize = true;
                    checkBoxChildren.Location = new Point(x + 75, y + dy + 15);
                    if (profiles[i].IsChildren)
                    {
                        checkBoxChildren.Checked = true;
                    }


                    checkBoxChildren.MouseClick += new MouseEventHandler((o, a) => {
                        MakeChildren(_accountLogic.SearchProfile(profileID), checkBoxChildren.Checked);
                        UpdateLobbyScreen();
                    });


                    var deleteProfile = new PictureBox();
                    deleteProfile.Image = Image.FromFile("./Images/lobbyClose.png");
                    deleteProfile.Location = new Point(x + 30, y - 35);
                    deleteProfile.Size = new Size(deleteProfile.Image.Width, deleteProfile.Image.Height);
                    deleteProfile.MouseClick += new MouseEventHandler((o, a) => DeleteProfile(_accountLogic.SearchProfile(profileID)));

                    panel.Controls.Add(checkBoxChildren);
                    panel.Controls.Add(labelIsChildren);
                    panel.Controls.Add(deleteProfile);
                }
                if (addPlusButton && i + 1 == profiles.Count)
                {
                    var picturePlus = new PictureBox();
                    picturePlus.Image = Image.FromFile("./Images/lobbyPlus.png");
                    picturePlus.Location = new Point(x + 250, y);
                    picturePlus.Size = new Size(picturePlus.Image.Width, picturePlus.Image.Height);

                    var labelPlus = new Label();
                    labelPlus.AutoSize = true;
                    labelPlus.Location = new Point(x + 250, y + dy);
                    labelPlus.Font = new Font(labelPlus.Font, FontStyle.Bold);
                    labelPlus.Text = "Add a User";
                    picturePlus.MouseClick += new MouseEventHandler((o, a) => _form.changeToAddProfile());

                   
                    panel.Controls.Add(picturePlus);
                    panel.Controls.Add(labelPlus);
                }

                pictureProfile.MouseClick += new MouseEventHandler((o, a) => _form.LobbyToMovies(_accountLogic.SearchProfile(profileID)));

                
                panel.Controls.Add(pictureProfile);
                panel.Controls.Add(labelName);

                int dx1 = labelName.Width + labelName.Width + pictureProfile.Width;
                int dx2 = pictureProfile.Width;
                x += Math.Max(dx1, dx2) + delta;
            }

        }

        private void MakeChildren(Profile profile, bool check)
        {
            string input = Interaction.InputBox("Enter password of this account", "Change to children");
            if (input.Trim() != "")
            {
                if (_accountLogic.GetCurrentAccount().Password == input)
                {

                    if (check)
                    {
                        _accountLogic.ChangeChildren(profile, true);
                        MessageBox.Show("Profile is now a child");

                    }
                    else
                    {
                        _accountLogic.ChangeChildren(profile, false);
                        MessageBox.Show("Profile is not longer a child");

                    }
                }
                else
                {
                    MessageBox.Show("Incorrect password");  
                }
            }
        }

    }
}
