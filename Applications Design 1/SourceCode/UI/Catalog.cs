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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class Catalog : UserControl
    {
        private IMovieLogic _movieLogic;
        private Form1 _form;
        private FlowLayoutPanel flowLayoutPanel1;
        private IAccountLogic _accountLogic;

        public Catalog(Form1 form, IMovieLogic movieLogic, FlowLayoutPanel flowLayoutPanel1,IAccountLogic accountLogic )
        {
            _form = form;
            _movieLogic = movieLogic;
            _accountLogic = accountLogic;
            this.flowLayoutPanel1 = flowLayoutPanel1;
            InitializeComponent();
            comboBoxSearch.Text = "By Actor";
            comboBoxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            IList<Movie> movies = _form.SortContext.Sort(_movieLogic.GetAllMovies());
            PopulateList(movies);
        }

    


        public void PopulateList(IList<Movie> movies)
        {
            labelCurrentSorter.Text = "Sorting: ";
            flowLayoutPanelCatalog.Controls.Clear();

            var currentSortingName = _form.SortContext.ToString();
            var lastDot = currentSortingName.LastIndexOf('.');
            labelCurrentSorter.Text += " "+currentSortingName.Substring(lastDot+1);

            if (_accountLogic.GetCurrentProfile().IsChildren)
            {
                movies = _movieLogic.GetAllPGMovies();
            }

            for (int i = 0; i < movies.Count; i++)
            {

                Panel moviePanel = new Panel();
                moviePanel.Name = "panel" + movies[i].Id;
                moviePanel.Size = new Size(170, 250);

                var posterImage = new PictureBox();
                posterImage.Image = _form.ResizeImage(Image.FromFile(movies[i].Poster), 170, 200);
                posterImage.Size = new Size(posterImage.Image.Width, posterImage.Image.Height);

                var labelName = new Label();
                labelName.AutoSize = true;
                labelName.Location = new Point(0, 210);
                labelName.Font = new Font(labelName.Font, FontStyle.Bold);
                labelName.Text = movies[i].Name;

                var movieID = movies[i].Id;
                posterImage.MouseClick += new MouseEventHandler((o, a) => _form.changeToMovie(_movieLogic.GetMovieById(movieID)));


                moviePanel.Controls.Add(posterImage);
                moviePanel.Controls.Add(labelName);
                flowLayoutPanelCatalog.Controls.Add(moviePanel);
            }

        }


        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToLobby();
        }

        private void buttonWatchedMovies_Click(object sender, EventArgs e)
        {
            _form.changeToWatchedMovies();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Trim() != "")
            {
              
                _form.SearchContext.SetStrategy(comboBoxSearch.Text);
                
                IList<Movie> searchedMovies = _form.SearchContext.Search(_movieLogic.GetAllMovies(), textBoxSearch.Text.ToLower().Trim());

                IList<Movie> sortedMovies = _form.SortContext.Sort(searchedMovies);

                PopulateList(sortedMovies);

            }
            else
            {
                MessageBox.Show("Write a valid search");
            }
        }

        private void buttonCleanSearch_Click(object sender, EventArgs e)
        {
            IList<Movie> movies = _form.SortContext.Sort(_movieLogic.GetAllMovies());
            PopulateList(movies);
            textBoxSearch.Text = "";
        }
    }
}
