namespace DamaVisualization
{
    partial class Menu
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
            this.button_Play = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Play
            // 
            this.button_Play.Location = new System.Drawing.Point(76, 138);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(112, 69);
            this.button_Play.TabIndex = 0;
            this.button_Play.Text = "Play";
            this.button_Play.UseVisualStyleBackColor = true;
            this.button_Play.Click += new System.EventHandler(this.PlayClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(240, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 69);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LoadClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(413, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 69);
            this.button3.TabIndex = 2;
            this.button3.Text = "Quit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.QuitClick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 338);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Play);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}