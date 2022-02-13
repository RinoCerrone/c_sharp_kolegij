using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace c_sharp_kolegij
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        Point LocationXY;
        Point LocationX1Y1;
        bool IsMouseDown = false;
        List<Rectangle> rectangles = new List<Rectangle>();
        public Form1()
        {
            InitializeComponent();
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            IsMouseDown = true;
            LocationXY = e.Location;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;
                Invalidate();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;
                IsMouseDown = false;
                rectangles.Add(GetRect());
            }

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //foreach po svim prakoutnicima i iscrtati ih

            foreach (Rectangle item in rectangles) {
                if (rect != Rectangle.Empty)
                {
                    e.Graphics.DrawRectangle(Pens.Red, GetRect());
                }
            }
            
        }


        private Rectangle GetRect()
        {
            rect = new Rectangle();
            rect.X = Math.Min(LocationXY.X, LocationX1Y1.X);
            rect.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y);
            rect.Width = Math.Abs(LocationXY.X - LocationX1Y1.X);
            rect.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);
            return rect;


        }

        
    }
}

