namespace forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Triangle = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Group_radio = new System.Windows.Forms.RadioButton();
            this.Manpulate = new System.Windows.Forms.RadioButton();
            this.Square = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 391);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove_1);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Triangle
            // 
            this.Triangle.AutoSize = true;
            this.Triangle.Location = new System.Drawing.Point(6, 12);
            this.Triangle.Name = "Triangle";
            this.Triangle.Size = new System.Drawing.Size(63, 17);
            this.Triangle.TabIndex = 1;
            this.Triangle.Text = "Triangle";
            this.Triangle.UseVisualStyleBackColor = true;
            this.Triangle.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Group_radio);
            this.groupBox1.Controls.Add(this.Manpulate);
            this.groupBox1.Controls.Add(this.Square);
            this.groupBox1.Controls.Add(this.Triangle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 41);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // Group_radio
            // 
            this.Group_radio.AutoSize = true;
            this.Group_radio.Location = new System.Drawing.Point(223, 12);
            this.Group_radio.Name = "Group_radio";
            this.Group_radio.Size = new System.Drawing.Size(54, 17);
            this.Group_radio.TabIndex = 0;
            this.Group_radio.Text = "Group";
            this.Group_radio.UseVisualStyleBackColor = true;
            this.Group_radio.CheckedChanged += new System.EventHandler(this.Group_radio_CheckedChanged);
            // 
            // Manpulate
            // 
            this.Manpulate.AutoSize = true;
            this.Manpulate.Location = new System.Drawing.Point(140, 12);
            this.Manpulate.Name = "Manpulate";
            this.Manpulate.Size = new System.Drawing.Size(77, 17);
            this.Manpulate.TabIndex = 0;
            this.Manpulate.Text = "Manipulate";
            this.Manpulate.UseVisualStyleBackColor = true;
            this.Manpulate.CheckedChanged += new System.EventHandler(this.Resize_CheckedChanged);
            // 
            // Square
            // 
            this.Square.AutoSize = true;
            this.Square.Location = new System.Drawing.Point(75, 12);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(59, 17);
            this.Square.TabIndex = 2;
            this.Square.Text = "Square";
            this.Square.UseVisualStyleBackColor = true;
            this.Square.CheckedChanged += new System.EventHandler(this.circkle_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Triangle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Square;
        private System.Windows.Forms.RadioButton Manpulate;
        private System.Windows.Forms.RadioButton Group_radio;
    }
}

