
namespace ConveyorGui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.GoodRadio = new System.Windows.Forms.RadioButton();
            this.DefectiveButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DefectiveButton);
            this.panel1.Controls.Add(this.GoodRadio);
            this.panel1.Location = new System.Drawing.Point(35, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 100);
            this.panel1.TabIndex = 0;
            // 
            // GoodRadio
            // 
            this.GoodRadio.AutoSize = true;
            this.GoodRadio.Checked = true;
            this.GoodRadio.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GoodRadio.Location = new System.Drawing.Point(13, 11);
            this.GoodRadio.Name = "GoodRadio";
            this.GoodRadio.Size = new System.Drawing.Size(97, 29);
            this.GoodRadio.TabIndex = 1;
            this.GoodRadio.Text = "Годный";
            this.GoodRadio.UseVisualStyleBackColor = true;
            // 
            // DefectiveButton
            // 
            this.DefectiveButton.AutoSize = true;
            this.DefectiveButton.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DefectiveButton.Location = new System.Drawing.Point(13, 46);
            this.DefectiveButton.Name = "DefectiveButton";
            this.DefectiveButton.Size = new System.Drawing.Size(73, 29);
            this.DefectiveButton.TabIndex = 2;
            this.DefectiveButton.Text = "Брак";
            this.DefectiveButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 431);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Конвейер";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton GoodRadio;
        private System.Windows.Forms.RadioButton DefectiveButton;
    }
}

