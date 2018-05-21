namespace Reg
{
    partial class GameForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.nameLabel = new System.Windows.Forms.Label();
			this.datagv = new System.Windows.Forms.DataGridView();
			this.newgame_btn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.datagv)).BeginInit();
			this.SuspendLayout();
			// 
			// nameLabel
			// 
			this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameLabel.Location = new System.Drawing.Point(0, 0);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(571, 26);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "label1";
			this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// datagv
			// 
			this.datagv.AllowUserToAddRows = false;
			this.datagv.AllowUserToResizeColumns = false;
			this.datagv.AllowUserToResizeRows = false;
			this.datagv.ColumnHeadersHeight = 4;
			this.datagv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.datagv.ColumnHeadersVisible = false;
			this.datagv.Location = new System.Drawing.Point(12, 71);
			this.datagv.Name = "datagv";
			this.datagv.ReadOnly = true;
			this.datagv.RowHeadersVisible = false;
			this.datagv.RowTemplate.Height = 24;
			this.datagv.Size = new System.Drawing.Size(547, 584);
			this.datagv.StandardTab = true;
			this.datagv.TabIndex = 1;
			this.datagv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagv_CellClick);
			// 
			// newgame_btn
			// 
			this.newgame_btn.Location = new System.Drawing.Point(12, 29);
			this.newgame_btn.Name = "newgame_btn";
			this.newgame_btn.Size = new System.Drawing.Size(122, 36);
			this.newgame_btn.TabIndex = 2;
			this.newgame_btn.Text = "Start new game";
			this.newgame_btn.UseVisualStyleBackColor = true;
			this.newgame_btn.Click += new System.EventHandler(this.newgame_btn_Click);
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(571, 667);
			this.Controls.Add(this.newgame_btn);
			this.Controls.Add(this.datagv);
			this.Controls.Add(this.nameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "GameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Кликомания";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
			this.Load += new System.EventHandler(this.RegForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.datagv)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.DataGridView datagv;
        private System.Windows.Forms.Button newgame_btn;
    }
}

