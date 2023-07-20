namespace UI
{
    partial class RemoveAMember
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
            this.buttonRemoveMember = new System.Windows.Forms.Button();
            this.listBoxRemoveMember = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(128, 98);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 42;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // buttonRemoveMember
            // 
            this.buttonRemoveMember.Location = new System.Drawing.Point(611, 390);
            this.buttonRemoveMember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveMember.Name = "buttonRemoveMember";
            this.buttonRemoveMember.Size = new System.Drawing.Size(137, 26);
            this.buttonRemoveMember.TabIndex = 41;
            this.buttonRemoveMember.Text = "Delete Member";
            this.buttonRemoveMember.UseVisualStyleBackColor = true;
            this.buttonRemoveMember.Click += new System.EventHandler(this.buttonRemoveMember_Click);
            // 
            // listBoxRemoveMember
            // 
            this.listBoxRemoveMember.FormattingEnabled = true;
            this.listBoxRemoveMember.ItemHeight = 16;
            this.listBoxRemoveMember.Location = new System.Drawing.Point(577, 201);
            this.listBoxRemoveMember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxRemoveMember.Name = "listBoxRemoveMember";
            this.listBoxRemoveMember.Size = new System.Drawing.Size(209, 164);
            this.listBoxRemoveMember.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(471, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 58);
            this.label1.TabIndex = 39;
            this.label1.Text = "Delete a Member";
            // 
            // RemoveAMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.buttonRemoveMember);
            this.Controls.Add(this.listBoxRemoveMember);
            this.Controls.Add(this.label1);
            this.Name = "RemoveAMember";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Button buttonRemoveMember;
        private System.Windows.Forms.ListBox listBoxRemoveMember;
        private System.Windows.Forms.Label label1;
    }
}
