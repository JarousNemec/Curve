using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krivka
{
    public partial class Form1 : Form
    {
        private readonly Stack<float> _y;

        private float _angelC1 = 0;
        private const int C1_SIZE = 150;
        private readonly Point C1_LOCATION;
        private const float C1_ANGLE_PART = 1.6f;
        
        private float _angelC2 = 45;
        private const int C2_SIZE = 100;
        private readonly Point C2_LOCATION;
        private const float C2_ANGLE_PART = 4f;
        
        private float _angelC3 = 90;
        private const int C3_SIZE = 75;
        private readonly Point C3_LOCATION;
        private const float C3_ANGLE_PART = 8f;
        
        private float _angelC4 = 18;
        private const int C4_SIZE = 80;
        private readonly Point C4_LOCATION;
        private const float C4_ANGLE_PART = 10f;
        
        private float _angelC5 = 69;
        private const int C5_SIZE = 120;
        private readonly Point C5_LOCATION;
        private const float C5_ANGLE_PART = 10f;


        private const float CHART_POINT_SIZE = 2;
        private const float CHART_X_PART = 2;
        private const int POINT_SIZE = 5;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _y = new Stack<float>();
            C1_LOCATION = new Point(150, 150);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _angelC1 += C1_ANGLE_PART;
            _angelC2 += C2_ANGLE_PART;
            _angelC3 += C3_ANGLE_PART;
            _angelC4 += C4_ANGLE_PART;
            _angelC5 += C5_ANGLE_PART;
            
            var g = e.Graphics;

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //c1 draw
            g.DrawEllipse(Pens.Red, C1_LOCATION.X, C1_LOCATION.Y, C1_SIZE, C1_SIZE);
            //c1 center point
            var c1Center = new Point(C1_LOCATION.X + C1_SIZE / 2, C1_LOCATION.Y + C1_SIZE / 2);
            // calculate point on c1 by angle
            var pointOnC1 = GetPointByAngle(_angelC1, c1Center, C1_SIZE / 2);
            

            var C2_LOCATION = new PointF(pointOnC1.X-C2_SIZE/2,pointOnC1.Y-C2_SIZE/2);
            g.DrawEllipse(Pens.Chartreuse, C2_LOCATION.X, C2_LOCATION.Y, C2_SIZE, C2_SIZE);
            var pointOnC2 = GetPointByAngle(_angelC2, pointOnC1, C2_SIZE / 2);
            
            var C3_LOCATION = new PointF(pointOnC2.X-C3_SIZE/2,pointOnC2.Y-C3_SIZE/2);
            g.DrawEllipse(Pens.BlueViolet, C3_LOCATION.X, C3_LOCATION.Y, C3_SIZE, C3_SIZE);
            var pointOnC3 = GetPointByAngle(_angelC3, pointOnC2, C3_SIZE / 2);
            
            var C4_LOCATION = new PointF(pointOnC3.X-C4_SIZE/2,pointOnC3.Y-C4_SIZE/2);
            g.DrawEllipse(Pens.Gold, C4_LOCATION.X, C4_LOCATION.Y, C4_SIZE, C4_SIZE);
            var pointOnC4 = GetPointByAngle(_angelC4, pointOnC3, C4_SIZE / 2);
            
            var C5_LOCATION = new PointF(pointOnC4.X-C5_SIZE/2,pointOnC4.Y-C5_SIZE/2);
            g.DrawEllipse(Pens.Brown, C5_LOCATION.X, C5_LOCATION.Y, C5_SIZE, C5_SIZE);
            var pointOnC5 = GetPointByAngle(_angelC5, pointOnC4, C5_SIZE / 2);
            
            _y.Push(pointOnC5.Y); 
            
            // draw line from center to point on c
            g.DrawLine(Pens.Blue, c1Center, pointOnC1);
            g.DrawLine(Pens.Blue, pointOnC1, pointOnC2);
            g.DrawLine(Pens.Blue, pointOnC2, pointOnC3);
            g.DrawLine(Pens.Blue, pointOnC3, pointOnC4);
            g.DrawLine(Pens.Blue, pointOnC4, pointOnC5);
            
            // draw c1 center
            const int offsetCenterC1 = POINT_SIZE / 2;
            g.FillEllipse(Brushes.Red, c1Center.X - offsetCenterC1, c1Center.Y - offsetCenterC1, POINT_SIZE,
                POINT_SIZE);

            // line start
            float x = c1Center.X + 200;

            // draw x axis
            g.DrawLine(Pens.Black,x, c1Center.Y ,c1Center.X + 600, c1Center.Y);

            float chart_center = CHART_POINT_SIZE / 2;
            
            // draw line to last point on graph
            g.DrawLine(Pens.Blue, pointOnC5, new PointF(x, _y.Peek()));
            
            
            // draw points to graph
            foreach (var y in _y.Take((int)_numValuesCount.Value))
            {
                g.FillEllipse(Brushes.Red, x-chart_center,y-chart_center, CHART_POINT_SIZE,CHART_POINT_SIZE);
                x += CHART_X_PART;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private PointF GetPointByAngle(float angle, PointF center, int size)
        {
            var rad = angle * (Math.PI / 180);
            var x = center.X + size * Math.Cos(rad);
            var y = center.Y + size * Math.Sin(rad);

            return new PointF((float)x, (float)y);
        }
    }
}