namespace UI
{
    partial class WatchedMovies
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
            this.flowLayoutWatchedMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // flowLayoutWatchedMovies
            // 
            this.flowLayoutWatchedMovies.Location = new System.Drawing.Point(59, 80);
            this.flowLayoutWatchedMovies.Name = "flowLayoutWatchedMovies";
            this.flowLayoutWatchedMovies.Size = new System.Drawing.Size(1221, 753);
            this.flowLayoutWatchedMovies.TabIndex = 0;
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(56, 32);
            this.linkLabelBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 2;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // WatchedMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.flowLayoutWatchedMovies);
            this.Name = "WatchedMovies";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutWatchedMovies;
        private System.Windows.Forms.LinkLabel linkLabelBack;
    }
}
