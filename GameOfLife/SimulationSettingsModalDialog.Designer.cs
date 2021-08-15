
namespace GameOfLife
{
    partial class SimulationSettingsModalDialog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownUHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownUWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(201, 304);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(283, 304);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(265, 133);
            this.numericUpDownTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTime.TabIndex = 2;
            // 
            // numericUpDownUHeight
            // 
            this.numericUpDownUHeight.Location = new System.Drawing.Point(265, 159);
            this.numericUpDownUHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownUHeight.Name = "numericUpDownUHeight";
            this.numericUpDownUHeight.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownUHeight.TabIndex = 3;
            // 
            // numericUpDownUWidth
            // 
            this.numericUpDownUWidth.Location = new System.Drawing.Point(265, 186);
            this.numericUpDownUWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownUWidth.Name = "numericUpDownUWidth";
            this.numericUpDownUWidth.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownUWidth.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time Interval:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Universe Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Universe Width:";
            // 
            // SimulationSettingsModalDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(559, 339);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownUWidth);
            this.Controls.Add(this.numericUpDownUHeight);
            this.Controls.Add(this.numericUpDownTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimulationSettingsModalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SimulationSettingsModalDialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.NumericUpDown numericUpDownUHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownUWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}