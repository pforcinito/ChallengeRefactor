using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Languages;
using System;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Trapezoid : IGeometricShape
    {
        private readonly decimal _largerBase;
        private readonly decimal _smallerBase;
        private readonly decimal _height;
        private readonly decimal _side1;
        private readonly decimal _side2;

        public ShapeType Type = ShapeType.Trapezoid;

        public Trapezoid(decimal largerBase, decimal smallerBase, decimal height, decimal side1, decimal side2)
        {
            if (largerBase <= decimal.Zero || smallerBase <= decimal.Zero || height <= decimal.Zero || side1 <= decimal.Zero || side2 <= decimal.Zero)
                throw new ArgumentException("Invalid value");

            if (largerBase <= smallerBase)
                throw new ArgumentException("The larger base must be greater than the smaller base.");

            _largerBase = largerBase;
            _smallerBase = smallerBase;
            _height = height;
            _side1 = side1;
            _side2 = side2;
        }

        public string GetName(int quantity, string codeLanguage)
        {
            return Dictionaries.GetShapeName(Enums.ShapeType.Trapezoid, codeLanguage, quantity > 1);
        }

        public decimal GetArea()
        {
            return ((_largerBase + _smallerBase) / 2) * _height;
        }

        public decimal GetPerimeter()
        {
            return _largerBase + _smallerBase + _side1 + _side2;
        }
    }
}
