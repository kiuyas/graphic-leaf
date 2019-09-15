using System;
using System.Drawing;

namespace LeafTest1
{
    class LeafDrawer
    {
        private static readonly Pen GRID_COLOR = Pens.DarkBlue;

        private static readonly Pen LEAF_COLOR1 = Pens.SandyBrown;
        private static readonly Pen LEAF_COLOR2 = Pens.RosyBrown;

        private static Graphics g;
        public static void Paint(Graphics g)
        {
            LeafDrawer.g = g;
            //DrawGrid();
            DrawLeaf();
        }

        private static void DrawGrid()
        {
            for (int i = 0; i < 640; i += 8)
            {
                g.DrawLine(GRID_COLOR, i, 0, i, 480);
            }

            for (int i = 0; i < 480; i += 8)
            {
                g.DrawLine(GRID_COLOR, 0, i, 640, i);
            }
        }

        private const int R = 100;

        private static void DrawLeaf()
        {
            DrawLeafSub(0, 3.14, 0.2, 1, LEAF_COLOR1);
            DrawLeafSub(0, 3.14, 0.2, -1, LEAF_COLOR2);
        }

        private static void DrawLeafSub(double t1, double t2, double d, int direction, Pen p)
        {
            double z = 0.2;
            double r = R * z;
            double dr = R * (1 - z) / (3.14 / 0.2);
            double ddr = R * 0.002;
            double x2 = 320 + r * 2;
            double y2 = 240;

            double ox = x2;
            double oy = y2;

            for (double theta1 = t1; theta1 <= t2; theta1 += d)
            {
                double theta = theta1 * direction;
                double x = Math.Cos(theta) * r * 2 + 320;
                double y = 480 - (Math.Sin(theta) * r + 240);

                g.DrawLine(p, (float)x, (float)y, (float)x2, (float)y2);
                g.DrawLine(p, (float)ox, (float)oy, (float)x, (float)y);
                x2 -= 200 / (3.14 / 0.2) / 2;

                r += dr;
                dr += ddr;
                ox = x;
                oy = y;

                if (theta1 < t2 && theta1 + d > t2)
                {
                    theta1 = 3.14 - d;
                    r += dr;
                }
            }

            r = R * z;
            x2 = 320 + r * 2;
            y2 = 240;
            g.DrawLine(p, (float)ox, (float)oy, (float)x2, (float)y2);
        }
    }
}
