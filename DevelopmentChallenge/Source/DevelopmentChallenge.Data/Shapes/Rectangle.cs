using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Languages;
using System;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Rectangle : IGeometricShape
    {
        private readonly decimal _base;
        private readonly decimal _height;

        public ShapeType Type = ShapeType.Rectangle;

        public Rectangle(decimal @base, decimal height)
        {
            if (@base < decimal.Zero || height < decimal.Zero)
                throw new ArgumentNullException("invalid value");
            _base = @base;
            _height = height;
        }

        public string GetName(int quantity, string codeLanguage)
        {
            return Dictionaries.GetShapeName(Enums.ShapeType.Rectangle, codeLanguage, quantity > 1);
        }

        public decimal GetArea()
        {
            return _base * _height;
        }

        public decimal GetPerimeter()
        {
            return 2 * (_base + _height);
        }
    }
}
