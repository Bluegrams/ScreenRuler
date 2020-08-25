using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ScreenRuler
{
    public class MouseTracker
    {
        Thread thread;

        public Point Position { get; private set; }

        public event EventHandler Tick;

        public MouseTracker(Form form, int ticks = 50)
        {
            thread = new Thread(() =>
            {
                while (true)
                {
                    if (form.IsHandleCreated)
                    {
                        form.Invoke(new MethodInvoker(() => {
                            if (form.Bounds.Contains(Cursor.Position))
                            {
                                this.Position = form.PointToClient(Cursor.Position);
                                form.Invalidate();
                            }
                            Tick?.Invoke(this, EventArgs.Empty);
                        }));
                    }
                    Thread.Sleep(ticks);
                }
            });
            thread.IsBackground = true;
        }

        public void Start() => thread.Start();

        public void Stop()
        {
            thread.Abort();
        }
    }
}
