using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public double GetBiggestNumber(params double[] numbers)
        {
            double biggestNumber = 0;
            foreach (double number in numbers)
            {
                if (number > biggestNumber)
                {
                    biggestNumber = number;
                }
            }
            return biggestNumber;
        }

        public double GetCircleArea(double radius)
        {
            return Math.PI * Math.Sqrt(radius);
        }

        public double GetCirclePerimeter(double radius)
        {
            return 2 * Math.PI * radius;
        }

        public double GetTriangleArea(double height, double weight)
        {
            return height * weight / 2;
        }

        public double GetTrianglePerimeter(double a, double b, double c)
        {
            return Sum(a, b, c);
        }

        public bool IsTriangleBuildable(double side1, double side2, double side3)
        {
            bool result = false;
            double biggestSide = GetBiggestNumber(side1, side2, side3);
            if (biggestSide == side1)
            {
                if (biggestSide < (side2 + side3))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else if (biggestSide == side2)
            {
                if (biggestSide < (side1 + side3))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else if (biggestSide == side3)
            {
                if (biggestSide < (side1 + side2))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
