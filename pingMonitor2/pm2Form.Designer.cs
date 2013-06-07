namespace pingMonitor2
{
    partial class pm2Form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMonitor = new System.Windows.Forms.TabPage();
            this.realtimeOutput = new System.Windows.Forms.TextBox();
            this.pageStats = new System.Windows.Forms.TabPage();
            this.pageGraph = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1.SuspendLayout();
            this.pageMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageMonitor);
            this.tabControl1.Controls.Add(this.pageStats);
            this.tabControl1.Controls.Add(this.pageGraph);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(698, 327);
            this.tabControl1.TabIndex = 0;
            // 
            // pageMonitor
            // 
            this.pageMonitor.Controls.Add(this.realtimeOutput);
            this.pageMonitor.Location = new System.Drawing.Point(4, 22);
            this.pageMonitor.Name = "pageMonitor";
            this.pageMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.pageMonitor.Size = new System.Drawing.Size(690, 301);
            this.pageMonitor.TabIndex = 0;
            this.pageMonitor.Text = "Monitor";
            this.pageMonitor.UseVisualStyleBackColor = true;
            // 
            // realtimeOutput
            // 
            this.realtimeOutput.BackColor = System.Drawing.SystemColors.Window;
            this.realtimeOutput.Location = new System.Drawing.Point(7, 4);
            this.realtimeOutput.Multiline = true;
            this.realtimeOutput.Name = "realtimeOutput";
            this.realtimeOutput.ReadOnly = true;
            this.realtimeOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.realtimeOutput.Size = new System.Drawing.Size(677, 291);
            this.realtimeOutput.TabIndex = 0;
            // 
            // pageStats
            // 
            this.pageStats.Location = new System.Drawing.Point(4, 22);
            this.pageStats.Name = "pageStats";
            this.pageStats.Padding = new System.Windows.Forms.Padding(3);
            this.pageStats.Size = new System.Drawing.Size(690, 301);
            this.pageStats.TabIndex = 1;
            this.pageStats.Text = "Statistik";
            this.pageStats.UseVisualStyleBackColor = true;
            // 
            // pageGraph
            // 
            this.pageGraph.Location = new System.Drawing.Point(4, 22);
            this.pageGraph.Name = "pageGraph";
            this.pageGraph.Size = new System.Drawing.Size(690, 301);
            this.pageGraph.TabIndex = 2;
            this.pageGraph.Text = "Graph";
            this.pageGraph.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(590, 343);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Beenden";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.quit);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(723, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pm2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 401);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabControl1);
            this.Name = "pm2Form";
            this.Text = "PingMonitor 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cleanup);
            this.tabControl1.ResumeLayout(false);
            this.pageMonitor.ResumeLayout(false);
            this.pageMonitor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageMonitor;
        private System.Windows.Forms.TabPage pageStats;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage pageGraph;
        private System.Windows.Forms.TextBox realtimeOutput;
    }
}

