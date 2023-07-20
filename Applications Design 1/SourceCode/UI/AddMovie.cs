using Domain;

using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class AddMovie : UserControl
    {
        private IGenreLogic _genreLogic;
        private IMovieLogic _movieLogic;
        private Form1 _form;
        private IAccountLogic _accountLogic;
        private string posterPath;

        public AddMovie(Form1 form, IGenreLogic genreLogic,IMovieLogic movieLogic, IAccountLogic accountLogic)
        {
            _form = form;
            _accountLogic = accountLogic;
            _genreLogic = genreLogic;
            _movieLogic = movieLogic;
            InitializeComponent();
            populateFieldsBoxes();
            comboBoxPrimaryGenre.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void populateFieldsBoxes()
        {
            if (_genreLogic.GetAllGenres().Count != 0)
            {
                comboBoxPrimaryGenre.DataSource = _genreLogic.GetAllGenres().ToArray();


                Genre[] arrayGenre =  _genreLogic.GetAllGenres().ToArray();

                foreach (Genre genre in arrayGenre)
                {
                    listBoxSubGenres1.Items.Add(genre);
                }

            }

            if (_movieLogic.GetAllMovies().Count != 0)
            {
                Movie[] arrayMovies = _movieLogic.GetAllMovies().ToArray();

                foreach (Movie movie in arrayMovies)
                {
                    listBoxRelatedMovies1.Items.Add(movie);
                }
            }

            listBoxRelatedMovies2.Items.Clear();
            listBoxSubGenres2.Items.Clear();
        }

        private void buttonPoster_Click(object sender, EventArgs e)
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
            if (posterPath != null)
            {
                posterPath = null;
            }


            if (filePath != "")
            {
                IList<String> nameArray = filePath.Split('\\');
                String name = nameArray.Last();
                try
                {
                    File.Copy(filePath, @"./Images/" + name);
                    pictureBoxPoster.Image = _form.ResizeImage(Image.FromFile(@"./Images/" + name), 150, 200);
                    posterPath = @"./Images/" + name;
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("An image with that name is already being use in a movie or member");
                }
            }
        }

       

        private void buttonAddGenre_Click(object sender, EventArgs e)
        {
            if (listBoxSubGenres1.SelectedItem != null)
            {
                Genre selectedGenre = (Genre)listBoxSubGenres1.SelectedItem;
                listBoxSubGenres2.Items.Add(selectedGenre);
                listBoxSubGenres1.Items.Remove(selectedGenre);
            }
        }

        private void buttonRemoveGenre_Click(object sender, EventArgs e)
        {
            if (listBoxSubGenres2.SelectedItem != null)
            {
                Genre selectedGenre = (Genre)listBoxSubGenres2.SelectedItem;
                listBoxSubGenres1.Items.Add(selectedGenre);
                listBoxSubGenres2.Items.Remove(selectedGenre);
            }
        }

        private void buttonAddRelatedMovie_Click(object sender, EventArgs e)
        {
            if (listBoxRelatedMovies1.SelectedItem != null)
            {
                Movie selectedMovie = (Movie)listBoxRelatedMovies1.SelectedItem;
                listBoxRelatedMovies2.Items.Add(selectedMovie);
                listBoxRelatedMovies1.Items.Remove(selectedMovie);
            }
        }

        private void buttonRemoveRelatedMovie_Click(object sender, EventArgs e)
        {
            if (listBoxRelatedMovies2.SelectedItem != null)
            {
                Movie selectedMovie = (Movie)listBoxRelatedMovies2.SelectedItem;
                listBoxRelatedMovies1.Items.Add(selectedMovie);
                listBoxRelatedMovies2.Items.Remove(selectedMovie);
            }
        }

        private void buttonAddMovie_Click(object sender, EventArgs e)
        {

            if (textBoxMovieName.Text.Trim() != "" )
            {
                if(textBoxMovieDescription.Text.Trim() != "")
                {
                    if (pictureBoxPoster.Image != null)
                    {

                        bool verified = true;
                        List<Genre> subgenresForNewMovie = SubGenresSelectedItems();
                        Genre possiblePrimaryGenre = _genreLogic.SearchGenre(comboBoxPrimaryGenre.Text);

                        if (subgenresForNewMovie.Contains(possiblePrimaryGenre))
                        {
                            verified = false;
                            MessageBox.Show("Can't add a subgenre that is the primary genre of a movie");
                        }
                          

                            if (verified)
                            {
                                try
                                {

                                Movie movie = new Movie()
                                    {
                                        Name = textBoxMovieName.Text,
                                        Description = textBoxMovieDescription.Text,
                                        IsPG = checkBoxPG.Checked,
                                        IsSponsored = checkBoxSponsored.Checked,
                                        Poster = posterPath,
                                        PrimaryGenre = possiblePrimaryGenre,
                                        ReleaseDate = dateTimePickerReleaseDate.Value,
                                    };
                          

                                    List<Movie> RelatedMovies = (List<Movie>)RelatedMoviesSelectedItems();
                                    foreach (Movie aMovie in RelatedMovies)
                                    {
                                        _movieLogic.AddMovieToRelatedMovies(aMovie, movie, _accountLogic.GetCurrentAccount());

                                    }

                                    foreach (Genre aGenre in subgenresForNewMovie)
                                    {
                                         _movieLogic.AddGenreToSubgenres(aGenre,movie);

                                    }

                                    _movieLogic.AddNewMovie(movie, _accountLogic.GetCurrentAccount());
                                    MessageBox.Show("Movie Added Correctly");
                                    CleanScreen();
                                }
                                catch (MovieException err)
                                {
                                    MessageBox.Show(err.Message);
                                }
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show("Please select a poster for the movie");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter a valid description for the movie");
                }

            }
            else
            {
                MessageBox.Show("Please enter a valid name for the movie (can't be the same as other movie)");
            }
        }



        private List<Movie> RelatedMoviesSelectedItems()
        {
            List<Movie> results = listBoxRelatedMovies2.Items.Cast<Movie>().ToList();
            return results;
        }

        private List<Genre> SubGenresSelectedItems()
        {
            List<Genre> results = listBoxSubGenres2.Items.Cast<Genre>().ToList();
            return results;
        }

        public void CleanScreen()
        {
            textBoxMovieName.Text = "";
            textBoxMovieDescription.Text = "";
            pictureBoxPoster.Image = null;
            posterPath = "";
            listBoxRelatedMovies1.Items.Clear();
            listBoxSubGenres1.Items.Clear();
            populateFieldsBoxes();
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToMovieSettings();
        }

        private void buttonRemoveMovie_Click_1(object sender, EventArgs e)
        {
            _form.changeToRemoveMovie();
        }

        private void buttonAddDirector_Click(object sender, EventArgs e)
        {
            _form.changeToDirectorSettings();
        }

        string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }


    }
}


    

