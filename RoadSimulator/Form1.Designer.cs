
namespace RoadSimulator
{
    partial class Road
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
            this.components = new System.ComponentModel.Container();
            this.CarAddButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CarsCountLabel = new System.Windows.Forms.Label();
            this.CarDeleteButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CarAddButton
            // 
            this.CarAddButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CarAddButton.Location = new System.Drawing.Point(12, 12);
            this.CarAddButton.Name = "CarAddButton";
            this.CarAddButton.Size = new System.Drawing.Size(102, 23);
            this.CarAddButton.TabIndex = 0;
            this.CarAddButton.Text = "Add car";
            this.CarAddButton.UseVisualStyleBackColor = true;
            this.CarAddButton.Click += new System.EventHandler(this.CarAddButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
            // 
            // CarsCountLabel
            // 
            this.CarsCountLabel.AutoSize = true;
            this.CarsCountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CarsCountLabel.Location = new System.Drawing.Point(427, 12);
            this.CarsCountLabel.Name = "CarsCountLabel";
            this.CarsCountLabel.Size = new System.Drawing.Size(87, 21);
            this.CarsCountLabel.TabIndex = 1;
            this.CarsCountLabel.Text = "Cars Count";
            // 
            // CarDeleteButton
            // 
            this.CarDeleteButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CarDeleteButton.Location = new System.Drawing.Point(142, 12);
            this.CarDeleteButton.Name = "CarDeleteButton";
            this.CarDeleteButton.Size = new System.Drawing.Size(102, 23);
            this.CarDeleteButton.TabIndex = 2;
            this.CarDeleteButton.Text = "Delete car";
            this.CarDeleteButton.UseVisualStyleBackColor = true;
            this.CarDeleteButton.Click += new System.EventHandler(this.CarDeleteButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(268, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Wanna see rectangles";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Road
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RoadSimulator.Properties.Resources.mapa_v6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1051, 761);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CarDeleteButton);
            this.Controls.Add(this.CarsCountLabel);
            this.Controls.Add(this.CarAddButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Road";
            this.Text = "Road Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CarAddButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label CarsCountLabel;
        private System.Windows.Forms.Button CarDeleteButton;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

