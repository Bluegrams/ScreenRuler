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

        public MouseTracker(Form form, int ticks = 50)
        {
            thread = new Thread(() =>
            {
                while (true)
                {
                    if (form.Bounds.Contains(Cursor.Position))
                    {
                        form.Invoke(new MethodInvoker(() => {

                            this.Position = form.PointToClient(Cursor.Position);
                        }));
                        form.Invalidate();
                    }
                    Thread.Sleep(ticks);
                }
            });
        }

        public void Start() => thread.Start();

        public void Stop()
        {
            thread.Abort();
        }
    }
}
