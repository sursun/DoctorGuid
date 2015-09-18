using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace DoctorGuid
{
    public class AppButton:Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            GraphicsPath FormPath = new GraphicsPath();

            Rectangle rect = new Rectangle(-1, -1, this.Width + 1, this.Height + 1);//this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 

            FormPath = GetRoundedRectPath(rect, 20);

            this.Region = new Region(FormPath);

        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {

            int diameter = radius;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            GraphicsPath path = new GraphicsPath();

            //   左上角   

            path.AddArc(arcRect, 180, 90);

            //   右上角   

            arcRect.X = rect.Right - diameter;

            path.AddArc(arcRect, 270, 90);

            //   右下角   

            arcRect.Y = rect.Bottom - diameter;

            path.AddArc(arcRect, 0, 90);

            //   左下角   

            arcRect.X = rect.Left;

            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();

            return path;

        }
    }
}
