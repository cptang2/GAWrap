namespace GAWrap.VNC
{
    partial class VNCWindow
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
            this.rd = new VncSharp.RemoteDesktop();
            this.SuspendLayout();
            // 
            // rd
            // 
            this.rd.AutoScroll = true;
            this.rd.AutoScrollMinSize = new System.Drawing.Size(608, 427);
            this.rd.Location = new System.Drawing.Point(0, 0);
            this.rd.Name = "rd";
            this.rd.Size = new System.Drawing.Size(757, 598);
            this.rd.TabIndex = 0;
            this.rd.ConnectComplete += new VncSharp.ConnectCompleteHandler(this.rd_ConnectComplete);
            this.rd.ConnectionLost += new System.EventHandler(this.rd_ConnectionLost);
            // 
            // VNCWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 598);
            this.Controls.Add(this.rd);
            this.Name = "VNCWindow";
            this.Text = "VNCWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private VncSharp.RemoteDesktop rd;

    }
}