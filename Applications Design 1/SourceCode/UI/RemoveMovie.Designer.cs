namespace UI
{
    partial class RemoveMovie
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
            this.buttonRemoveMovie2 = new System.Windows.Forms.Button();
            this.listBoxRemoveMovie = new System.Windows.Forms.ListBox();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(550, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 58);
            this.label1.TabIndex = 12;
            this.label1.Text = "Remove Movie";
            // 
            // buttonRemoveMovie2
            // 
            this.buttonRemoveMovie2.Location = new System.Drawing.Point(654, 329);
            this.buttonRemoveMovie2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveMovie2.Name = "buttonRemoveMovie2";
            this.buttonRemoveMovie2.Size = new System.Drawing.Size(137, 26);
            this.buttonRemoveMovie2.TabIndex = 20;
            this.buttonRemoveMovie2.Text = "Remove Movie";
            this.buttonRemoveMovie2.UseVisualStyleBackColor = true;
            this.buttonRemoveMovie2.Click += new System.EventHandler(this.buttonRemoveMovie2_Click);
            // 
            // listBoxRemoveMovie
            // 
            this.listBoxRemoveMovie.FormattingEnabled = true;
            this.listBoxRemoveMovie.ItemHeight = 16;
            this.listBoxRemoveMovie.Location = new System.Drawing.Point(620, 140);
            this.listBoxRemoveMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxRemoveMovie.Name = "listBoxRemoveMovie";
            this.listBoxRemoveMovie.Size = new System.Drawing.Size(209, 164);
            this.listBoxRemoveMovie.TabIndex = 19;
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(171, 37);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 38;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // RemoveMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.buttonRemoveMovie2);
            this.Controls.Add(this.listBoxRemoveMovie);
            this.Controls.Add(this.label1);
            this.Name = "RemoveMovie";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemoveMovie2;
        private System.Windows.Forms.ListBox listBoxRemoveMovie;
        private System.Windows.Forms.LinkLabel linkLabelBack;
    }
}
