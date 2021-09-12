
namespace ConsoleUI
{
    partial class GameSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label m_PlayersLabel;
        private System.Windows.Forms.Label m_Player1Label;
        private System.Windows.Forms.CheckBox m_Player2CheckBox;
        private System.Windows.Forms.TextBox m_Player2TextBox;
        private System.Windows.Forms.TextBox m_Player1TextBox;
        private System.Windows.Forms.Label m_BoardSizeLabel;
        private System.Windows.Forms.Label m_RowsLabel;
        private System.Windows.Forms.NumericUpDown m_RowsUpDown;
        private System.Windows.Forms.NumericUpDown m_ColumnsUpDown;
        private System.Windows.Forms.Label m_ColumnsLabel;
        private System.Windows.Forms.Button m_StartGameButton;

        public string Player1TextBox
        {
            get => m_Player1TextBox.Text;
        }

        public string Player2TextBox
        {
            get => m_Player2TextBox.Text;
        }

        public bool Player2CheckBox
        {
            get => m_Player2CheckBox.Checked;
        }

        public int RowsUpDown
        {
            get => (int)m_RowsUpDown.Value;
        }

        public int ColumnsUpDown
        {
            get => (int)m_ColumnsUpDown.Value;
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
            this.m_PlayersLabel = new System.Windows.Forms.Label();
            this.m_Player1Label = new System.Windows.Forms.Label();
            this.m_Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.m_Player2TextBox = new System.Windows.Forms.TextBox();
            this.m_Player1TextBox = new System.Windows.Forms.TextBox();
            this.m_BoardSizeLabel = new System.Windows.Forms.Label();
            this.m_RowsLabel = new System.Windows.Forms.Label();
            this.m_RowsUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_ColumnsUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_ColumnsLabel = new System.Windows.Forms.Label();
            this.m_StartGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColumnsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // m_PlayersLabel
            // 
            this.m_PlayersLabel.AllowDrop = true;
            this.m_PlayersLabel.AutoSize = true;
            this.m_PlayersLabel.Location = new System.Drawing.Point(42, 40);
            this.m_PlayersLabel.Name = "m_PlayersLabel";
            this.m_PlayersLabel.Size = new System.Drawing.Size(118, 32);
            this.m_PlayersLabel.TabIndex = 0;
            this.m_PlayersLabel.Text = "Players:";
            // 
            // m_Player1Label
            // 
            this.m_Player1Label.AutoSize = true;
            this.m_Player1Label.Location = new System.Drawing.Point(79, 102);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(127, 32);
            this.m_Player1Label.TabIndex = 1;
            this.m_Player1Label.Text = "Player 1:";
            // 
            // m_Player2CheckBox
            // 
            this.m_Player2CheckBox.AutoSize = true;
            this.m_Player2CheckBox.Location = new System.Drawing.Point(85, 160);
            this.m_Player2CheckBox.Name = "m_Player2CheckBox";
            this.m_Player2CheckBox.Size = new System.Drawing.Size(165, 36);
            this.m_Player2CheckBox.TabIndex = 2;
            this.m_Player2CheckBox.Text = "Player 2:";
            this.m_Player2CheckBox.UseVisualStyleBackColor = true;
            // 
            // m_Player2TextBox
            // 
            this.m_Player2TextBox.Location = new System.Drawing.Point(275, 159);
            this.m_Player2TextBox.Name = "m_Player2TextBox";
            this.m_Player2TextBox.Size = new System.Drawing.Size(337, 38);
            this.m_Player2TextBox.TabIndex = 3;
            this.m_Player2TextBox.Text = "[Computer]";
            // 
            // m_Player1TextBox
            // 
            this.m_Player1TextBox.Location = new System.Drawing.Point(275, 102);
            this.m_Player1TextBox.Name = "m_Player1TextBox";
            this.m_Player1TextBox.Size = new System.Drawing.Size(337, 38);
            this.m_Player1TextBox.TabIndex = 4;
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.AllowDrop = true;
            this.m_BoardSizeLabel.AutoSize = true;
            this.m_BoardSizeLabel.Location = new System.Drawing.Point(42, 268);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new System.Drawing.Size(162, 32);
            this.m_BoardSizeLabel.TabIndex = 5;
            this.m_BoardSizeLabel.Text = "Board Size:";
            // 
            // m_RowsLabel
            // 
            this.m_RowsLabel.AutoSize = true;
            this.m_RowsLabel.Location = new System.Drawing.Point(85, 334);
            this.m_RowsLabel.Name = "m_RowsLabel";
            this.m_RowsLabel.Size = new System.Drawing.Size(93, 32);
            this.m_RowsLabel.TabIndex = 6;
            this.m_RowsLabel.Text = "Rows:";
            // 
            // m_RowsUpDown
            // 
            this.m_RowsUpDown.Location = new System.Drawing.Point(196, 332);
            this.m_RowsUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_RowsUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_RowsUpDown.Name = "m_RowsUpDown";
            this.m_RowsUpDown.Size = new System.Drawing.Size(120, 38);
            this.m_RowsUpDown.TabIndex = 7;
            this.m_RowsUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_ColumnsUpDown
            // 
            this.m_ColumnsUpDown.Location = new System.Drawing.Point(492, 332);
            this.m_ColumnsUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_ColumnsUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_ColumnsUpDown.Name = "m_ColumnsUpDown";
            this.m_ColumnsUpDown.Size = new System.Drawing.Size(120, 38);
            this.m_ColumnsUpDown.TabIndex = 9;
            this.m_ColumnsUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_ColumnsLabel
            // 
            this.m_ColumnsLabel.AutoSize = true;
            this.m_ColumnsLabel.Location = new System.Drawing.Point(381, 334);
            this.m_ColumnsLabel.Name = "m_ColumnsLabel";
            this.m_ColumnsLabel.Size = new System.Drawing.Size(80, 32);
            this.m_ColumnsLabel.TabIndex = 8;
            this.m_ColumnsLabel.Text = "Cols:";
            // 
            // m_StartGameButton
            // 
            this.m_StartGameButton.Location = new System.Drawing.Point(48, 407);
            this.m_StartGameButton.Name = "m_StartGameButton";
            this.m_StartGameButton.Size = new System.Drawing.Size(564, 54);
            this.m_StartGameButton.TabIndex = 10;
            this.m_StartGameButton.Text = "Start!";
            this.m_StartGameButton.UseVisualStyleBackColor = true;
            // 
            // GameSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 516);
            this.Controls.Add(this.m_StartGameButton);
            this.Controls.Add(this.m_ColumnsUpDown);
            this.Controls.Add(this.m_ColumnsLabel);
            this.Controls.Add(this.m_RowsUpDown);
            this.Controls.Add(this.m_RowsLabel);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.Controls.Add(this.m_Player1TextBox);
            this.Controls.Add(this.m_Player2TextBox);
            this.Controls.Add(this.m_Player2CheckBox);
            this.Controls.Add(this.m_Player1Label);
            this.Controls.Add(this.m_PlayersLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingForm";
            this.Text = "GameSettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColumnsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}