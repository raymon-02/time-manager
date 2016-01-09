namespace TimeManager
{
    partial class SignUpForm
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
            this.loginSignUpLabel = new System.Windows.Forms.Label();
            this.loginSignUpTextBox = new System.Windows.Forms.TextBox();
            this.passwordSignUpLabel = new System.Windows.Forms.Label();
            this.passwordSignUpTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.signupSignUpButton = new System.Windows.Forms.Button();
            this.cancelSignUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginSignUpLabel
            // 
            this.loginSignUpLabel.AutoSize = true;
            this.loginSignUpLabel.Location = new System.Drawing.Point(41, 70);
            this.loginSignUpLabel.Name = "loginSignUpLabel";
            this.loginSignUpLabel.Size = new System.Drawing.Size(48, 20);
            this.loginSignUpLabel.TabIndex = 0;
            this.loginSignUpLabel.Text = "Login";
            // 
            // loginSignUpTextBox
            // 
            this.loginSignUpTextBox.Location = new System.Drawing.Point(45, 93);
            this.loginSignUpTextBox.Name = "loginSignUpTextBox";
            this.loginSignUpTextBox.Size = new System.Drawing.Size(170, 26);
            this.loginSignUpTextBox.TabIndex = 1;
            // 
            // passwordSignUpLabel
            // 
            this.passwordSignUpLabel.AutoSize = true;
            this.passwordSignUpLabel.Location = new System.Drawing.Point(41, 138);
            this.passwordSignUpLabel.Name = "passwordSignUpLabel";
            this.passwordSignUpLabel.Size = new System.Drawing.Size(78, 20);
            this.passwordSignUpLabel.TabIndex = 2;
            this.passwordSignUpLabel.Text = "Passowrd";
            // 
            // passwordSignUpTextBox
            // 
            this.passwordSignUpTextBox.Location = new System.Drawing.Point(45, 161);
            this.passwordSignUpTextBox.Name = "passwordSignUpTextBox";
            this.passwordSignUpTextBox.Size = new System.Drawing.Size(170, 26);
            this.passwordSignUpTextBox.TabIndex = 3;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(41, 213);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(136, 20);
            this.confirmPasswordLabel.TabIndex = 4;
            this.confirmPasswordLabel.Text = "Confirm password";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(45, 236);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(170, 26);
            this.confirmPasswordTextBox.TabIndex = 5;
            // 
            // signupSignUpButton
            // 
            this.signupSignUpButton.Location = new System.Drawing.Point(45, 292);
            this.signupSignUpButton.Name = "signupSignUpButton";
            this.signupSignUpButton.Size = new System.Drawing.Size(86, 35);
            this.signupSignUpButton.TabIndex = 6;
            this.signupSignUpButton.Text = "Sign up";
            this.signupSignUpButton.UseVisualStyleBackColor = true;
            this.signupSignUpButton.Click += new System.EventHandler(this.signupSignUpButton_Click);
            // 
            // cancelSignUpButton
            // 
            this.cancelSignUpButton.Location = new System.Drawing.Point(137, 292);
            this.cancelSignUpButton.Name = "cancelSignUpButton";
            this.cancelSignUpButton.Size = new System.Drawing.Size(78, 35);
            this.cancelSignUpButton.TabIndex = 7;
            this.cancelSignUpButton.Text = "Cancel";
            this.cancelSignUpButton.UseVisualStyleBackColor = true;
            this.cancelSignUpButton.Click += new System.EventHandler(this.cancelSignUpButton_Click);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 364);
            this.Controls.Add(this.cancelSignUpButton);
            this.Controls.Add(this.signupSignUpButton);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.passwordSignUpTextBox);
            this.Controls.Add(this.passwordSignUpLabel);
            this.Controls.Add(this.loginSignUpTextBox);
            this.Controls.Add(this.loginSignUpLabel);
            this.MaximumSize = new System.Drawing.Size(275, 420);
            this.MinimumSize = new System.Drawing.Size(275, 420);
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginSignUpLabel;
        private System.Windows.Forms.TextBox loginSignUpTextBox;
        private System.Windows.Forms.Label passwordSignUpLabel;
        private System.Windows.Forms.TextBox passwordSignUpTextBox;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Button signupSignUpButton;
        private System.Windows.Forms.Button cancelSignUpButton;
    }
}