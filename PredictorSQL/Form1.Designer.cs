namespace PredictorSQL
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
            label1 = new Label();
            txtEntrada = new TextBox();
            labelsug = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 9);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 0;
            label1.Text = "Escribe tu consulta";
            // 
            // txtEntrada
            // 
            txtEntrada.Location = new Point(27, 32);
            txtEntrada.Name = "txtEntrada";
            txtEntrada.Size = new Size(815, 27);
            txtEntrada.TabIndex = 1;
            txtEntrada.TextChanged += txtEntrada_TextChanged_1;
            // 
            // labelsug
            // 
            labelsug.AutoSize = true;
            labelsug.ForeColor = SystemColors.ActiveBorder;
            labelsug.Location = new Point(32, 65);
            labelsug.Name = "labelsug";
            labelsug.Size = new Size(138, 20);
            labelsug.TabIndex = 2;
            labelsug.Text = "\"texto para sugerir\"";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 207);
            Controls.Add(labelsug);
            Controls.Add(txtEntrada);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEntrada;
        private Label labelsug;
    }
}
