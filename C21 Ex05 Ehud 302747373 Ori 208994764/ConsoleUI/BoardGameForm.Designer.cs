
namespace ConsoleUI
{
    partial class BoardGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label m_Player1Label;
        private System.Windows.Forms.Label m_Player1ScoreLabel;
        private System.Windows.Forms.Label m_Player2ScoreLabel;
        private System.Windows.Forms.Label m_Player2Label;

        public System.Windows.Forms.Label Player1Label
        {
            get => m_Player1Label;
        }

        public System.Windows.Forms.Label Player2Label
        {
            get => m_Player2Label;
        }

        public System.Windows.Forms.Label Player1ScoreLabel
        {
            get => m_Player1ScoreLabel;
        }

        public System.Windows.Forms.Label Player2ScoreLabel
        {
            get => m_Player2ScoreLabel;
        }

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
            this.m_Player1Label = new System.Windows.Forms.Label();
            this.m_Player1ScoreLabel = new System.Windows.Forms.Label();
            this.m_Player2ScoreLabel = new System.Windows.Forms.Label();
            this.m_Player2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_Player1Label
            // 
            this.m_Player1Label.AutoSize = true;
            this.m_Player1Label.Location = new System.Drawing.Point(260, 707);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(127, 32);
            this.m_Player1Label.TabIndex = 0;
            this.m_Player1Label.Text = "Player 1:";
            // 
            // m_Player1ScoreLabel
            // 
            this.m_Player1ScoreLabel.AutoSize = true;
            this.m_Player1ScoreLabel.Location = new System.Drawing.Point(402, 707);
            this.m_Player1ScoreLabel.Name = "m_Player1ScoreLabel";
            this.m_Player1ScoreLabel.Size = new System.Drawing.Size(31, 32);
            this.m_Player1ScoreLabel.TabIndex = 1;
            this.m_Player1ScoreLabel.Text = "0";
            // 
            // m_Player2ScoreLabel
            // 
            this.m_Player2ScoreLabel.AutoSize = true;
            this.m_Player2ScoreLabel.Location = new System.Drawing.Point(950, 707);
            this.m_Player2ScoreLabel.Name = "m_Player2ScoreLabel";
            this.m_Player2ScoreLabel.Size = new System.Drawing.Size(31, 32);
            this.m_Player2ScoreLabel.TabIndex = 3;
            this.m_Player2ScoreLabel.Text = "0";
            // 
            // m_Player2Label
            // 
            this.m_Player2Label.AutoSize = true;
            this.m_Player2Label.Location = new System.Drawing.Point(808, 707);
            this.m_Player2Label.Name = "m_Player2Label";
            this.m_Player2Label.Size = new System.Drawing.Size(127, 32);
            this.m_Player2Label.TabIndex = 2;
            this.m_Player2Label.Text = "Player 2:";
            // 
            // BoardGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 831);
            this.Controls.Add(this.m_Player2ScoreLabel);
            this.Controls.Add(this.m_Player2Label);
            this.Controls.Add(this.m_Player1ScoreLabel);
            this.Controls.Add(this.m_Player1Label);
            this.Name = "BoardGameForm";
            this.Text = "4 in a Row !!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}