
namespace SnakeGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameScreen = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.labelGameOver = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // gameScreen
            // 
            this.gameScreen.BackColor = System.Drawing.Color.Gray;
            this.gameScreen.Image = ((System.Drawing.Image)(resources.GetObject("gameScreen.Image")));
            this.gameScreen.Location = new System.Drawing.Point(12, 12);
            this.gameScreen.Name = "gameScreen";
            this.gameScreen.Size = new System.Drawing.Size(908, 460);
            this.gameScreen.TabIndex = 0;
            this.gameScreen.TabStop = false;
            this.gameScreen.Click += new System.EventHandler(this.gameScreen_Click);
            this.gameScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.gameScreen_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 492);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Georgia", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(146, 495);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(0, 38);
            this.labelScore.TabIndex = 2;
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.BackColor = System.Drawing.Color.Transparent;
            this.labelGameOver.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGameOver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGameOver.Font = new System.Drawing.Font("Georgia", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameOver.ForeColor = System.Drawing.Color.Black;
            this.labelGameOver.Location = new System.Drawing.Point(132, 54);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(121, 40);
            this.labelGameOver.TabIndex = 3;
            this.labelGameOver.Text = "label2";
            this.labelGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGameOver.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 492);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "HighestScore:";
            // 
            // labelHScore
            // 
            this.labelHScore.AutoSize = true;
            this.labelHScore.Font = new System.Drawing.Font("Georgia", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHScore.Location = new System.Drawing.Point(835, 492);
            this.labelHScore.Name = "labelHScore";
            this.labelHScore.Size = new System.Drawing.Size(0, 38);
            this.labelHScore.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 603);
            this.Controls.Add(this.labelHScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameScreen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHScore;
    }
}

