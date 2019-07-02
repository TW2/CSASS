using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.ASSNeo
{
    public class Character
    {
        private List<PointF> points = new List<PointF>();
        private PointF origin = new PointF(0, 0);

        public Character()
        {

        }

        public void addPointF(PointF p)
        {
            points.Add(p);
        }

        public void addPointF(float x, float y)
        {
            addPointF(new PointF(x, y));
        }

        public PointF getPointF(int index)
        {
            return points[index];
        }
    }
}
