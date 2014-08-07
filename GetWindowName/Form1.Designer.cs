namespace GetWindowName
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
            this.lblWindowName = new System.Windows.Forms.Label();
            this.lblWindowBounds = new System.Windows.Forms.Label();
            this.lblMousePos = new System.Windows.Forms.Label();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.lblMainWindow = new System.Windows.Forms.Label();
            this.lblVisibleWindows = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWindowBoundsTracking = new System.Windows.Forms.Label();
            this.lblWindowNameTracking = new System.Windows.Forms.Label();
            this.lblMainWindowTracking = new System.Windows.Forms.Label();
            this.lblProcessNameTracking = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRaise = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWindowName
            // 
            this.lblWindowName.AutoSize = true;
            this.lblWindowName.Location = new System.Drawing.Point(12, 8);
            this.lblWindowName.Name = "lblWindowName";
            this.lblWindowName.Size = new System.Drawing.Size(35, 13);
            this.lblWindowName.TabIndex = 0;
            this.lblWindowName.Text = "label1";
            // 
            // lblWindowBounds
            // 
            this.lblWindowBounds.AutoSize = true;
            this.lblWindowBounds.Location = new System.Drawing.Point(12, 29);
            this.lblWindowBounds.Name = "lblWindowBounds";
            this.lblWindowBounds.Size = new System.Drawing.Size(35, 13);
            this.lblWindowBounds.TabIndex = 1;
            this.lblWindowBounds.Text = "label2";
            // 
            // lblMousePos
            // 
            this.lblMousePos.AutoSize = true;
            this.lblMousePos.Location = new System.Drawing.Point(13, 50);
            this.lblMousePos.Name = "lblMousePos";
            this.lblMousePos.Size = new System.Drawing.Size(35, 13);
            this.lblMousePos.TabIndex = 2;
            this.lblMousePos.Text = "label1";
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Location = new System.Drawing.Point(13, 71);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(35, 13);
            this.lblProcessName.TabIndex = 3;
            this.lblProcessName.Text = "label2";
            // 
            // lblMainWindow
            // 
            this.lblMainWindow.AutoSize = true;
            this.lblMainWindow.Location = new System.Drawing.Point(13, 92);
            this.lblMainWindow.Name = "lblMainWindow";
            this.lblMainWindow.Size = new System.Drawing.Size(35, 13);
            this.lblMainWindow.TabIndex = 4;
            this.lblMainWindow.Text = "label1";
            // 
            // lblVisibleWindows
            // 
            this.lblVisibleWindows.AutoSize = true;
            this.lblVisibleWindows.Location = new System.Drawing.Point(13, 113);
            this.lblVisibleWindows.Name = "lblVisibleWindows";
            this.lblVisibleWindows.Size = new System.Drawing.Size(35, 13);
            this.lblVisibleWindows.TabIndex = 5;
            this.lblVisibleWindows.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRaise);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblMainWindowTracking);
            this.panel1.Controls.Add(this.lblProcessNameTracking);
            this.panel1.Controls.Add(this.lblWindowBoundsTracking);
            this.panel1.Controls.Add(this.lblWindowNameTracking);
            this.panel1.Location = new System.Drawing.Point(13, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 110);
            this.panel1.TabIndex = 6;
            // 
            // lblWindowBoundsTracking
            // 
            this.lblWindowBoundsTracking.AutoSize = true;
            this.lblWindowBoundsTracking.Location = new System.Drawing.Point(3, 41);
            this.lblWindowBoundsTracking.Name = "lblWindowBoundsTracking";
            this.lblWindowBoundsTracking.Size = new System.Drawing.Size(35, 13);
            this.lblWindowBoundsTracking.TabIndex = 3;
            this.lblWindowBoundsTracking.Text = "label2";
            // 
            // lblWindowNameTracking
            // 
            this.lblWindowNameTracking.AutoSize = true;
            this.lblWindowNameTracking.Location = new System.Drawing.Point(3, 16);
            this.lblWindowNameTracking.Name = "lblWindowNameTracking";
            this.lblWindowNameTracking.Size = new System.Drawing.Size(35, 13);
            this.lblWindowNameTracking.TabIndex = 2;
            this.lblWindowNameTracking.Text = "label1";
            // 
            // lblMainWindowTracking
            // 
            this.lblMainWindowTracking.AutoSize = true;
            this.lblMainWindowTracking.Location = new System.Drawing.Point(3, 91);
            this.lblMainWindowTracking.Name = "lblMainWindowTracking";
            this.lblMainWindowTracking.Size = new System.Drawing.Size(35, 13);
            this.lblMainWindowTracking.TabIndex = 6;
            this.lblMainWindowTracking.Text = "label1";
            // 
            // lblProcessNameTracking
            // 
            this.lblProcessNameTracking.AutoSize = true;
            this.lblProcessNameTracking.Location = new System.Drawing.Point(3, 66);
            this.lblProcessNameTracking.Name = "lblProcessNameTracking";
            this.lblProcessNameTracking.Size = new System.Drawing.Size(35, 13);
            this.lblProcessNameTracking.TabIndex = 5;
            this.lblProcessNameTracking.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hover over a window and Press ENTER to track";
            // 
            // btnRaise
            // 
            this.btnRaise.Enabled = false;
            this.btnRaise.Location = new System.Drawing.Point(300, 70);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(46, 37);
            this.btnRaise.TabIndex = 8;
            this.btnRaise.Text = "Bring Top";
            this.btnRaise.UseVisualStyleBackColor = true;
            this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(374, 252);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblVisibleWindows);
            this.Controls.Add(this.lblMainWindow);
            this.Controls.Add(this.lblProcessName);
            this.Controls.Add(this.lblMousePos);
            this.Controls.Add(this.lblWindowBounds);
            this.Controls.Add(this.lblWindowName);
            this.MaximumSize = new System.Drawing.Size(382, 500);
            this.MinimumSize = new System.Drawing.Size(382, 171);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWindowName;
        private System.Windows.Forms.Label lblWindowBounds;
        private System.Windows.Forms.Label lblMousePos;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Label lblMainWindow;
        private System.Windows.Forms.Label lblVisibleWindows;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMainWindowTracking;
        private System.Windows.Forms.Label lblProcessNameTracking;
        private System.Windows.Forms.Label lblWindowBoundsTracking;
        private System.Windows.Forms.Label lblWindowNameTracking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRaise;
    }
}

