namespace UI
{
    partial class ShowMovie
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
            this.labelMovieName = new System.Windows.Forms.Label();
            this.pictureBoxPoster = new System.Windows.Forms.PictureBox();
            this.labelPrimaryGenre = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonMinusOne = new System.Windows.Forms.Button();
            this.buttonPlusOne = new System.Windows.Forms.Button();
            this.buttonPlusPlusOne = new System.Windows.Forms.Button();
            this.buttonWatched = new System.Windows.Forms.Button();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.labelRelatedMovies = new System.Windows.Forms.Label();
            this.flowLayoutPanelRelatedMovies = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMovieName
            // 
            this.labelMovieName.AutoSize = true;
            this.labelMovieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovieName.Location = new System.Drawing.Point(779, 50);
            this.labelMovieName.Name = "labelMovieName";
            this.labelMovieName.Size = new System.Drawing.Size(159, 58);
            this.labelMovieName.TabIndex = 12;
            this.labelMovieName.Text = "Name";
            // 
            // pictureBoxPoster
            // 
            this.pictureBoxPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPoster.Location = new System.Drawing.Point(180, 50);
            this.pictureBoxPoster.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPoster.Name = "pictureBoxPoster";
            this.pictureBoxPoster.Size = new System.Drawing.Size(454, 492);
            this.pictureBoxPoster.TabIndex = 13;
            this.pictureBoxPoster.TabStop = false;
            // 
            // labelPrimaryGenre
            // 
            this.labelPrimaryGenre.AutoSize = true;
            this.labelPrimaryGenre.Location = new System.Drawing.Point(716, 106);
            this.labelPrimaryGenre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrimaryGenre.Name = "labelPrimaryGenre";
            this.labelPrimaryGenre.Size = new System.Drawing.Size(47, 16);
            this.labelPrimaryGenre.TabIndex = 15;
            this.labelPrimaryGenre.Text = "Genre:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(716, 150);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.MaximumSize = new System.Drawing.Size(563, 279);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(78, 16);
            this.labelDescription.TabIndex = 16;
            this.labelDescription.Text = "Description:";
            // 
            // buttonMinusOne
            // 
            this.buttonMinusOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMinusOne.Location = new System.Drawing.Point(839, 508);
            this.buttonMinusOne.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMinusOne.Name = "buttonMinusOne";
            this.buttonMinusOne.Size = new System.Drawing.Size(91, 33);
            this.buttonMinusOne.TabIndex = 17;
            this.buttonMinusOne.Text = "-1";
            this.buttonMinusOne.UseVisualStyleBackColor = true;
            this.buttonMinusOne.Click += new System.EventHandler(this.buttonMinusOne_Click);
            // 
            // buttonPlusOne
            // 
            this.buttonPlusOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPlusOne.Location = new System.Drawing.Point(952, 508);
            this.buttonPlusOne.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlusOne.Name = "buttonPlusOne";
            this.buttonPlusOne.Size = new System.Drawing.Size(91, 33);
            this.buttonPlusOne.TabIndex = 18;
            this.buttonPlusOne.Text = "+1";
            this.buttonPlusOne.UseVisualStyleBackColor = true;
            this.buttonPlusOne.Click += new System.EventHandler(this.buttonPlusOne_Click);
            // 
            // buttonPlusPlusOne
            // 
            this.buttonPlusPlusOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPlusPlusOne.Location = new System.Drawing.Point(1065, 508);
            this.buttonPlusPlusOne.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlusPlusOne.Name = "buttonPlusPlusOne";
            this.buttonPlusPlusOne.Size = new System.Drawing.Size(91, 33);
            this.buttonPlusPlusOne.TabIndex = 19;
            this.buttonPlusPlusOne.Text = "++1";
            this.buttonPlusPlusOne.UseVisualStyleBackColor = true;
            this.buttonPlusPlusOne.Click += new System.EventHandler(this.buttonPlusPlusOne_Click);
            // 
            // buttonWatched
            // 
            this.buttonWatched.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonWatched.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonWatched.Location = new System.Drawing.Point(885, 452);
            this.buttonWatched.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWatched.Name = "buttonWatched";
            this.buttonWatched.Size = new System.Drawing.Size(204, 33);
            this.buttonWatched.TabIndex = 20;
            this.buttonWatched.Text = "Watched";
            this.buttonWatched.UseVisualStyleBackColor = true;
            this.buttonWatched.Click += new System.EventHandler(this.buttonWatched_Click);
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(56, 12);
            this.linkLabelBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 21;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // labelRelatedMovies
            // 
            this.labelRelatedMovies.AutoSize = true;
            this.labelRelatedMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRelatedMovies.Location = new System.Drawing.Point(49, 564);
            this.labelRelatedMovies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRelatedMovies.Name = "labelRelatedMovies";
            this.labelRelatedMovies.Size = new System.Drawing.Size(234, 36);
            this.labelRelatedMovies.TabIndex = 23;
            this.labelRelatedMovies.Text = "RelatedMovies:";
            // 
            // flowLayoutPanelRelatedMovies
            // 
            this.flowLayoutPanelRelatedMovies.AutoScroll = true;
            this.flowLayoutPanelRelatedMovies.Location = new System.Drawing.Point(49, 599);
            this.flowLayoutPanelRelatedMovies.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelRelatedMovies.Name = "flowLayoutPanelRelatedMovies";
            this.flowLayoutPanelRelatedMovies.Size = new System.Drawing.Size(1275, 346);
            this.flowLayoutPanelRelatedMovies.TabIndex = 24;
            this.flowLayoutPanelRelatedMovies.WrapContents = false;
            // 
            // ShowMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelRelatedMovies);
            this.Controls.Add(this.labelRelatedMovies);
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.buttonWatched);
            this.Controls.Add(this.buttonPlusPlusOne);
            this.Controls.Add(this.buttonPlusOne);
            this.Controls.Add(this.buttonMinusOne);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelPrimaryGenre);
            this.Controls.Add(this.pictureBoxPoster);
            this.Controls.Add(this.labelMovieName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShowMovie";
            this.Size = new System.Drawing.Size(1365, 945);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMovieName;
        private System.Windows.Forms.PictureBox pictureBoxPoster;
        private System.Windows.Forms.Label labelPrimaryGenre;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonMinusOne;
        private System.Windows.Forms.Button buttonPlusOne;
        private System.Windows.Forms.Button buttonPlusPlusOne;
        private System.Windows.Forms.Button buttonWatched;
        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Label labelRelatedMovies;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRelatedMovies;
    }
}
