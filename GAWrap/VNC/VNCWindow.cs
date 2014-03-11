using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VncSharp;

// VNC Client code and dll modified from https://cdot.senecacollege.ca/projects/vncsharp/

namespace GAWrap.VNC
{
    public partial class VNCWindow : Form
    {
        private bool viewOnly = false;
        private bool scaledView = true;

        public VNCWindow()
        {
            InitializeComponent();

            // Display scales incoming bitmaps to the size needed
            rd.SetScalingMode(true);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // If the user tries to close the window without doing a clean
            // shutdown of the remote connection, do it for them.
            if (rd.IsConnected)
                rd.Disconnect();

            base.OnClosing(e);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get a host name from the user.
            string host = ConnectDialog.GetVncHost();

            // As long as they didn't click Cancel, try to connect
            if (host != null)
            {
                try
                {
                    rd.Connect(host, viewOnly, scaledView);
                }
                catch (VncProtocolException vex)
                {
                    MessageBox.Show(this,
                                    string.Format("Unable to connect to VNC host:\n\n{0}.\n\nCheck that a VNC host is running there.", vex.Message),
                                    string.Format("Unable to Connect to {0}", host),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                                    string.Format("Unable to connect to host.  Error was: {0}", ex.Message),
                                    string.Format("Unable to Connect to {0}", host),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rd.IsConnected)
                rd.Disconnect();
        }

        private void fullScreenRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Request a fullscreen update (normally incremental updates are sent)
            if (rd.IsConnected)
                rd.FullScreenUpdate();
        }

        private void viewOnlyToolStripMenuItem_Click(bool view)
        {
            // Turn view-only mode (no mouse/keyboard events sent) on or off
            if (rd.IsConnected)
                rd.SetInputMode(view);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Copy the contents of the local clipboard into the server's clipboard
            // so that it can be pasted.  Only works with text.
            if (rd.IsConnected)
            {
                rd.FillServerClipboard();

                MessageBox.Show(this,
                                "Your clipboard's text was copied to the remote host.",
                                "Clipboard Copied",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            }
        }

        private void rd_ConnectComplete(object sender, ConnectEventArgs e)
        {
            // Update the Form to match the geometry of remote desktop (including the height of the menu bar in this form).
            ClientSize = new Size(e.DesktopWidth, e.DesktopHeight);

            // Change the Form's title to match the remote desktop name
            Text = e.DesktopName;

            // Give the remote desktop focus now that it's connected
            rd.Focus();
        }

        private void rd_ConnectionLost(object sender, EventArgs e)
        {
            // Let the user know of the lost connection
            MessageBox.Show(this,
                            "Lost Connection to Host.",
                            "Connection Lost",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void rd_ClipboardChanged(object sender, EventArgs e)
        {
            // You normally wouldn't do this (i.e., you might show something in the status bar),
            // but as a demo, let the user know that there is new data in the local clipboard
            MessageBox.Show(this,
                            "Remote clipboard copied to local host.",
                            "Clipboard Changed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}
