using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Languages;
using System;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Circle : IGeometricShape
    {
        private decimal _radio;

        public Circle(decimal diameter)
        {
            if (diameter < decimal.Zero)
                throw new ArgumentNullException("invalid value");

            _radio = diameter / 2;
        }

        public string GetName(int quantity, string codeLanguage)
        {
            return Dictionaries.GetShapeName(Enums.ShapeType.Circle, codeLanguage, quantity > 1);
        }

        public decimal GetArea()
        {
            return (decimal)Math.PI * (_radio * _radio);
        }

        public decimal GetPerimeter()
        {
            return 2 * (decimal)Math.PI * _radio;
        }
    }
}
