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
        public double Sum(params double[] args) // Somme
        {
            double finalResult = 0;
            foreach (double arg in args)
            {
                finalResult += arg; // Ajoute les nombres
            }
            return finalResult;
        }

        public double GetLowestNumber(params double[] numbers)
        {
            double lowestNumber = numbers[0];
            foreach (double number in numbers)
            {
                if (number < lowestNumber)
                {
                    lowestNumber = number;
                }
            }
            return lowestNumber;
        }

        public double GetBiggestNumber(params double[] numbers) // Obtient le nombre le plus grand
        {
            double biggestNumber = numbers[0]; // Fonction compatible avec des nombres négatifs
            foreach (double number in numbers) // Pour chaque nombre
            {
                if (number > biggestNumber) // Si le nombre est plus grand le plus grand nombre, alors il devient le plus grand nombre
                {
                    biggestNumber = number;
                }
            }
            return biggestNumber;
        }

        public class Circle
        {
            public double GetArea(double radius) // Obtenir l'aire d'un cercle
            {
                return Math.PI * Math.Sqrt(radius); // Formule
            }

            public double GetPerimeter(double radius) // Obtenir le périmètre d'un cercle
            {
                return 2 * Math.PI * radius; // Formule
            }
        }

        public class Triangle
        {
            public double GetArea(double height, double weight) // Obtenir l'aire d'un triangle
            {
                return height * weight / 2; // Formule
            }

            public double GetPerimeter(double side1, double side2, double side3) // Obtenir le périmètre d'un triangle
            {
                return new Maths().Sum(side1, side2, side3); // Formule
            }

            public bool IsBuildable(double side1, double side2, double side3) // Triangle construisable ?
            {
                bool result = false; // Résultat final
                double biggestSide = new Maths().GetBiggestNumber(side1, side2, side3); // Obtient le grand côté
                if (biggestSide == side1) // Si le grand coté est side1
                {
                    if (biggestSide < (side2 + side3)) // Formule pour savoir si le triangle est construisable
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (biggestSide == side2) // Si le grand coté est side2
                {
                    if (biggestSide < (side1 + side3)) // Formule pour savoir si le triangle est construisable
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (biggestSide == side3) // Si le grand coté est side3
                {
                    if (biggestSide < (side1 + side2)) // Formule pour savoir si le triangle est construisable
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
}
