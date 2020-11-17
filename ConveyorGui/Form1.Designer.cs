
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
            this.DefectiveButton = new System.Windows.Forms.RadioButton();
            this.GoodRadio = new System.Windows.Forms.RadioButton();
            this.AddButton = new System.Windows.Forms.Button();
            this.PushButton = new System.Windows.Forms.Button();
            this.ConveyorPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorHandler = new System.Windows.Forms.Label();
            this.ErrorText = new System.Windows.Forms.Label();
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
            // GoodRadio
            // 
            this.GoodRadio.AutoSize = true;
            this.GoodRadio.Checked = true;
            this.GoodRadio.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GoodRadio.Location = new System.Drawing.Point(13, 11);
            this.GoodRadio.Name = "GoodRadio";
            this.GoodRadio.Size = new System.Drawing.Size(97, 29);
            this.GoodRadio.TabIndex = 1;
            this.GoodRadio.TabStop = true;
            this.GoodRadio.Text = "Годный";
            this.GoodRadio.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddButton.Location = new System.Drawing.Point(35, 181);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(151, 50);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Камера";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PushButton
            // 
            this.PushButton.Enabled = false;
            this.PushButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PushButton.Location = new System.Drawing.Point(35, 265);
            this.PushButton.Name = "PushButton";
            this.PushButton.Size = new System.Drawing.Size(151, 50);
            this.PushButton.TabIndex = 2;
            this.PushButton.Text = "Толкатель";
            this.PushButton.UseVisualStyleBackColor = true;
            this.PushButton.Click += new System.EventHandler(this.PushButton_Click);
            // 
            // ConveyorPanel
            // 
            this.ConveyorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConveyorPanel.Location = new System.Drawing.Point(234, 69);
            this.ConveyorPanel.Name = "ConveyorPanel";
            this.ConveyorPanel.Size = new System.Drawing.Size(460, 140);
            this.ConveyorPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(407, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Конвейер";
            // 
            // ErrorHandler
            // 
            this.ErrorHandler.AutoSize = true;
            this.ErrorHandler.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ErrorHandler.ForeColor = System.Drawing.Color.Firebrick;
            this.ErrorHandler.Location = new System.Drawing.Point(407, 227);
            this.ErrorHandler.Name = "ErrorHandler";
            this.ErrorHandler.Size = new System.Drawing.Size(98, 28);
            this.ErrorHandler.TabIndex = 5;
            this.ErrorHandler.Text = "Ошибка!";
            this.ErrorHandler.Visible = false;
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ErrorText.ForeColor = System.Drawing.Color.IndianRed;
            this.ErrorText.Location = new System.Drawing.Point(254, 265);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(72, 20);
            this.ErrorText.TabIndex = 6;
            this.ErrorText.Text = "Ошибка!";
            this.ErrorText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorText.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 373);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.ErrorHandler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConveyorPanel);
            this.Controls.Add(this.PushButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Конвейер";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton GoodRadio;
        private System.Windows.Forms.RadioButton DefectiveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button PushButton;
        private System.Windows.Forms.FlowLayoutPanel ConveyorPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrorHandler;
        private System.Windows.Forms.Label ErrorText;
    }
}

