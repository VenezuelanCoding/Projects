namespace UI
{
    partial class AdminPanel
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
            this.buttonMovieSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenreSettings = new System.Windows.Forms.Button();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.buttonSorting = new System.Windows.Forms.Button();
            this.buttonExporter = new System.Windows.Forms.Button();
            this.buttonMemberSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMovieSettings
            // 
            this.buttonMovieSettings.Location = new System.Drawing.Point(347, 340);
            this.buttonMovieSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMovieSettings.Name = "buttonMovieSettings";
            this.buttonMovieSettings.Size = new System.Drawing.Size(163, 75);
            this.buttonMovieSettings.TabIndex = 0;
            this.buttonMovieSettings.Text = "Movie Settings";
            this.buttonMovieSettings.UseVisualStyleBackColor = true;
            this.buttonMovieSettings.Click += new System.EventHandler(this.buttonMovieSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 58);
            this.label1.TabIndex = 12;
            this.label1.Text = "Admin Panel";
            // 
            // buttonGenreSettings
            // 
            this.buttonGenreSettings.Location = new System.Drawing.Point(564, 340);
            this.buttonGenreSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGenreSettings.Name = "buttonGenreSettings";
            this.buttonGenreSettings.Size = new System.Drawing.Size(163, 75);
            this.buttonGenreSettings.TabIndex = 13;
            this.buttonGenreSettings.Text = "Genre Settings";
            this.buttonGenreSettings.UseVisualStyleBackColor = true;
            this.buttonGenreSettings.Click += new System.EventHandler(this.buttonGenreSettings_Click);
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(83, 70);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 14;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // buttonSorting
            // 
            this.buttonSorting.Location = new System.Drawing.Point(764, 340);
            this.buttonSorting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSorting.Name = "buttonSorting";
            this.buttonSorting.Size = new System.Drawing.Size(163, 75);
            this.buttonSorting.TabIndex = 15;
            this.buttonSorting.Text = "Sorting Algorithm";
            this.buttonSorting.UseVisualStyleBackColor = true;
            this.buttonSorting.Click += new System.EventHandler(this.buttonSorting_Click);
            // 
            // buttonExporter
            // 
            this.buttonExporter.Location = new System.Drawing.Point(564, 447);
            this.buttonExporter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExporter.Name = "buttonExporter";
            this.buttonExporter.Size = new System.Drawing.Size(163, 75);
            this.buttonExporter.TabIndex = 16;
            this.buttonExporter.Text = "Export Movies Info";
            this.buttonExporter.UseVisualStyleBackColor = true;
            this.buttonExporter.Click += new System.EventHandler(this.buttonExporter_Click);
            // 
            // buttonMemberSettings
            // 
            this.buttonMemberSettings.Location = new System.Drawing.Point(347, 447);
            this.buttonMemberSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMemberSettings.Name = "buttonMemberSettings";
            this.buttonMemberSettings.Size = new System.Drawing.Size(163, 75);
            this.buttonMemberSettings.TabIndex = 17;
            this.buttonMemberSettings.Text = "Member Settings";
            this.buttonMemberSettings.UseVisualStyleBackColor = true;
            this.buttonMemberSettings.Click += new System.EventHandler(this.buttonMemberSettings_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(764, 447);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 75);
            this.button1.TabIndex = 18;
            this.button1.Text = "Acting Role Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonMemberSettings);
            this.Controls.Add(this.buttonExporter);
            this.Controls.Add(this.buttonSorting);
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.buttonGenreSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMovieSettings);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminPanel";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMovieSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenreSettings;
        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Button buttonSorting;
        private System.Windows.Forms.Button buttonExporter;
        private System.Windows.Forms.Button buttonMemberSettings;
        private System.Windows.Forms.Button button1;
    }
}
