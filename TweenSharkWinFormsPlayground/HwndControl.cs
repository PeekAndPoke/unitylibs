using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace TweenSharkWinFormsPlayground
{
    class HwndControl
    {
        private readonly IntPtr _hwnd;
        private readonly Point _mainPos;

        private int _x;
        public int X
        {
            get { return _x; }
            set { 
                _x = value;
                Move();
            }
        }
        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                _y = value; 
                Move();
            }
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int X;
            public int Y;
            public int Right;
            public int Bottom;

            public int Width
            {
                get { return Right - X; }
            }

            public int Height
            {
                get { return Bottom - Y; }
            }
        }

        const short SWP_NOMOVE = 0X2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0X4;
        const int SWP_SHOWWINDOW = 0x0040;

        public HwndControl(IntPtr hwnd, Point mainPos)
        {
            _hwnd = hwnd;
            _mainPos = mainPos;
            RECT rect;

            GetWindowRect(_hwnd, out rect);

            X = (int) rect.X;
            Y = (int) rect.Y;

            // Console.WriteLine("x,y " + X + "," + Y);
        }

        private void Move()
        {
            SetWindowPos(_hwnd, 0, (int) (X - _mainPos.X), (int) (Y - _mainPos.Y), 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
        }
    }
}
