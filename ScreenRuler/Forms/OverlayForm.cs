using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenRuler
{
    /// <summary>
    /// Provides an overlay over the screen that allows the selection of a window.
    /// </summary>
    [DesignerCategory("")]
    class OverlayForm : Form
    {
        private bool transp = false;

        public Rectangle WindowSelection { get; private set; }
        public Color SelectionColor { get; set; } = Color.Red;

        public OverlayForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.BackColor = Color.White;
            this.Opacity = 0.15;
            this.DoubleBuffered = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Cursor = Cursors.Cross;
            this.Location = SystemInformation.VirtualScreen.Location;
            this.Size = SystemInformation.VirtualScreen.Size;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84) //WM_NCHITTEST (called in response to WindowFromPoint)
            {
                // Set HTTRANSPARENT as result to ignore this window in WindowFromPoint.
                if (transp)
                {
                    m.Result = (IntPtr)(-1);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            base.OnKeyDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            try
            {
                var point = PointToScreen(e.Location);
                transp = true;
                WindowSelection = WinApi.GetWindowRectangle(point);
                transp = false;
                this.Invalidate();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            using (var brush = new SolidBrush(SelectionColor))
            {
                e.Graphics.FillRectangle(brush, RectangleToClient(WindowSelection));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (WindowSelection != null)
                this.DialogResult = DialogResult.OK;
            else this.DialogResult = DialogResult.Cancel;
        }
    }
}
