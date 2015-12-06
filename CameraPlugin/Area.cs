using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

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

        public static XYZ max(XYZ p1, XYZ p2)
        {
            double retx = p1.X;
            double rety = p1.Y;
            double retz = p1.Z;

            if (p2.X > p1.X) retx = p2.X;
            if (p2.Y > p1.Y) rety = p2.Y;
            if (p2.Z > p1.Z) retz = p2.Z;

            return new XYZ(retx, rety, retz);
        }

        public static XYZ min(XYZ p1, XYZ p2)
        {
            double retx = p1.X;
            double rety = p1.Y;
            double retz = p1.Z;

            if (p2.X < p1.X) retx = p2.X;
            if (p2.Y < p1.Y) rety = p2.Y;
            if (p2.Z < p1.Z) retz = p2.Z;

            return new XYZ(retx, rety, retz);
        }
    }
}
