namespace UI
{
    partial class ModifyAMember
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
            this.buttonLoadPoster = new System.Windows.Forms.Button();
            this.listBoxMembers = new System.Windows.Forms.ListBox();
            this.buttonModify = new System.Windows.Forms.Button();
            this.pictureBoxNewProfilePicture = new System.Windows.Forms.PictureBox();
            this.buttoNewProfilePicture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadPoster
            // 
            this.buttonLoadPoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLoadPoster.Location = new System.Drawing.Point(472, 481);
            this.buttonLoadPoster.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadPoster.Name = "buttonLoadPoster";
            this.buttonLoadPoster.Size = new System.Drawing.Size(140, 27);
            this.buttonLoadPoster.TabIndex = 36;
            this.buttonLoadPoster.Text = "Load Poster";
            this.buttonLoadPoster.UseVisualStyleBackColor = true;
            this.buttonLoadPoster.Click += new System.EventHandler(this.buttonLoadPoster_Click);
            // 
            // listBoxMembers
            // 
            this.listBoxMembers.FormattingEnabled = true;
            this.listBoxMembers.ItemHeight = 16;
            this.listBoxMembers.Location = new System.Drawing.Point(442, 224);
            this.listBoxMembers.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMembers.Name = "listBoxMembers";
            this.listBoxMembers.Size = new System.Drawing.Size(199, 244);
            this.listBoxMembers.TabIndex = 35;
            // 
            // buttonModify
            // 
            this.buttonModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonModify.Location = new System.Drawing.Point(575, 566);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(4);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(140, 27);
            this.buttonModify.TabIndex = 34;
            this.buttonModify.Text = "Modify Member";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // pictureBoxNewProfilePicture
            // 
            this.pictureBoxNewProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxNewProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxNewProfilePicture.Location = new System.Drawing.Point(688, 223);
            this.pictureBoxNewProfilePicture.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxNewProfilePicture.Name = "pictureBoxNewProfilePicture";
            this.pictureBoxNewProfilePicture.Size = new System.Drawing.Size(199, 246);
            this.pictureBoxNewProfilePicture.TabIndex = 33;
            this.pictureBoxNewProfilePicture.TabStop = false;
            // 
            // buttoNewProfilePicture
            // 
            this.buttoNewProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttoNewProfilePicture.Location = new System.Drawing.Point(711, 481);
            this.buttoNewProfilePicture.Margin = new System.Windows.Forms.Padding(4);
            this.buttoNewProfilePicture.Name = "buttoNewProfilePicture";
            this.buttoNewProfilePicture.Size = new System.Drawing.Size(140, 27);
            this.buttoNewProfilePicture.TabIndex = 32;
            this.buttoNewProfilePicture.Text = "Select New Poster";
            this.buttoNewProfilePicture.UseVisualStyleBackColor = true;
            this.buttoNewProfilePicture.Click += new System.EventHandler(this.buttoNewProfilePicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(432, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 58);
            this.label1.TabIndex = 37;
            this.label1.Text = "Member Modification";
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(104, 72);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 38;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // ModifyAMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoadPoster);
            this.Controls.Add(this.listBoxMembers);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.pictureBoxNewProfilePicture);
            this.Controls.Add(this.buttoNewProfilePicture);
            this.Name = "ModifyAMember";
            this.Size = new System.Drawing.Size(1365, 945);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadPoster;
        private System.Windows.Forms.ListBox listBoxMembers;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.PictureBox pictureBoxNewProfilePicture;
        private System.Windows.Forms.Button buttoNewProfilePicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelBack;
    }
}
