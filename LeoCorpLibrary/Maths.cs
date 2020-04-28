using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    public class Maths
    {
        public double Sum(params double[] args)
        {
            double finalResult = 0;
            foreach (double arg in args)
            {
                finalResult += arg;
            }
            return finalResult;
        }

        public double GetCircleArea(double radius)
        {
            return Math.PI * Math.Sqrt(radius);
        }

        public double GetCirclePerimeter(double radius)
        {
            return 2 * Math.PI * radius;
        }
    }
}
