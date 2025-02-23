using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Languages;
using System;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Triangle : IGeometricShape
    {
        private readonly decimal _side;

        public ShapeType Type = ShapeType.Triangle;

        public Triangle(decimal side)
        {
            if (side < decimal.Zero)
                throw new ArgumentNullException("invalid value");

            _side = side;
        }

        public string GetName(int quantity, string codeLanguage)
        {
            return Dictionaries.GetShapeName(Enums.ShapeType.Triangle, codeLanguage, quantity > 1);
        }

        public decimal GetArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _side * _side;
        }

        public decimal GetPerimeter()
        {
            return _side * 3;
        }
    }
}
