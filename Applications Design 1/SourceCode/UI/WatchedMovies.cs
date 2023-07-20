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
    public partial class WatchedMovies : UserControl
    {
        private IMovieLogic _movieLogic;
        private Form1 _form;
        private FlowLayoutPanel flowLayoutPanel1;
        private IAccountLogic _accountLogic;

        public WatchedMovies
            (Form1 form, IMovieLogic movieLogic, FlowLayoutPanel flowLayoutPanel1, IAccountLogic accountLogic)
        {
            _form = form;
            _movieLogic = movieLogic;
            _accountLogic = accountLogic;
            this.flowLayoutPanel1 = flowLayoutPanel1;
            InitializeComponent();

            PopulateList();
        }

        public void PopulateList()
        {


            Profile currentProfile = _accountLogic.GetCurrentProfile();
            IList<Movie> movies = currentProfile.WatchedMovies;

            // movies.ToArray().Reverse();

            for (int i = 0; i < movies.Count; i++)
            {

                Panel moviePanel = new Panel();
                moviePanel.Name = "panel" + (flowLayoutPanel1.Controls.Count + 1);
                moviePanel.Size = new Size(170, 360);

                var posterImage = new PictureBox();
                posterImage.Image = _form.ResizeImage(Image.FromFile(movies[i].Poster), 170, 200);
                posterImage.Size = new Size(posterImage.Image.Width, posterImage.Image.Height);


                var labelName = new Label();
                labelName.AutoSize = true;
                labelName.Location = new Point(0, 210);
                labelName.Font = new Font(labelName.Font, FontStyle.Bold);
                labelName.Text = movies[i].Name;

                int quantityOfDirectorsInMovie = movies[i].Directors.Count;
                String textDirector="";
                if (quantityOfDirectorsInMovie != 0)
                {
                    textDirector = "Director/s:\n";
                }
                else
                {
                    textDirector = "Director/s:";
                }

                for (int j = 0; j < 2 && quantityOfDirectorsInMovie > j; j++)
                {
                    textDirector += movies[i].Directors[j].Name + ", ";
                    if (textDirector.Length > 15)
                    {
                        textDirector += "\n";
                    }

                }
                if (quantityOfDirectorsInMovie != 0)
                {
                    textDirector = textDirector.Substring(0, textDirector.Length - 3);
                }

                var labelDirectors = new Label();
                labelDirectors.AutoSize = true;
                labelDirectors.Location = new Point(0, 230);
                labelDirectors.Font = new Font(labelName.Font, FontStyle.Bold);
                labelDirectors.Text=textDirector;

                String textActors = "Actor/s:\n";


                for (int j = 0; j < 4 && movies[i].ActingRoles.Count > j; j++)
                {
                    textActors += movies[i].ActingRoles[j].Member.Name + ", ";
                    if (textActors.Length > 15)
                    {
                        textActors += "\n";
                    }

                }

                textActors = textActors.Substring(0, textActors.Length - 3);

                var labelActors = new Label();
                labelActors.AutoSize = true;
                labelActors.Location = new Point(0, 280);
                labelActors.Font = new Font(labelName.Font, FontStyle.Bold);
                labelActors.Text = textActors;

                var movieID = movies[i].Id;
                posterImage.MouseClick += new MouseEventHandler((o, a) => _form.changeToMovie(_movieLogic.GetMovieById(movieID)));

                moviePanel.Controls.Add(labelActors);
                moviePanel.Controls.Add(labelDirectors);
                moviePanel.Controls.Add(posterImage);
                moviePanel.Controls.Add(labelName);
                flowLayoutWatchedMovies.Controls.Add(moviePanel);
            }


        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToCatalog();
        }
    }
}
