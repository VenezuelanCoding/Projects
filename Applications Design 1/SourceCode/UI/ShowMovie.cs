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
    public partial class ShowMovie : UserControl
    {
        private IGenreLogic _genreLogic;
        private IMovieLogic _movieLogic;
        private IAccountLogic _accountLogic;
        private Form1 _form;
        Profile currentProfile;

        Movie _movie;

        public ShowMovie(Form1 form, IAccountLogic accountLogic, IMovieLogic movieLogic, Movie movie, IGenreLogic genreLogic)
        {
            _form = form;
            _movieLogic = movieLogic;
            _movie = movie;
            _accountLogic = accountLogic;
            _genreLogic = genreLogic;
            currentProfile = _accountLogic.GetCurrentProfile();

            InitializeComponent();
            PopulatePanel();
        }


        private void PopulatePanel()
        {

            populateMovie();
            checkPressedButtons();
            fillRelatedMovies();

        }


        private void populateMovie()
        {
            pictureBoxPoster.Image = _form.ResizeImage(Image.FromFile(_movie.Poster), 341, 400);
            labelMovieName.Text = _movie.Name;
            labelDescription.Text += "\n" + _movie.Description;
            labelPrimaryGenre.Text += "\n" + _movie.PrimaryGenre.ToString();
        }


        private void fillRelatedMovies()
        {
            IList<Movie> movies = _movie.RelatedMovies;


            if (_accountLogic.GetCurrentProfile().IsChildren)
            {
                movies = _movie.GetRelatedPGMovies();
            }


            for (int i = 0; i < movies.Count; i++)
            {

                Panel moviePanel = new Panel();
                moviePanel.Name = "panel" + (flowLayoutPanelRelatedMovies.Controls.Count + 1);
                moviePanel.Size = new Size(150, 250);

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
                flowLayoutPanelRelatedMovies.Controls.Add(moviePanel);

            }
        }

        private void checkPressedButtons()
        {
            if (currentProfile.IsAWatchedMovie(_movie))
            {
                buttonWatched.Enabled = false;
            }

            if (currentProfile.IsALikedMovie(_movie))
            {
                changeButtonStyle(buttonPlusOne);
                buttonMinusOne.Enabled = false;
                buttonPlusPlusOne.Enabled = false;
            }

            if (currentProfile.IsADislikedMovie(_movie))
            {
                changeButtonStyle(buttonMinusOne);
                buttonPlusOne.Enabled = false;
                buttonPlusPlusOne.Enabled = false;
            }

            if (currentProfile.IsASuperlikedMovie(_movie))
            {
                changeButtonStyle(buttonPlusPlusOne);
                buttonMinusOne.Enabled = false;
                buttonPlusOne.Enabled = false;
            }


        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToCatalog();
        }

        private void buttonWatched_Click(object sender, EventArgs e)
        {
            _accountLogic.AddToWatchedMovies(_movie, currentProfile);
            Score genreScore=_accountLogic.SearchScore(_movie.PrimaryGenre.Id,currentProfile.Id);
            if (genreScore != null)
            {
                _accountLogic.AddPointsToScore(genreScore.Id, currentProfile, 1);
            }
            else
            {
                Genre likedGenre = _genreLogic.SearchGenre(_movie.PrimaryGenre.Name);
                Score score = new Score(likedGenre);
                _accountLogic.AddScoreToProfile(currentProfile.Id, score);
                _accountLogic.AddPointsToScore(score.Id, currentProfile, 1);
            }
            buttonWatched.Enabled = false;
            currentProfile = _accountLogic.GetCurrentProfile();
        }

        private void buttonMinusOne_Click(object sender, EventArgs e)
        {

            if (buttonMinusOne.FlatStyle==FlatStyle.Popup)
            {
                _accountLogic.AddToDislikedMovies(_movie.Id, currentProfile.Id);
                changeButtonStyle(buttonMinusOne);

                Score genreScore = _accountLogic.SearchScore(_movie.PrimaryGenre.Id,currentProfile.Id);
                if (genreScore != null)
                {
                    _accountLogic.AddPointsToScore(genreScore.Id, currentProfile, -1);
                }
                else
                {
                    Genre likedGenre = _genreLogic.SearchGenre(_movie.PrimaryGenre.Name);
                    Score score = new Score(likedGenre);
                    _accountLogic.AddScoreToProfile(currentProfile.Id, score);
                    _accountLogic.AddPointsToScore(score.Id, currentProfile, -1);
                }

                buttonPlusOne.Enabled = false;
                buttonPlusPlusOne.Enabled = false;
                currentProfile = _accountLogic.GetCurrentProfile();

            }
            else
            {
                changeButtonStyle(buttonMinusOne);

                _accountLogic.RemoveOfDislikedMovies(_movie.Id, currentProfile.Id);

                Score genreScore = _accountLogic.SearchScore(_movie.PrimaryGenre.Id, currentProfile.Id);
                if (genreScore != null)
                {
                    _accountLogic.AddPointsToScore(genreScore.Id, currentProfile, 1);
                }
                else
                {
                    Score score = new Score(_movie.PrimaryGenre);
                    _accountLogic.AddScoreToProfile(currentProfile.Id, score);
                    _accountLogic.AddPointsToScore(score.Id, currentProfile, 1);
                }

                buttonPlusOne.Enabled = true;
                buttonPlusPlusOne.Enabled = true;
                currentProfile = _accountLogic.GetCurrentProfile();

            }
        }


        private void changeButtonStyle(Button buttonToChange)
        {
            if(buttonToChange.FlatStyle == FlatStyle.Flat)
            {
                buttonToChange.FlatStyle=FlatStyle.Popup;
            }
            else
            {
                buttonToChange.FlatStyle = FlatStyle.Flat;
            }
        }

        private void buttonPlusOne_Click(object sender, EventArgs e)
        {

            if (buttonPlusOne.FlatStyle == FlatStyle.Popup)
            {
                _accountLogic.AddToLikedMovies(_movie.Id, currentProfile.Id);

                changeButtonStyle(buttonPlusOne);

                Score genreScore = _accountLogic.SearchScore(_movie.PrimaryGenre.Id, currentProfile.Id);
                if (genreScore != null)
                {
                    _accountLogic.AddPointsToScore(genreScore.Id, currentProfile, 1);
                }
                else
                {
                    Genre likedGenre=_genreLogic.SearchGenre(_movie.PrimaryGenre.Name);
                    Score score = new Score(likedGenre);
                    _accountLogic.AddScoreToProfile(currentProfile.Id, score);
                    _accountLogic.AddPointsToScore(score.Id, currentProfile, 1);
                }

                buttonMinusOne.Enabled = false;
                buttonPlusPlusOne.Enabled = false;
                currentProfile = _accountLogic.GetCurrentProfile();

            }
            else
            {
                changeButtonStyle(buttonPlusOne);

                _accountLogic.RemoveOfLikedMovies(_movie.Id, currentProfile.Id);


                Score genreScore = _accountLogic.SearchScore(_movie.PrimaryGenre.Id, currentProfile.Id);
                if (genreScore != null)
                {
                    _accountLogic.AddPointsToScore(genreScore.Id, currentProfile, -1);
                }
                else
                {
                    Score score = new Score(_movie.PrimaryGenre);
                    _accountLogic.AddScoreToProfile(currentProfile.Id, score);
                    _accountLogic.AddPointsToScore(score.Id, currentProfile, -1);
                }

                buttonMinusOne.Enabled = true;
                buttonPlusPlusOne.Enabled = true;
                currentProfile = _accountLogic.GetCurrentProfile();

            }
        }

        private void buttonPlusPlusOne_Click(object sender, EventArgs e)
        {

            List<Genre> subGenreToLike = _movieLogic.GetMovieById(_movie.Id).SubGenres;

            if (buttonPlusPlusOne.FlatStyle == FlatStyle.Popup)
            {
                _accountLogic.AddToSuperLikedMovies(_movie.Id, currentProfile.Id);

                changeButtonStyle(buttonPlusPlusOne);

                Score genreScore = _accountLogic.SearchScore(_movie.PrimaryGenre.Id, currentProfile.Id);
                if (genreScore != null)
                {
                    _accountLogic.AddPointsToScore(genreScore.Id, currentProfile, 2);
                }
                else
                {
                    Score score = new Score(_movie.PrimaryGenre);
                    _accountLogic.AddScoreToProfile(currentProfile.Id, score);
                    _accountLogic.AddPointsToScore(score.Id, currentProfile, 2);
                }

                foreach (Genre aGenre in subGenreToLike)
                {

                    Score subGenreScoreDB = _accountLogic.SearchScore(aGenre.Id,currentProfile.Id);
                    if (subGenreScoreDB != null)
                    {
                        _accountLogic.AddPointsToScore(subGenreScoreDB.Id, currentProfile, 1);
                    }
                    else
                    {
                        Score subGenreScore = new Score(aGenre);
                        _accountLogic.AddScoreToProfile(currentProfile.Id, subGenreScore);
                        _accountLogic.AddPointsToScore(subGenreScore.Id, currentProfile, 1);
                    }
                }

                buttonMinusOne.Enabled = false;
                buttonPlusOne.Enabled = false;
                currentProfile = _accountLogic.GetCurrentProfile();

            }
            else
            {
                changeButtonStyle(buttonPlusPlusOne);

                _accountLogic.RemoveOfSuperLikedMovies(_movie.Id, currentProfile.Id);

                Score genreScore = _accountLogic.SearchScore(_movie.PrimaryGenre.Id, currentProfile.Id);
                if (genreScore != null)
                {
                    _accountLogic.AddPointsToScore(genreScore.Id, currentProfile, -2);
                }
                else
                {
                    Score score = new Score(_movie.PrimaryGenre);
                    _accountLogic.AddScoreToProfile(currentProfile.Id, score);
                    _accountLogic.AddPointsToScore(score.Id, currentProfile, -2);
                }

                foreach (Genre aGenre in subGenreToLike)
                {

                    Score subGenreScoreDB = _accountLogic.SearchScore(aGenre.Id, currentProfile.Id);
                    if (subGenreScoreDB != null)
                    {
                        _accountLogic.AddPointsToScore(subGenreScoreDB.Id, currentProfile, -1);
                    }
                    else
                    {
                        Score subGenreScore = new Score(aGenre);
                        _accountLogic.AddScoreToProfile(currentProfile.Id, subGenreScore);
                        _accountLogic.AddPointsToScore(subGenreScore.Id, currentProfile, -1);
                    }
                }

                buttonMinusOne.Enabled = true;
                buttonPlusOne.Enabled = true;
                currentProfile = _accountLogic.GetCurrentProfile();

            }
        }
    }
}
