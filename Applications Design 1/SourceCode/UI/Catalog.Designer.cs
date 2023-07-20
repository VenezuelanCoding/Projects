namespace UI
{
    partial class Catalog
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
            this.flowLayoutPanelCatalog = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.buttonWatchedMovies = new System.Windows.Forms.Button();
            this.labelCurrentSorter = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.buttonCleanSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCatalog
            // 
            this.flowLayoutPanelCatalog.AutoScroll = true;
            this.flowLayoutPanelCatalog.Location = new System.Drawing.Point(59, 80);
            this.flowLayoutPanelCatalog.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelCatalog.Name = "flowLayoutPanelCatalog";
            this.flowLayoutPanelCatalog.Size = new System.Drawing.Size(1221, 753);
            this.flowLayoutPanelCatalog.TabIndex = 0;
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(56, 8);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 1;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // buttonWatchedMovies
            // 
            this.buttonWatchedMovies.Location = new System.Drawing.Point(1091, 5);
            this.buttonWatchedMovies.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWatchedMovies.Name = "buttonWatchedMovies";
            this.buttonWatchedMovies.Size = new System.Drawing.Size(189, 44);
            this.buttonWatchedMovies.TabIndex = 2;
            this.buttonWatchedMovies.Text = "Watched Movies";
            this.buttonWatchedMovies.UseVisualStyleBackColor = true;
            this.buttonWatchedMovies.Click += new System.EventHandler(this.buttonWatchedMovies_Click);
            // 
            // labelCurrentSorter
            // 
            this.labelCurrentSorter.AutoSize = true;
            this.labelCurrentSorter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentSorter.Location = new System.Drawing.Point(109, 5);
            this.labelCurrentSorter.Name = "labelCurrentSorter";
            this.labelCurrentSorter.Size = new System.Drawing.Size(80, 25);
            this.labelCurrentSorter.TabIndex = 3;
            this.labelCurrentSorter.Text = "Sorting:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(875, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(160, 22);
            this.textBoxSearch.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(875, 31);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(121, 28);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "By Actor",
            "By Director"});
            this.comboBoxSearch.Location = new System.Drawing.Point(757, 5);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(112, 24);
            this.comboBoxSearch.TabIndex = 6;
            // 
            // buttonCleanSearch
            // 
            this.buttonCleanSearch.Location = new System.Drawing.Point(757, 31);
            this.buttonCleanSearch.Name = "buttonCleanSearch";
            this.buttonCleanSearch.Size = new System.Drawing.Size(112, 28);
            this.buttonCleanSearch.TabIndex = 7;
            this.buttonCleanSearch.Text = "Clean Search";
            this.buttonCleanSearch.UseVisualStyleBackColor = true;
            this.buttonCleanSearch.Click += new System.EventHandler(this.buttonCleanSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(650, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search:";
            // 
            // Catalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCleanSearch);
            this.Controls.Add(this.comboBoxSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelCurrentSorter);
            this.Controls.Add(this.buttonWatchedMovies);
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.flowLayoutPanelCatalog);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Catalog";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCatalog;
        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Button buttonWatchedMovies;
        private System.Windows.Forms.Label labelCurrentSorter;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Button buttonCleanSearch;
        private System.Windows.Forms.Label label1;
    }
}
