namespace Folder.Hidden.Client
{
    partial class Enter
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtPlaceholderPassword = new Folder.Hidden.Controls.TextBoxPlaceholder();
            this.btnEnter = new System.Windows.Forms.Button();
            this.linkForgetPassword = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(100, 26);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(80, 22);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            // 
            // txtPlaceholderPassword
            // 
            this.txtPlaceholderPassword.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaceholderPassword.Location = new System.Drawing.Point(59, 89);
            this.txtPlaceholderPassword.Name = "txtPlaceholderPassword";
            this.txtPlaceholderPassword.PlaceholderText = "Password";
            this.txtPlaceholderPassword.Size = new System.Drawing.Size(165, 20);
            this.txtPlaceholderPassword.TabIndex = 2;
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(59, 115);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(165, 23);
            this.btnEnter.TabIndex = 3;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // linkForgetPassword
            // 
            this.linkForgetPassword.AutoSize = true;
            this.linkForgetPassword.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkForgetPassword.Location = new System.Drawing.Point(56, 141);
            this.linkForgetPassword.Name = "linkForgetPassword";
            this.linkForgetPassword.Size = new System.Drawing.Size(127, 13);
            this.linkForgetPassword.TabIndex = 4;
            this.linkForgetPassword.TabStop = true;
            this.linkForgetPassword.Text = "I Forget My Password";
            this.linkForgetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgetPassword_LinkClicked);
            // 
            // Enter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 261);
            this.Controls.Add(this.linkForgetPassword);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtPlaceholderPassword);
            this.Controls.Add(this.lblWelcome);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "Enter";
            this.Text = "Enter your password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWelcome;
        private Controls.TextBoxPlaceholder txtPlaceholderPassword;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.LinkLabel linkForgetPassword;
    }
}