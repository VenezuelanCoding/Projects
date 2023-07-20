namespace UI
{
    partial class ActingRoleSettings
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
            this.buttonAddActingRole = new System.Windows.Forms.Button();
            this.buttonDissociateActingRole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(435, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "Acting Role Settings";
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(127, 76);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(38, 16);
            this.linkLabelBack.TabIndex = 25;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // buttonAddActingRole
            // 
            this.buttonAddActingRole.Location = new System.Drawing.Point(449, 310);
            this.buttonAddActingRole.Name = "buttonAddActingRole";
            this.buttonAddActingRole.Size = new System.Drawing.Size(185, 79);
            this.buttonAddActingRole.TabIndex = 33;
            this.buttonAddActingRole.Text = "Add an Acting Role";
            this.buttonAddActingRole.UseVisualStyleBackColor = true;
            this.buttonAddActingRole.Click += new System.EventHandler(this.buttonAddActingRole_Click);
            // 
            // buttonDissociateActingRole
            // 
            this.buttonDissociateActingRole.Location = new System.Drawing.Point(675, 310);
            this.buttonDissociateActingRole.Name = "buttonDissociateActingRole";
            this.buttonDissociateActingRole.Size = new System.Drawing.Size(185, 79);
            this.buttonDissociateActingRole.TabIndex = 34;
            this.buttonDissociateActingRole.Text = "Dissociate an Acting Role from a Movie";
            this.buttonDissociateActingRole.UseVisualStyleBackColor = true;
            this.buttonDissociateActingRole.Click += new System.EventHandler(this.buttonDissociateActingRole_Click);
            // 
            // ActingRoleSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDissociateActingRole);
            this.Controls.Add(this.buttonAddActingRole);
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.label1);
            this.Name = "ActingRoleSettings";
            this.Size = new System.Drawing.Size(1365, 945);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.Button buttonAddActingRole;
        private System.Windows.Forms.Button buttonDissociateActingRole;
    }
}
