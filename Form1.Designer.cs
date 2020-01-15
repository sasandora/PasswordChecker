namespace PasswordChecker
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
            if (disposing && (components != null)) {
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
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblHash = new System.Windows.Forms.Label();
            this.lblResponse = new System.Windows.Forms.Label();
            this.chkHide = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(36, 76);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(330, 22);
            this.txtPass.TabIndex = 0;
            this.txtPass.TextChanged += new System.EventHandler(this.TextToHash);
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(372, 76);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Tarkista";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblHash
            // 
            this.lblHash.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.lblHash.AutoSize = true;
            this.lblHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHash.Location = new System.Drawing.Point(32, 138);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(51, 20);
            this.lblHash.TabIndex = 2;
            this.lblHash.Text = "Hash:";
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponse.Location = new System.Drawing.Point(32, 192);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(0, 22);
            this.lblResponse.TabIndex = 3;
            // 
            // chkHide
            // 
            this.chkHide.Location = new System.Drawing.Point(372, 105);
            this.chkHide.Name = "chkHide";
            this.chkHide.Size = new System.Drawing.Size(104, 24);
            this.chkHide.TabIndex = 0;
            this.chkHide.Text = "Piilota teksti";
            this.chkHide.CheckedChanged += new System.EventHandler(this.chkHide_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 318);
            this.Controls.Add(this.chkHide);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.lblHash);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtPass);
            this.Name = "Form1";
            this.Text = "Password Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.CheckBox chkHide;
    }
}

