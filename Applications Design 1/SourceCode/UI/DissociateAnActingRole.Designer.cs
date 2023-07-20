namespace UI
{
    partial class DissociateAnActingRole
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
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.buttonLoadActors = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAddDirectors = new System.Windows.Forms.Button();
            this.listBoxMovies = new System.Windows.Forms.ListBox();
            this.listBoxActors = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(134, 62);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 62;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // buttonLoadActors
            // 
            this.buttonLoadActors.Location = new System.Drawing.Point(426, 462);
            this.buttonLoadActors.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadActors.Name = "buttonLoadActors";
            this.buttonLoadActors.Size = new System.Drawing.Size(200, 58);
            this.buttonLoadActors.TabIndex = 61;
            this.buttonLoadActors.Text = "Load Actor/s";
            this.buttonLoadActors.UseVisualStyleBackColor = true;
            this.buttonLoadActors.Click += new System.EventHandler(this.buttonLoadActors_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(785, 58);
            this.label1.TabIndex = 60;
            this.label1.Text = "Dissociate Acting Role from Movie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(778, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 32);
            this.label3.TabIndex = 59;
            this.label3.Text = "Actors";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(462, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 32);
            this.label7.TabIndex = 58;
            this.label7.Text = "Movies";
            // 
            // buttonAddDirectors
            // 
            this.buttonAddDirectors.Location = new System.Drawing.Point(587, 600);
            this.buttonAddDirectors.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddDirectors.Name = "buttonAddDirectors";
            this.buttonAddDirectors.Size = new System.Drawing.Size(200, 58);
            this.buttonAddDirectors.TabIndex = 57;
            this.buttonAddDirectors.Text = "Dissociate Actor/s from Movie";
            this.buttonAddDirectors.UseVisualStyleBackColor = true;
            this.buttonAddDirectors.Click += new System.EventHandler(this.buttonAddDirectors_Click);
            // 
            // listBoxMovies
            // 
            this.listBoxMovies.FormattingEnabled = true;
            this.listBoxMovies.ItemHeight = 16;
            this.listBoxMovies.Location = new System.Drawing.Point(402, 226);
            this.listBoxMovies.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovies.Name = "listBoxMovies";
            this.listBoxMovies.Size = new System.Drawing.Size(247, 228);
            this.listBoxMovies.TabIndex = 56;
            // 
            // listBoxActors
            // 
            this.listBoxActors.FormattingEnabled = true;
            this.listBoxActors.ItemHeight = 16;
            this.listBoxActors.Location = new System.Drawing.Point(774, 226);
            this.listBoxActors.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxActors.Name = "listBoxActors";
            this.listBoxActors.Size = new System.Drawing.Size(247, 228);
            this.listBoxActors.TabIndex = 55;
            // 
            // DissociateAnActingRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.buttonLoadActors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonAddDirectors);
            this.Controls.Add(this.listBoxMovies);
            this.Controls.Add(this.listBoxActors);
            this.Name = "DissociateAnActingRole";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Button buttonLoadActors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAddDirectors;
        private System.Windows.Forms.ListBox listBoxMovies;
        private System.Windows.Forms.ListBox listBoxActors;
    }
}
