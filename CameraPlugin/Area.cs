using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraPlugin
{
    class Area
    {
        public static double calc(PointF[] pfs)
        {
            int i, j;
            double area = 0;

            for (i = 0; i < pfs.Length; i++)
            {
                j = (i + 1) % pfs.Length;

                area += pfs[i].X * pfs[j].Y;
                area -= pfs[i].Y * pfs[j].X;
            }

            area /= 2;
            return (area < 0 ? -area : area);
        }
    }
}
