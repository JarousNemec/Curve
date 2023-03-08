namespace Krivka
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this._numValuesCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._numValuesCount)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // _numValuesCount
            // 
            this._numValuesCount.Location = new System.Drawing.Point(12, 12);
            this._numValuesCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this._numValuesCount.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            this._numValuesCount.Name = "_numValuesCount";
            this._numValuesCount.Size = new System.Drawing.Size(120, 20);
            this._numValuesCount.TabIndex = 0;
            this._numValuesCount.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._numValuesCount);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this._numValuesCount)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown _numValuesCount;

        private System.Windows.Forms.Timer timer1;

        #endregion
    }
}