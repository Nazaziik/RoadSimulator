
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
            this.OpenControlPanelButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CarsCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OpenControlPanelButton
            // 
            this.OpenControlPanelButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenControlPanelButton.Location = new System.Drawing.Point(947, 12);
            this.OpenControlPanelButton.Name = "OpenControlPanelButton";
            this.OpenControlPanelButton.Size = new System.Drawing.Size(102, 23);
            this.OpenControlPanelButton.TabIndex = 0;
            this.OpenControlPanelButton.Text = "Open Control Panel";
            this.OpenControlPanelButton.UseVisualStyleBackColor = true;
            this.OpenControlPanelButton.Click += new System.EventHandler(this.OpenControlPanelButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // CarsCountLabel
            // 
            this.CarsCountLabel.AutoSize = true;
            this.CarsCountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CarsCountLabel.Location = new System.Drawing.Point(952, 38);
            this.CarsCountLabel.Name = "CarsCountLabel";
            this.CarsCountLabel.Size = new System.Drawing.Size(87, 21);
            this.CarsCountLabel.TabIndex = 1;
            this.CarsCountLabel.Text = "Cars Count";
            // 
            // Road
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RoadSimulator.Properties.Resources.mapa_v6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1051, 761);
            this.Controls.Add(this.CarsCountLabel);
            this.Controls.Add(this.OpenControlPanelButton);
            this.DoubleBuffered = true;
            this.Name = "Road";
            this.Text = "Road Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenControlPanelButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label CarsCountLabel;
    }
}

