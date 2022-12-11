
namespace Tetris
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.game_field = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.game_field2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.game_field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_field2)).BeginInit();
            this.SuspendLayout();
            // 
            // game_field
            // 
            this.game_field.AllowUserToAddRows = false;
            this.game_field.AllowUserToDeleteRows = false;
            this.game_field.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.game_field.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.game_field.Location = new System.Drawing.Point(2, -26);
            this.game_field.Name = "game_field";
            this.game_field.ReadOnly = true;
            this.game_field.RowTemplate.Height = 25;
            this.game_field.Size = new System.Drawing.Size(240, 363);
            this.game_field.TabIndex = 1;
            this.game_field.SelectionChanged += new System.EventHandler(this.game_field_SelectionChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // game_field2
            // 
            this.game_field2.AllowUserToAddRows = false;
            this.game_field2.AllowUserToDeleteRows = false;
            this.game_field2.BackgroundColor = System.Drawing.Color.Black;
            this.game_field2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.game_field2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.game_field2.Location = new System.Drawing.Point(270, 42);
            this.game_field2.Name = "game_field2";
            this.game_field2.ReadOnly = true;
            this.game_field2.RowTemplate.Height = 25;
            this.game_field2.Size = new System.Drawing.Size(99, 89);
            this.game_field2.TabIndex = 8;
            this.game_field2.SelectionChanged += new System.EventHandler(this.game_field2_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(270, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Score:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(270, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Speed: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(384, 478);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.game_field2);
            this.Controls.Add(this.game_field);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.game_field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_field2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView game_field;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView game_field2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

