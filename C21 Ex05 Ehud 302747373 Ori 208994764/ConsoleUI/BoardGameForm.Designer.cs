
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
            this.m_Player1Label.Location = new System.Drawing.Point(145, 510);
            this.m_Player1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(69, 20);
            this.m_Player1Label.TabIndex = 0;
            this.m_Player1Label.Text = "Player 1:";
            // 
            // m_Player1ScoreLabel
            // 
            this.m_Player1ScoreLabel.AutoSize = true;
            this.m_Player1ScoreLabel.Location = new System.Drawing.Point(224, 510);
            this.m_Player1ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_Player1ScoreLabel.Name = "m_Player1ScoreLabel";
            this.m_Player1ScoreLabel.Size = new System.Drawing.Size(18, 20);
            this.m_Player1ScoreLabel.TabIndex = 1;
            this.m_Player1ScoreLabel.Text = "0";
            // 
            // m_Player2ScoreLabel
            // 
            this.m_Player2ScoreLabel.AutoSize = true;
            this.m_Player2ScoreLabel.Location = new System.Drawing.Point(533, 510);
            this.m_Player2ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_Player2ScoreLabel.Name = "m_Player2ScoreLabel";
            this.m_Player2ScoreLabel.Size = new System.Drawing.Size(18, 20);
            this.m_Player2ScoreLabel.TabIndex = 3;
            this.m_Player2ScoreLabel.Text = "0";
            // 
            // m_Player2Label
            // 
            this.m_Player2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_Player2Label.AutoSize = true;
            this.m_Player2Label.Location = new System.Drawing.Point(453, 510);
            this.m_Player2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_Player2Label.Name = "m_Player2Label";
            this.m_Player2Label.Size = new System.Drawing.Size(69, 20);
            this.m_Player2Label.TabIndex = 2;
            this.m_Player2Label.Text = "Player 2:";
            // 
            // m_XOButtonsTableLayout
            // 
            this.m_XOButtonsTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_XOButtonsTableLayout.AutoSize = true;
            this.m_XOButtonsTableLayout.ColumnCount = 8;
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_XOButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_XOButtonsTableLayout.Location = new System.Drawing.Point(20, 70);
            this.m_XOButtonsTableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.m_XOButtonsTableLayout.Name = "m_XOButtonsTableLayout";
            this.m_XOButtonsTableLayout.RowCount = 8;
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_XOButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.m_XOButtonsTableLayout.Size = new System.Drawing.Size(683, 404);
            this.m_XOButtonsTableLayout.TabIndex = 4;
            // 
            // m_ColNumberButtonsTableLayout
            // 
            this.m_ColNumberButtonsTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ColNumberButtonsTableLayout.AutoSize = true;
            this.m_ColNumberButtonsTableLayout.ColumnCount = 8;
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_ColNumberButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_ColNumberButtonsTableLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.m_ColNumberButtonsTableLayout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_ColNumberButtonsTableLayout.Location = new System.Drawing.Point(20, 28);
            this.m_ColNumberButtonsTableLayout.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.m_ColNumberButtonsTableLayout.Name = "m_ColNumberButtonsTableLayout";
            this.m_ColNumberButtonsTableLayout.RowCount = 1;
            this.m_ColNumberButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.m_ColNumberButtonsTableLayout.Size = new System.Drawing.Size(683, 32);
            this.m_ColNumberButtonsTableLayout.TabIndex = 5;
            // 
            // BoardGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 561);
            this.Controls.Add(this.m_ColNumberButtonsTableLayout);
            this.Controls.Add(this.m_XOButtonsTableLayout);
            this.Controls.Add(this.m_Player2ScoreLabel);
            this.Controls.Add(this.m_Player2Label);
            this.Controls.Add(this.m_Player1ScoreLabel);
            this.Controls.Add(this.m_Player1Label);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoardGameForm";
            this.Text = "4 in a Row !!";
            this.Load += new System.EventHandler(this.boardGameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel m_ColNumberButtonsTableLayout;
        protected System.Windows.Forms.TableLayoutPanel m_XOButtonsTableLayout;
    }
}