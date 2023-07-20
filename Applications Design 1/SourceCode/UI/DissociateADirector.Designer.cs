namespace UI
{
    partial class DissociateADirector
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
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonDissociateDirectors = new System.Windows.Forms.Button();
            this.listBoxMovies = new System.Windows.Forms.ListBox();
            this.listBoxDirectors = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoadDirectors = new System.Windows.Forms.Button();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(782, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 32);
            this.label3.TabIndex = 51;
            this.label3.Text = "Directors";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(414, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 32);
            this.label7.TabIndex = 50;
            this.label7.Text = "Movies";
            // 
            // buttonDissociateDirectors
            // 
            this.buttonDissociateDirectors.Location = new System.Drawing.Point(543, 597);
            this.buttonDissociateDirectors.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDissociateDirectors.Name = "buttonDissociateDirectors";
            this.buttonDissociateDirectors.Size = new System.Drawing.Size(200, 58);
            this.buttonDissociateDirectors.TabIndex = 49;
            this.buttonDissociateDirectors.Text = "Dissociate Director/s from Movie";
            this.buttonDissociateDirectors.UseVisualStyleBackColor = true;
            this.buttonDissociateDirectors.Click += new System.EventHandler(this.buttonAddDirectors_Click);
            // 
            // listBoxMovies
            // 
            this.listBoxMovies.FormattingEnabled = true;
            this.listBoxMovies.ItemHeight = 16;
            this.listBoxMovies.Location = new System.Drawing.Point(358, 223);
            this.listBoxMovies.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovies.Name = "listBoxMovies";
            this.listBoxMovies.Size = new System.Drawing.Size(247, 228);
            this.listBoxMovies.TabIndex = 48;
            // 
            // listBoxDirectors
            // 
            this.listBoxDirectors.FormattingEnabled = true;
            this.listBoxDirectors.ItemHeight = 16;
            this.listBoxDirectors.Location = new System.Drawing.Point(730, 223);
            this.listBoxDirectors.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxDirectors.Name = "listBoxDirectors";
            this.listBoxDirectors.Size = new System.Drawing.Size(247, 228);
            this.listBoxDirectors.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(706, 58);
            this.label1.TabIndex = 52;
            this.label1.Text = "Dissociate Director from Movie";
            // 
            // buttonLoadDirectors
            // 
            this.buttonLoadDirectors.Location = new System.Drawing.Point(382, 459);
            this.buttonLoadDirectors.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadDirectors.Name = "buttonLoadDirectors";
            this.buttonLoadDirectors.Size = new System.Drawing.Size(200, 58);
            this.buttonLoadDirectors.TabIndex = 53;
            this.buttonLoadDirectors.Text = "Load Director/s";
            this.buttonLoadDirectors.UseVisualStyleBackColor = true;
            this.buttonLoadDirectors.Click += new System.EventHandler(this.buttonLoadDirectors_Click);
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(90, 59);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 54;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // DissociateADirector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.buttonLoadDirectors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonDissociateDirectors);
            this.Controls.Add(this.listBoxMovies);
            this.Controls.Add(this.listBoxDirectors);
            this.Name = "DissociateADirector";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonDissociateDirectors;
        private System.Windows.Forms.ListBox listBoxMovies;
        private System.Windows.Forms.ListBox listBoxDirectors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadDirectors;
        private System.Windows.Forms.LinkLabel linkLabelBack;
    }
}
