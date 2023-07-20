namespace UI
{
    partial class GenreSettings
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGenreName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGenreDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddGenre = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxRemoveGenre = new System.Windows.Forms.ListBox();
            this.buttonRemoveGenre = new System.Windows.Forms.Button();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(442, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 58);
            this.label1.TabIndex = 12;
            this.label1.Text = "Genre Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 39);
            this.label2.TabIndex = 13;
            this.label2.Text = "Add a Genre";
            // 
            // textBoxGenreName
            // 
            this.textBoxGenreName.Location = new System.Drawing.Point(331, 192);
            this.textBoxGenreName.Name = "textBoxGenreName";
            this.textBoxGenreName.Size = new System.Drawing.Size(182, 22);
            this.textBoxGenreName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name";
            // 
            // textBoxGenreDescription
            // 
            this.textBoxGenreDescription.Location = new System.Drawing.Point(333, 239);
            this.textBoxGenreDescription.Multiline = true;
            this.textBoxGenreDescription.Name = "textBoxGenreDescription";
            this.textBoxGenreDescription.Size = new System.Drawing.Size(179, 77);
            this.textBoxGenreDescription.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Description";
            // 
            // buttonAddGenre
            // 
            this.buttonAddGenre.Location = new System.Drawing.Point(357, 342);
            this.buttonAddGenre.Name = "buttonAddGenre";
            this.buttonAddGenre.Size = new System.Drawing.Size(106, 33);
            this.buttonAddGenre.TabIndex = 3;
            this.buttonAddGenre.Text = "Add Genre";
            this.buttonAddGenre.UseVisualStyleBackColor = true;
            this.buttonAddGenre.Click += new System.EventHandler(this.buttonAddGenre_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(734, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 39);
            this.label5.TabIndex = 17;
            this.label5.Text = "Remove a Genre";
            // 
            // listBoxRemoveGenre
            // 
            this.listBoxRemoveGenre.FormattingEnabled = true;
            this.listBoxRemoveGenre.ItemHeight = 16;
            this.listBoxRemoveGenre.Location = new System.Drawing.Point(734, 184);
            this.listBoxRemoveGenre.Name = "listBoxRemoveGenre";
            this.listBoxRemoveGenre.Size = new System.Drawing.Size(275, 132);
            this.listBoxRemoveGenre.TabIndex = 4;
            // 
            // buttonRemoveGenre
            // 
            this.buttonRemoveGenre.Location = new System.Drawing.Point(814, 342);
            this.buttonRemoveGenre.Name = "buttonRemoveGenre";
            this.buttonRemoveGenre.Size = new System.Drawing.Size(125, 33);
            this.buttonRemoveGenre.TabIndex = 5;
            this.buttonRemoveGenre.Text = "Remove Genre";
            this.buttonRemoveGenre.UseVisualStyleBackColor = true;
            this.buttonRemoveGenre.Click += new System.EventHandler(this.buttonRemoveGenre_Click);
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(48, 46);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 18;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // GenreSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.buttonRemoveGenre);
            this.Controls.Add(this.listBoxRemoveGenre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonAddGenre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxGenreDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGenreName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GenreSettings";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGenreName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGenreDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddGenre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxRemoveGenre;
        private System.Windows.Forms.Button buttonRemoveGenre;
        private System.Windows.Forms.LinkLabel linkLabelBack;
    }
}
