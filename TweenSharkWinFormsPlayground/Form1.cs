using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using De.Kjg.TweenSharkPkg;
using De.Kjg.TweenSharkPkg.Logging;
using De.Kjg.TweenSharkPkg.Options;
using Color = System.Drawing.Color;

namespace TweenSharkWinFormsPlayground
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        private Random _random = new Random();

        private int _counter;
        public int Counter { get { return _counter; } set
        {
            _counter = value;  textBox1.Text = _counter.ToString(); } }

        public Form1()
        {
            InitializeComponent();

            TweenShark.Initialize(new TweenSharkWinformsTick(), new ConsoleLogger());
            TweenShark.RegisterPropertyTweener(typeof(ColorTweener), typeof(Color));

            Deactivate += (sender, e) => Destroy(GetForegroundWindow());

            this.Click += (sender, e) =>
            {

            };


//            this.BackgroundImage = Resources.background;
//
//            this.FormBorderStyle = FormBorderStyle.None;
//            this.TransparencyKey = Color.FromArgb(255, 0, 255);


            button1.MouseEnter += HandleButtonMouseEnter;
            button1.MouseLeave += HandleButtonMouseLeave;
            button2.MouseEnter += HandleButtonMouseEnter;
            button2.MouseLeave += HandleButtonMouseLeave;
        }

        private void Destroy(IntPtr hwnd)
        {
            // MessageBox.Show("Destroying", "hwnd " + hwnd);

            var process = Process.GetProcesses().Where(p => p.MainWindowHandle == hwnd).First();
            Console.WriteLine("process " + process);

            if (process == null) return;


            var window = new HwndControl(process.MainWindowHandle, new Point(0, 0));

            TweenShark.To(window, 2F,
                          new TweenOps(Ease.OutBounce)
                          .PropBy("X", _random.Next(100) - 50)
                          .PropBy("Y", _random.Next(100) - 50)
                          );

            var mainPoint = new Point(window.X, window.Y);

            DestroyRecursive(process.MainWindowHandle, mainPoint);
        }

        private void DestroyRecursive(IntPtr hwnd, Point mainPoint, int level = 0, int maxLevel = 3)
        {
            IntPtr child = IntPtr.Zero;

            do
            {
                child = FindWindowEx(hwnd, child, null, null);
                if (child != IntPtr.Zero)
                {
                    TweenShark.To(new HwndControl(child, mainPoint), 2F,
                                  new TweenOps(Ease.OutQuint)
                                  .PropBy("X", _random.Next(100) - 50)
                                  .PropBy("Y", _random.Next(100) - 50)
                                  );

                    if (level < maxLevel)
                    {
                        DestroyRecursive(child, mainPoint, level+1, maxLevel);
                    }
                }
            } while (child != IntPtr.Zero);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var b = (Button) sender;
            //b.
//            TweenShark.To(this, 1, new TweenOps().PropBy("Counter", 100));
            TweenShark.To(this, 1, new TweenOps(Ease.InOutQuint)
                .PropTo("Left", Left < 100 ? 1000 : 0) //Screen.FromControl(this).WorkingArea.Width - Width : 0)
                .OnUpdate(tween => Counter = Left)
            );
        }

        private void button1_MouseOver(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HandleButtonMouseEnter(object sender, EventArgs e)
        {
            var b = (Button)sender;
            TweenShark.To(b, 0.2F, new TweenOps(Ease.OutQuad)
//                .PropTo("Left", b.Left < 100 ? 200 : 50)
                .PropTo("BackColor", Color.FromArgb(200, 255, 0, 0))
            );
        }

        private void HandleButtonMouseLeave(object sender, EventArgs e)
        {
            var b = (Button)sender;
//            b.BackColor = null;
            TweenShark.To(b, 0.2F, new TweenOps(Ease.OutQuad)
                .PropTo("BackColor", Color.FromArgb(0, 255, 255, 255))
            );
            //b.BackColor = Color.FromArgb()
        }

    }
}
