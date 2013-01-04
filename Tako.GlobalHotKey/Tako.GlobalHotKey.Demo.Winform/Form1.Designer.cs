namespace Tako.GlobalHotKey.Demo.Winform
{
    partial class Form1
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
            this.button_Register = new System.Windows.Forms.Button();
            this.button_Unregister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Register
            // 
            this.button_Register.Location = new System.Drawing.Point(12, 12);
            this.button_Register.Name = "button_Register";
            this.button_Register.Size = new System.Drawing.Size(75, 23);
            this.button_Register.TabIndex = 0;
            this.button_Register.Text = "Register";
            this.button_Register.UseVisualStyleBackColor = true;
            this.button_Register.Click += new System.EventHandler(this.button_Register_Click);
            // 
            // button_Unregister
            // 
            this.button_Unregister.Location = new System.Drawing.Point(12, 72);
            this.button_Unregister.Name = "button_Unregister";
            this.button_Unregister.Size = new System.Drawing.Size(75, 23);
            this.button_Unregister.TabIndex = 1;
            this.button_Unregister.Text = "Unregister";
            this.button_Unregister.UseVisualStyleBackColor = true;
            this.button_Unregister.Click += new System.EventHandler(this.button_Unregister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ctrl+Alt+F5 , Ctrl+Alt+F4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Unregister);
            this.Controls.Add(this.button_Register);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Register;
        private System.Windows.Forms.Button button_Unregister;
        private System.Windows.Forms.Label label1;
    }
}

