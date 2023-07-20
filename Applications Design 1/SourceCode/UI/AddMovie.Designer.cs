namespace UI
{
    partial class AddMovie
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxPoster = new System.Windows.Forms.PictureBox();
            this.buttonPoster = new System.Windows.Forms.Button();
            this.textBoxMovieDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMovieName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPrimaryGenre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxPG = new System.Windows.Forms.CheckBox();
            this.checkBoxSponsored = new System.Windows.Forms.CheckBox();
            this.dateTimePickerReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddMovie = new System.Windows.Forms.Button();
            this.listBoxSubGenres1 = new System.Windows.Forms.ListBox();
            this.listBoxSubGenres2 = new System.Windows.Forms.ListBox();
            this.buttonAddGenre = new System.Windows.Forms.Button();
            this.buttonRemoveGenre = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxRelatedMovies1 = new System.Windows.Forms.ListBox();
            this.listBoxRelatedMovies2 = new System.Windows.Forms.ListBox();
            this.buttonRemoveRelatedMovie = new System.Windows.Forms.Button();
            this.buttonAddRelatedMovie = new System.Windows.Forms.Button();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPoster
            // 
            this.pictureBoxPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPoster.Location = new System.Drawing.Point(290, 313);
            this.pictureBoxPoster.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPoster.Name = "pictureBoxPoster";
            this.pictureBoxPoster.Size = new System.Drawing.Size(199, 246);
            this.pictureBoxPoster.TabIndex = 17;
            this.pictureBoxPoster.TabStop = false;
            // 
            // buttonPoster
            // 
            this.buttonPoster.Location = new System.Drawing.Point(312, 571);
            this.buttonPoster.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPoster.Name = "buttonPoster";
            this.buttonPoster.Size = new System.Drawing.Size(140, 27);
            this.buttonPoster.TabIndex = 3;
            this.buttonPoster.Text = "Select Poster";
            this.buttonPoster.UseVisualStyleBackColor = true;
            this.buttonPoster.Click += new System.EventHandler(this.buttonPoster_Click);
            // 
            // textBoxMovieDescription
            // 
            this.textBoxMovieDescription.Location = new System.Drawing.Point(260, 208);
            this.textBoxMovieDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieDescription.Multiline = true;
            this.textBoxMovieDescription.Name = "textBoxMovieDescription";
            this.textBoxMovieDescription.Size = new System.Drawing.Size(249, 85);
            this.textBoxMovieDescription.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 203);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Description";
            // 
            // textBoxMovieName
            // 
            this.textBoxMovieName.Location = new System.Drawing.Point(258, 162);
            this.textBoxMovieName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieName.Name = "textBoxMovieName";
            this.textBoxMovieName.Size = new System.Drawing.Size(253, 22);
            this.textBoxMovieName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name";
            // 
            // comboBoxPrimaryGenre
            // 
            this.comboBoxPrimaryGenre.FormattingEnabled = true;
            this.comboBoxPrimaryGenre.Location = new System.Drawing.Point(268, 612);
            this.comboBoxPrimaryGenre.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPrimaryGenre.Name = "comboBoxPrimaryGenre";
            this.comboBoxPrimaryGenre.Size = new System.Drawing.Size(220, 24);
            this.comboBoxPrimaryGenre.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 615);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Primary Genre";
            // 
            // checkBoxPG
            // 
            this.checkBoxPG.AutoSize = true;
            this.checkBoxPG.Location = new System.Drawing.Point(268, 671);
            this.checkBoxPG.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPG.Name = "checkBoxPG";
            this.checkBoxPG.Size = new System.Drawing.Size(68, 20);
            this.checkBoxPG.TabIndex = 5;
            this.checkBoxPG.Text = "Is PG?";
            this.checkBoxPG.UseVisualStyleBackColor = true;
            // 
            // checkBoxSponsored
            // 
            this.checkBoxSponsored.AutoSize = true;
            this.checkBoxSponsored.Location = new System.Drawing.Point(268, 714);
            this.checkBoxSponsored.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSponsored.Name = "checkBoxSponsored";
            this.checkBoxSponsored.Size = new System.Drawing.Size(116, 20);
            this.checkBoxSponsored.TabIndex = 6;
            this.checkBoxSponsored.Text = "Is Sponsored?";
            this.checkBoxSponsored.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerReleaseDate
            // 
            this.dateTimePickerReleaseDate.Location = new System.Drawing.Point(268, 764);
            this.dateTimePickerReleaseDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerReleaseDate.Name = "dateTimePickerReleaseDate";
            this.dateTimePickerReleaseDate.Size = new System.Drawing.Size(255, 22);
            this.dateTimePickerReleaseDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 772);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Release Date";
            // 
            // buttonAddMovie
            // 
            this.buttonAddMovie.Location = new System.Drawing.Point(459, 828);
            this.buttonAddMovie.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddMovie.Name = "buttonAddMovie";
            this.buttonAddMovie.Size = new System.Drawing.Size(91, 30);
            this.buttonAddMovie.TabIndex = 16;
            this.buttonAddMovie.Text = "AddMovie";
            this.buttonAddMovie.UseVisualStyleBackColor = true;
            this.buttonAddMovie.Click += new System.EventHandler(this.buttonAddMovie_Click);
            // 
            // listBoxSubGenres1
            // 
            this.listBoxSubGenres1.FormattingEnabled = true;
            this.listBoxSubGenres1.ItemHeight = 16;
            this.listBoxSubGenres1.Location = new System.Drawing.Point(658, 208);
            this.listBoxSubGenres1.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxSubGenres1.Name = "listBoxSubGenres1";
            this.listBoxSubGenres1.Size = new System.Drawing.Size(209, 164);
            this.listBoxSubGenres1.TabIndex = 9;
            // 
            // listBoxSubGenres2
            // 
            this.listBoxSubGenres2.FormattingEnabled = true;
            this.listBoxSubGenres2.ItemHeight = 16;
            this.listBoxSubGenres2.Location = new System.Drawing.Point(902, 208);
            this.listBoxSubGenres2.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxSubGenres2.Name = "listBoxSubGenres2";
            this.listBoxSubGenres2.Size = new System.Drawing.Size(209, 164);
            this.listBoxSubGenres2.TabIndex = 27;
            // 
            // buttonAddGenre
            // 
            this.buttonAddGenre.Location = new System.Drawing.Point(732, 406);
            this.buttonAddGenre.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddGenre.Name = "buttonAddGenre";
            this.buttonAddGenre.Size = new System.Drawing.Size(137, 26);
            this.buttonAddGenre.TabIndex = 10;
            this.buttonAddGenre.Text = "Add Genre";
            this.buttonAddGenre.UseVisualStyleBackColor = true;
            this.buttonAddGenre.Click += new System.EventHandler(this.buttonAddGenre_Click);
            // 
            // buttonRemoveGenre
            // 
            this.buttonRemoveGenre.Location = new System.Drawing.Point(902, 406);
            this.buttonRemoveGenre.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveGenre.Name = "buttonRemoveGenre";
            this.buttonRemoveGenre.Size = new System.Drawing.Size(137, 26);
            this.buttonRemoveGenre.TabIndex = 11;
            this.buttonRemoveGenre.Text = "Remove Genre";
            this.buttonRemoveGenre.UseVisualStyleBackColor = true;
            this.buttonRemoveGenre.Click += new System.EventHandler(this.buttonRemoveGenre_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(761, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 39);
            this.label7.TabIndex = 30;
            this.label7.Text = "Sub-Genres";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(745, 479);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 39);
            this.label8.TabIndex = 31;
            this.label8.Text = "Related Movies";
            // 
            // listBoxRelatedMovies1
            // 
            this.listBoxRelatedMovies1.FormattingEnabled = true;
            this.listBoxRelatedMovies1.ItemHeight = 16;
            this.listBoxRelatedMovies1.Location = new System.Drawing.Point(665, 534);
            this.listBoxRelatedMovies1.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxRelatedMovies1.Name = "listBoxRelatedMovies1";
            this.listBoxRelatedMovies1.Size = new System.Drawing.Size(209, 164);
            this.listBoxRelatedMovies1.TabIndex = 12;
            // 
            // listBoxRelatedMovies2
            // 
            this.listBoxRelatedMovies2.FormattingEnabled = true;
            this.listBoxRelatedMovies2.ItemHeight = 16;
            this.listBoxRelatedMovies2.Location = new System.Drawing.Point(909, 532);
            this.listBoxRelatedMovies2.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxRelatedMovies2.Name = "listBoxRelatedMovies2";
            this.listBoxRelatedMovies2.Size = new System.Drawing.Size(209, 164);
            this.listBoxRelatedMovies2.TabIndex = 14;
            // 
            // buttonRemoveRelatedMovie
            // 
            this.buttonRemoveRelatedMovie.Location = new System.Drawing.Point(909, 714);
            this.buttonRemoveRelatedMovie.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveRelatedMovie.Name = "buttonRemoveRelatedMovie";
            this.buttonRemoveRelatedMovie.Size = new System.Drawing.Size(204, 26);
            this.buttonRemoveRelatedMovie.TabIndex = 15;
            this.buttonRemoveRelatedMovie.Text = "Remove Related Movie";
            this.buttonRemoveRelatedMovie.UseVisualStyleBackColor = true;
            this.buttonRemoveRelatedMovie.Click += new System.EventHandler(this.buttonRemoveRelatedMovie_Click);
            // 
            // buttonAddRelatedMovie
            // 
            this.buttonAddRelatedMovie.Location = new System.Drawing.Point(665, 714);
            this.buttonAddRelatedMovie.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddRelatedMovie.Name = "buttonAddRelatedMovie";
            this.buttonAddRelatedMovie.Size = new System.Drawing.Size(211, 26);
            this.buttonAddRelatedMovie.TabIndex = 13;
            this.buttonAddRelatedMovie.Text = "Add Related Movie";
            this.buttonAddRelatedMovie.UseVisualStyleBackColor = true;
            this.buttonAddRelatedMovie.Click += new System.EventHandler(this.buttonAddRelatedMovie_Click);
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(77, 39);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 37;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(440, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 58);
            this.label1.TabIndex = 11;
            this.label1.Text = "Add Movie";
            // 
            // AddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.buttonRemoveRelatedMovie);
            this.Controls.Add(this.buttonAddRelatedMovie);
            this.Controls.Add(this.listBoxRelatedMovies2);
            this.Controls.Add(this.listBoxRelatedMovies1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonRemoveGenre);
            this.Controls.Add(this.buttonAddGenre);
            this.Controls.Add(this.listBoxSubGenres2);
            this.Controls.Add(this.listBoxSubGenres1);
            this.Controls.Add(this.buttonAddMovie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerReleaseDate);
            this.Controls.Add(this.checkBoxSponsored);
            this.Controls.Add(this.checkBoxPG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxPrimaryGenre);
            this.Controls.Add(this.pictureBoxPoster);
            this.Controls.Add(this.buttonPoster);
            this.Controls.Add(this.textBoxMovieDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMovieName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddMovie";
            this.Size = new System.Drawing.Size(1365, 945);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPoster;
        private System.Windows.Forms.Button buttonPoster;
        private System.Windows.Forms.TextBox textBoxMovieDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMovieName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPrimaryGenre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxPG;
        private System.Windows.Forms.CheckBox checkBoxSponsored;
        private System.Windows.Forms.DateTimePicker dateTimePickerReleaseDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddMovie;
        private System.Windows.Forms.ListBox listBoxSubGenres1;
        private System.Windows.Forms.ListBox listBoxSubGenres2;
        private System.Windows.Forms.Button buttonAddGenre;
        private System.Windows.Forms.Button buttonRemoveGenre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBoxRelatedMovies1;
        private System.Windows.Forms.ListBox listBoxRelatedMovies2;
        private System.Windows.Forms.Button buttonRemoveRelatedMovie;
        private System.Windows.Forms.Button buttonAddRelatedMovie;
        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Label label1;
    }
}
