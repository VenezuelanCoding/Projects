namespace UI
{
    partial class DirectorSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.buttonAddDirectorToMovie = new System.Windows.Forms.Button();
            this.buttonDissociateDirector = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 58);
            this.label1.TabIndex = 31;
            this.label1.Text = "Directors Settings";
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(132, 75);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 38;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // buttonAddDirectorToMovie
            // 
            this.buttonAddDirectorToMovie.Location = new System.Drawing.Point(455, 316);
            this.buttonAddDirectorToMovie.Name = "buttonAddDirectorToMovie";
            this.buttonAddDirectorToMovie.Size = new System.Drawing.Size(189, 79);
            this.buttonAddDirectorToMovie.TabIndex = 39;
            this.buttonAddDirectorToMovie.Text = "Add Director to Movie";
            this.buttonAddDirectorToMovie.UseVisualStyleBackColor = true;
            this.buttonAddDirectorToMovie.Click += new System.EventHandler(this.buttonAddDirectorToMovie_Click);
            // 
            // buttonDissociateDirector
            // 
            this.buttonDissociateDirector.Location = new System.Drawing.Point(650, 316);
            this.buttonDissociateDirector.Name = "buttonDissociateDirector";
            this.buttonDissociateDirector.Size = new System.Drawing.Size(189, 79);
            this.buttonDissociateDirector.TabIndex = 40;
            this.buttonDissociateDirector.Text = "Dissociate a Director from a Movie";
            this.buttonDissociateDirector.UseVisualStyleBackColor = true;
            this.buttonDissociateDirector.Click += new System.EventHandler(this.buttonDissociateDirector_Click);
            // 
            // DirectorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDissociateDirector);
            this.Controls.Add(this.buttonAddDirectorToMovie);
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.label1);
            this.Name = "DirectorSettings";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Button buttonAddDirectorToMovie;
        private System.Windows.Forms.Button buttonDissociateDirector;
    }
}
