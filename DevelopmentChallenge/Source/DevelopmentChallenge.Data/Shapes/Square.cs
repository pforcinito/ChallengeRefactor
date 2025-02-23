using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Languages;
using System;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Square : IGeometricShape
    {
        private readonly decimal _side;

        public ShapeType Type = ShapeType.Square;

        public Square(decimal side)
        {
            if (side < decimal.Zero)
                throw new ArgumentNullException("invalid value");
            _side = side;
        }

        public string GetName(int quantity, string codeLanguage)
        {
            return Dictionaries.GetShapeName(Enums.ShapeType.Square, codeLanguage, quantity > 1);
        }

        public decimal GetArea()
        {
            return _side * _side;
        }

        public decimal GetPerimeter()
        {
            return _side * 4;
        }
    }
}
