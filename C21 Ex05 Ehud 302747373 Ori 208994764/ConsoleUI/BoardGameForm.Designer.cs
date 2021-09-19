
namespace WindowUI
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
            this.m_XOButtonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.m_ColNumberButtonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // m_Player1Label
            // 
            this.m_Player1Label.AutoSize = true;
            this.m_Player1Label.Location = new System.Drawing.Point(257, 791);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(127, 32);
            this.m_Player1Label.TabIndex = 0;
            this.m_Player1Label.Text = "Player 1:";
            // 
            // m_Player1ScoreLabel
            // 
            this.m_Player1ScoreLabel.AutoSize = true;
            this.m_Player1ScoreLabel.Location = new System.Drawing.Point(399, 791);
            this.m_Player1ScoreLabel.Name = "m_Player1ScoreLabel";
            this.m_Player1ScoreLabel.Size = new System.Drawing.Size(31, 32);
            this.m_Player1ScoreLabel.TabIndex = 1;
            this.m_Player1ScoreLabel.Text = "0";
            // 
            // m_Player2ScoreLabel
            // 
            this.m_Player2ScoreLabel.AutoSize = true;
            this.m_Player2ScoreLabel.Location = new System.Drawing.Point(947, 791);
            this.m_Player2ScoreLabel.Name = "m_Player2ScoreLabel";
            this.m_Player2ScoreLabel.Size = new System.Drawing.Size(31, 32);
            this.m_Player2ScoreLabel.TabIndex = 3;
            this.m_Player2ScoreLabel.Text = "0";
            // 
            // m_Player2Label
            // 
            this.m_Player2Label.AutoSize = true;
            this.m_Player2Label.Location = new System.Drawing.Point(805, 791);
            this.m_Player2Label.Name = "m_Player2Label";
            this.m_Player2Label.Size = new System.Drawing.Size(127, 32);
            this.m_Player2Label.TabIndex = 2;
            this.m_Player2Label.Text = "Player 2:";
            // 
            // m_XOButtonsTableLayout
            // 
            this.m_XOButtonsTableLayout.ColumnCount = 1;
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_XOButtonsTableLayout.Location = new System.Drawing.Point(35, 122);
            this.m_XOButtonsTableLayout.Name = "m_XOButtonsTableLayout";
            this.m_XOButtonsTableLayout.RowCount = 1;
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_XOButtonsTableLayout.Size = new System.Drawing.Size(1214, 634);
            this.m_XOButtonsTableLayout.TabIndex = 4;
            // 
            // m_ColNumberButtonsTableLayout
            // 
            this.m_ColNumberButtonsTableLayout.ColumnCount = 1;
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_ColNumberButtonsTableLayout.Location = new System.Drawing.Point(35, 44);
            this.m_ColNumberButtonsTableLayout.Name = "m_ColNumberButtonsTableLayout";
            this.m_ColNumberButtonsTableLayout.RowCount = 1;
            this.m_ColNumberButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_ColNumberButtonsTableLayout.Size = new System.Drawing.Size(1214, 72);
            this.m_ColNumberButtonsTableLayout.TabIndex = 5;
            // 
            // BoardGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 869);
            this.Controls.Add(this.m_ColNumberButtonsTableLayout);
            this.Controls.Add(this.m_XOButtonsTableLayout);
            this.Controls.Add(this.m_Player2ScoreLabel);
            this.Controls.Add(this.m_Player2Label);
            this.Controls.Add(this.m_Player1ScoreLabel);
            this.Controls.Add(this.m_Player1Label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoardGameForm";
            this.Text = "4 in a Row !!";
            this.Load += new System.EventHandler(this.boardGameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel m_XOButtonsTableLayout;
        private System.Windows.Forms.TableLayoutPanel m_ColNumberButtonsTableLayout;
    }
}