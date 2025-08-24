namespace Lesson_5_1_Graphics
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_LoadPicture = new System.Windows.Forms.Button();
            this.bt_ShowOne = new System.Windows.Forms.Button();
            this.tb_InsertID = new System.Windows.Forms.TextBox();
            this.bt_ShowAll = new System.Windows.Forms.Button();
            this.dgv_ShowData = new System.Windows.Forms.DataGridView();
            this.pb_ShowPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_LoadPicture
            // 
            this.bt_LoadPicture.Location = new System.Drawing.Point(22, 28);
            this.bt_LoadPicture.Name = "bt_LoadPicture";
            this.bt_LoadPicture.Size = new System.Drawing.Size(150, 40);
            this.bt_LoadPicture.TabIndex = 0;
            this.bt_LoadPicture.Text = "Load Picture";
            this.bt_LoadPicture.UseVisualStyleBackColor = true;
            this.bt_LoadPicture.Click += new System.EventHandler(this.bt_LoadPicture_Click);
            // 
            // bt_ShowOne
            // 
            this.bt_ShowOne.Location = new System.Drawing.Point(188, 28);
            this.bt_ShowOne.Name = "bt_ShowOne";
            this.bt_ShowOne.Size = new System.Drawing.Size(150, 40);
            this.bt_ShowOne.TabIndex = 1;
            this.bt_ShowOne.Text = "Show one";
            this.bt_ShowOne.UseVisualStyleBackColor = true;
            this.bt_ShowOne.Click += new System.EventHandler(this.bt_ShowOne_Click);
            // 
            // tb_InsertID
            // 
            this.tb_InsertID.Location = new System.Drawing.Point(357, 39);
            this.tb_InsertID.Name = "tb_InsertID";
            this.tb_InsertID.Size = new System.Drawing.Size(150, 20);
            this.tb_InsertID.TabIndex = 2;
            // 
            // bt_ShowAll
            // 
            this.bt_ShowAll.Location = new System.Drawing.Point(530, 28);
            this.bt_ShowAll.Name = "bt_ShowAll";
            this.bt_ShowAll.Size = new System.Drawing.Size(150, 40);
            this.bt_ShowAll.TabIndex = 3;
            this.bt_ShowAll.Text = "Show all";
            this.bt_ShowAll.UseVisualStyleBackColor = true;
            this.bt_ShowAll.Click += new System.EventHandler(this.bt_ShowAll_Click);
            // 
            // dgv_ShowData
            // 
            this.dgv_ShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShowData.Location = new System.Drawing.Point(12, 95);
            this.dgv_ShowData.Name = "dgv_ShowData";
            this.dgv_ShowData.Size = new System.Drawing.Size(379, 321);
            this.dgv_ShowData.TabIndex = 4;
            // 
            // pb_ShowPicture
            // 
            this.pb_ShowPicture.Location = new System.Drawing.Point(397, 95);
            this.pb_ShowPicture.Name = "pb_ShowPicture";
            this.pb_ShowPicture.Size = new System.Drawing.Size(391, 321);
            this.pb_ShowPicture.TabIndex = 5;
            this.pb_ShowPicture.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pb_ShowPicture);
            this.Controls.Add(this.dgv_ShowData);
            this.Controls.Add(this.bt_ShowAll);
            this.Controls.Add(this.tb_InsertID);
            this.Controls.Add(this.bt_ShowOne);
            this.Controls.Add(this.bt_LoadPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_LoadPicture;
        private System.Windows.Forms.Button bt_ShowOne;
        private System.Windows.Forms.TextBox tb_InsertID;
        private System.Windows.Forms.Button bt_ShowAll;
        private System.Windows.Forms.DataGridView dgv_ShowData;
        private System.Windows.Forms.PictureBox pb_ShowPicture;
    }
}

