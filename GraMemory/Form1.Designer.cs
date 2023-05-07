
namespace GraMemory
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCzasWartośc = new System.Windows.Forms.Label();
            this.lblPunktyWartośc = new System.Windows.Forms.Label();
            this.lblSTartInfo = new System.Windows.Forms.Label();
            this.panelGry = new System.Windows.Forms.Panel();
            this.timerZakrywacz = new System.Windows.Forms.Timer(this.components);
            this.timerCzasGry = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Czas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(193, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Punkty:";
            // 
            // lblCzasWartośc
            // 
            this.lblCzasWartośc.AutoSize = true;
            this.lblCzasWartośc.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCzasWartośc.Location = new System.Drawing.Point(117, 23);
            this.lblCzasWartośc.Name = "lblCzasWartośc";
            this.lblCzasWartośc.Size = new System.Drawing.Size(30, 35);
            this.lblCzasWartośc.TabIndex = 2;
            this.lblCzasWartośc.Text = "0";
            // 
            // lblPunktyWartośc
            // 
            this.lblPunktyWartośc.AutoSize = true;
            this.lblPunktyWartośc.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPunktyWartośc.Location = new System.Drawing.Point(299, 23);
            this.lblPunktyWartośc.Name = "lblPunktyWartośc";
            this.lblPunktyWartośc.Size = new System.Drawing.Size(30, 35);
            this.lblPunktyWartośc.TabIndex = 3;
            this.lblPunktyWartośc.Text = "0";
            // 
            // lblSTartInfo
            // 
            this.lblSTartInfo.AutoSize = true;
            this.lblSTartInfo.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSTartInfo.Location = new System.Drawing.Point(426, 23);
            this.lblSTartInfo.Name = "lblSTartInfo";
            this.lblSTartInfo.Size = new System.Drawing.Size(221, 35);
            this.lblSTartInfo.TabIndex = 4;
            this.lblSTartInfo.Text = "Czas do startu: 0";
            // 
            // panelGry
            // 
            this.panelGry.Location = new System.Drawing.Point(39, 73);
            this.panelGry.Name = "panelGry";
            this.panelGry.Size = new System.Drawing.Size(1149, 506);
            this.panelGry.TabIndex = 7;
            // 
            // timerZakrywacz
            // 
            this.timerZakrywacz.Interval = 3000;
            this.timerZakrywacz.Tick += new System.EventHandler(this.timerZakrywacz_Tick);
            // 
            // timerCzasGry
            // 
            this.timerCzasGry.Interval = 1000;
            this.timerCzasGry.Tick += new System.EventHandler(this.timerCzasGry_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 671);
            this.Controls.Add(this.panelGry);
            this.Controls.Add(this.lblSTartInfo);
            this.Controls.Add(this.lblPunktyWartośc);
            this.Controls.Add(this.lblCzasWartośc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Gra Memory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCzasWartośc;
        private System.Windows.Forms.Label lblPunktyWartośc;
        private System.Windows.Forms.Label lblSTartInfo;
        private System.Windows.Forms.Panel panelGry;
        private System.Windows.Forms.Timer timerZakrywacz;
        private System.Windows.Forms.Timer timerCzasGry;
    }
}

