namespace FigurePropertyView
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
            this.btCount = new System.Windows.Forms.Button();
            this.FigureList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MethodList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ParamValues = new System.Windows.Forms.GroupBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCount
            // 
            this.btCount.Location = new System.Drawing.Point(329, 220);
            this.btCount.Name = "btCount";
            this.btCount.Size = new System.Drawing.Size(75, 23);
            this.btCount.TabIndex = 0;
            this.btCount.Text = "Расчитать";
            this.btCount.UseVisualStyleBackColor = true;
            this.btCount.Click += new System.EventHandler(this.btCount_Click);
            // 
            // FigureList
            // 
            this.FigureList.FormattingEnabled = true;
            this.FigureList.Location = new System.Drawing.Point(8, 28);
            this.FigureList.Name = "FigureList";
            this.FigureList.Size = new System.Drawing.Size(153, 186);
            this.FigureList.TabIndex = 2;
            this.FigureList.Click += new System.EventHandler(this.FigureList_Click);
            this.FigureList.SelectedIndexChanged += new System.EventHandler(this.FigureList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фигуры";
            // 
            // MethodList
            // 
            this.MethodList.FormattingEnabled = true;
            this.MethodList.Location = new System.Drawing.Point(167, 28);
            this.MethodList.Name = "MethodList";
            this.MethodList.Size = new System.Drawing.Size(156, 186);
            this.MethodList.TabIndex = 4;
            this.MethodList.SelectedIndexChanged += new System.EventHandler(this.MethodList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Функции";
            // 
            // ParamValues
            // 
            this.ParamValues.Location = new System.Drawing.Point(329, 28);
            this.ParamValues.Name = "ParamValues";
            this.ParamValues.Size = new System.Drawing.Size(470, 186);
            this.ParamValues.TabIndex = 6;
            this.ParamValues.TabStop = false;
            this.ParamValues.Text = "Параметры";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(508, 220);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(291, 20);
            this.tbResult.TabIndex = 7;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(443, 225);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(59, 13);
            this.lbResult.TabIndex = 8;
            this.lbResult.Text = "Результат";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 302);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.ParamValues);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MethodList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FigureList);
            this.Controls.Add(this.btCount);
            this.Name = "Form1";
            this.Text = "Свойства фигур";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCount;
        private System.Windows.Forms.ListBox FigureList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox MethodList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox ParamValues;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label lbResult;
    }
}

