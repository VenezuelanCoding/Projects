using System.Windows.Forms;
using LogicInterfaces;
using DataInterfaces;
using Data.InDatabase;
using Logic.Implementations;
using Domain;
using System.Collections.Generic;
using System.Drawing;
using System;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using UnitTest;
using System.Windows.Forms.VisualStyles;

namespace UI
{
    public partial class Form1 : Form
    {
        private IAccountLogic _accountLogic;
        private IMovieLogic _movieLogic;
        private IGenreLogic _genreLogic;
        public SortContext SortContext;
        public SearchContext SearchContext;
        public IMemberLogic _memberLogic;

        public Form1()
        {
    
            SortContext = new SortContext();
            SearchContext = new SearchContext();


            IAccountRepository accountRepository = new AccountDBRepository();
            _accountLogic = new AccountLogic(accountRepository);

            IMovieRepository movieRepository = new MovieDBRepository();
            _movieLogic = new MovieLogic(movieRepository);

            IGenreRepository genreRepository = new GenreDBRepository();
            _genreLogic = new GenreLogic(genreRepository);

            IMemberRepository memberRepository = new MemberDBRepository();
            _memberLogic = new MemberLogic(memberRepository);

            SortContext.SetStrategy("By Name", _genreLogic, _accountLogic);



            InitializeComponent();
            flowLayoutPanel.Controls.Clear();
            UserControl Login = new Login(this, _accountLogic);
            flowLayoutPanel.Controls.Add(Login);
        }

        public void LobbyToMovies(Profile profile)
        {
            if (!profile.IsChildren)
            {
                string input = Interaction.InputBox("Enter profile pin", "Pin");
                if (input != "")
                {
                    if (profile.Pin == input)
                    {
                        _accountLogic.SetCurrentProfile(profile);
                        changeToCatalog();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect PIN");
                    }

                }
                
            }
            else
            {
                _accountLogic.SetCurrentProfile(profile);
                changeToCatalog();
            }
        }
        public void changeToRemoveAMember()
        {
            flowLayoutPanel.Controls.Clear();
            RemoveAMember RemoveAMember = new RemoveAMember(this, _memberLogic, _accountLogic);
            flowLayoutPanel.Controls.Add(RemoveAMember);
        }

        public void changeToModifyMember()
        {
            flowLayoutPanel.Controls.Clear();
            ModifyAMember ModifyAMember = new ModifyAMember(this, _memberLogic, _accountLogic);
            flowLayoutPanel.Controls.Add(ModifyAMember);
        }

        public void changeToAddAMember()
        {
            flowLayoutPanel.Controls.Clear();
            AddAMember AddAMember = new AddAMember(this, _memberLogic, _accountLogic);
            flowLayoutPanel.Controls.Add(AddAMember);
        }

        public void changeToDissociateDirector()
        {
            flowLayoutPanel.Controls.Clear();
            DissociateADirector DissociateADirector = new DissociateADirector(this, _movieLogic, _accountLogic, _memberLogic);
            flowLayoutPanel.Controls.Add(DissociateADirector);
        }

        public void changeToAddDirectorToAMovie()
        {
            flowLayoutPanel.Controls.Clear();
            AddDirectorToMovie AddDirectorToMovie = new AddDirectorToMovie(this, _movieLogic, _accountLogic, _memberLogic);
            flowLayoutPanel.Controls.Add(AddDirectorToMovie);
        }

        public void changeToDirectorSettings()
        {
            flowLayoutPanel.Controls.Clear();
            DirectorSettings DirectorSettings = new DirectorSettings(this);
            flowLayoutPanel.Controls.Add(DirectorSettings);
        }

        public void changeToRemoveMovie()
        {
            flowLayoutPanel.Controls.Clear();
            RemoveMovie RemoveMovie = new RemoveMovie(this, _movieLogic, _accountLogic);
            flowLayoutPanel.Controls.Add(RemoveMovie);
        }

        public void changeToDissociateActingRole()
        {
            flowLayoutPanel.Controls.Clear();
            DissociateAnActingRole DissociateAnActingRole = new DissociateAnActingRole(this, _movieLogic, _accountLogic,_memberLogic);
            flowLayoutPanel.Controls.Add(DissociateAnActingRole);
        }

        public void changeToAddActingRole()
        {
            flowLayoutPanel.Controls.Clear();
            AddActingRole AddActingRole = new AddActingRole(this, _memberLogic, _movieLogic, _accountLogic);
            flowLayoutPanel.Controls.Add(AddActingRole);
        }

        public void changeToActingRoleSettings()
        {
            flowLayoutPanel.Controls.Clear();
            ActingRoleSettings ActinRole = new ActingRoleSettings(this);
            flowLayoutPanel.Controls.Add(ActinRole);
        }

        public void changeToMemberSettings()
        {
            flowLayoutPanel.Controls.Clear();
            MemberSettings MemberSettings = new MemberSettings(this);
            flowLayoutPanel.Controls.Add(MemberSettings);
        }

        public void changeToWatchedMovies()
        {
            flowLayoutPanel.Controls.Clear();
            WatchedMovies WatchedMovies = new WatchedMovies(this, _movieLogic, flowLayoutPanel, _accountLogic);
            flowLayoutPanel.Controls.Add(WatchedMovies);
        }

        public void changeToMovie(Movie movie)
        {
            flowLayoutPanel.Controls.Clear();
            UserControl ShowMovie = new ShowMovie(this, _accountLogic,_movieLogic,movie,_genreLogic);
            flowLayoutPanel.Controls.Add(ShowMovie);
        }

        public void changeToSorting()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl Sorting = new Sorting(this, _accountLogic,_genreLogic);
            flowLayoutPanel.Controls.Add(Sorting);
        }

        public void changeToCatalog()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl Catalog = new Catalog(this, _movieLogic, flowLayoutPanel,_accountLogic);
            flowLayoutPanel.Controls.Add(Catalog);
        }

        public void changeToGenreSettings()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl GenreSettings = new GenreSettings(this, _genreLogic, _movieLogic, _accountLogic);
            flowLayoutPanel.Controls.Add(GenreSettings);
        }


        public void changeToAddMovie()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl MovieSettings = new AddMovie(this, _genreLogic, _movieLogic, _accountLogic);
            flowLayoutPanel.Controls.Add(MovieSettings);
        }

        public void changeToMovieSettings()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl MovieSettings2 = new MovieSettings(this);
            flowLayoutPanel.Controls.Add(MovieSettings2);
        }

        public void changeToAdmin()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl AdminPanel = new AdminPanel(this, _movieLogic, _accountLogic);
            flowLayoutPanel.Controls.Add(AdminPanel);
        }


        public void changeToRegister()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl Register = new Register(this, _accountLogic);
            flowLayoutPanel.Controls.Add(Register);
        }

        public void changeToLogin()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl Login = new Login(this, _accountLogic);
            flowLayoutPanel.Controls.Add(Login);
        }

        public void changeToAddProfile()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl Profile_Creation = new Profile_Creation(this, _accountLogic);
            flowLayoutPanel.Controls.Add(Profile_Creation);
        }

        public void changeToLobby()
        {
            flowLayoutPanel.Controls.Clear();
            UserControl Lobby = new Lobby(this, _accountLogic, flowLayoutPanel);
            flowLayoutPanel.Controls.Add(Lobby);
        }


        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

    }
}



