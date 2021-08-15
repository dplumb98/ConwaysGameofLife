
namespace GameOfLife
{
    partial class ColorsModalDialog
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
            this.buttonBC = new System.Windows.Forms.Button();
            this.buttonGC = new System.Windows.Forms.Button();
            this.buttonCC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(232, 317);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(314, 317);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonBC
            // 
            this.buttonBC.Location = new System.Drawing.Point(254, 135);
            this.buttonBC.Name = "buttonBC";
            this.buttonBC.Size = new System.Drawing.Size(113, 23);
            this.buttonBC.TabIndex = 2;
            this.buttonBC.Text = "Background Color";
            this.buttonBC.UseVisualStyleBackColor = true;
            this.buttonBC.Click += new System.EventHandler(this.buttonBC_Click);
            // 
            // buttonGC
            // 
            this.buttonGC.Location = new System.Drawing.Point(254, 164);
            this.buttonGC.Name = "buttonGC";
            this.buttonGC.Size = new System.Drawing.Size(113, 23);
            this.buttonGC.TabIndex = 3;
            this.buttonGC.Text = "Grid Color";
            this.buttonGC.UseVisualStyleBackColor = true;
            this.buttonGC.Click += new System.EventHandler(this.buttonGC_Click);
            // 
            // buttonCC
            // 
            this.buttonCC.Location = new System.Drawing.Point(254, 194);
            this.buttonCC.Name = "buttonCC";
            this.buttonCC.Size = new System.Drawing.Size(113, 23);
            this.buttonCC.TabIndex = 4;
            this.buttonCC.Text = "Cell Color";
            this.buttonCC.UseVisualStyleBackColor = true;
            this.buttonCC.Click += new System.EventHandler(this.buttonCC_Click);
            // 
            // ColorsModalDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 352);
            this.Controls.Add(this.buttonCC);
            this.Controls.Add(this.buttonGC);
            this.Controls.Add(this.buttonBC);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorsModalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ColorsModalDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonBC;
        private System.Windows.Forms.Button buttonGC;
        private System.Windows.Forms.Button buttonCC;
    }
}