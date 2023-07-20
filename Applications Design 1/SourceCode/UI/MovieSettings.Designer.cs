namespace UI
{
    partial class MovieSettings
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
            this.buttonDirectorSettings = new System.Windows.Forms.Button();
            this.buttonRemoveMovie = new System.Windows.Forms.Button();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddMovie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDirectorSettings
            // 
            this.buttonDirectorSettings.Location = new System.Drawing.Point(370, 260);
            this.buttonDirectorSettings.Name = "buttonDirectorSettings";
            this.buttonDirectorSettings.Size = new System.Drawing.Size(184, 52);
            this.buttonDirectorSettings.TabIndex = 43;
            this.buttonDirectorSettings.Text = "Director/s Settings";
            this.buttonDirectorSettings.UseVisualStyleBackColor = true;
            this.buttonDirectorSettings.Click += new System.EventHandler(this.buttonDirectorSettings_Click);
            // 
            // buttonRemoveMovie
            // 
            this.buttonRemoveMovie.Location = new System.Drawing.Point(750, 260);
            this.buttonRemoveMovie.Name = "buttonRemoveMovie";
            this.buttonRemoveMovie.Size = new System.Drawing.Size(184, 52);
            this.buttonRemoveMovie.TabIndex = 42;
            this.buttonRemoveMovie.Text = "Remove Movie";
            this.buttonRemoveMovie.UseVisualStyleBackColor = true;
            this.buttonRemoveMovie.Click += new System.EventHandler(this.buttonRemoveMovie_Click);
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(127, 62);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 41;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(490, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 58);
            this.label1.TabIndex = 40;
            this.label1.Text = "Movie Settings";
            // 
            // buttonAddMovie
            // 
            this.buttonAddMovie.Location = new System.Drawing.Point(560, 260);
            this.buttonAddMovie.Name = "buttonAddMovie";
            this.buttonAddMovie.Size = new System.Drawing.Size(184, 52);
            this.buttonAddMovie.TabIndex = 44;
            this.buttonAddMovie.Text = "Add Movie";
            this.buttonAddMovie.UseVisualStyleBackColor = true;
            this.buttonAddMovie.Click += new System.EventHandler(this.buttonAddMovie_Click);
            // 
            // MovieSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddMovie);
            this.Controls.Add(this.buttonDirectorSettings);
            this.Controls.Add(this.buttonRemoveMovie);
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.label1);
            this.Name = "MovieSettings";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDirectorSettings;
        private System.Windows.Forms.Button buttonRemoveMovie;
        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddMovie;
    }
}
