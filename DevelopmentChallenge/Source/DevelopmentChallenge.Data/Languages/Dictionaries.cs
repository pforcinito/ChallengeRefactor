using DevelopmentChallenge.Data.Constants;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Helper;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Languages
{
    public static class Dictionaries
    {
        public static readonly Dictionary<string, Dictionary<ShapeType, ShapeTranslation>> Translations =
            new Dictionary<string, Dictionary<ShapeType, ShapeTranslation>>
            {
                { ConstantKeys.LanguageEs, new Dictionary<ShapeType, ShapeTranslation>
                    {
                        { ShapeType.Square, new ShapeTranslation(ConstantKeys.SquareNameEs, ConstantKeys.SquaresNameEs) },
                        { ShapeType.Circle, new ShapeTranslation(ConstantKeys.CircleNameEs, ConstantKeys.CirclesNameEs) },
                        { ShapeType.Rectangle, new ShapeTranslation(ConstantKeys.RectangleNameEs, ConstantKeys.RectanglesNameEs) },
                        { ShapeType.Triangle, new ShapeTranslation(ConstantKeys.TriangleNameEs, ConstantKeys.TrianglesNameEs) },
                        { ShapeType.Trapezoid, new ShapeTranslation(ConstantKeys.TrapezoidNameEs, ConstantKeys.TrapezoidsNameEs) }
                    }
                },
                { ConstantKeys.LanguageEn, new Dictionary<ShapeType, ShapeTranslation>
                    {
                        { ShapeType.Square, new ShapeTranslation(ConstantKeys.SquareNameEn, ConstantKeys.SquaresNameEn) },
                        { ShapeType.Circle, new ShapeTranslation(ConstantKeys.CircleNameEn, ConstantKeys.CirclesNameEn) },
                        { ShapeType.Rectangle, new ShapeTranslation(ConstantKeys.RectangleNameEn, ConstantKeys.RectanglesNameEn) },
                        { ShapeType.Triangle, new ShapeTranslation(ConstantKeys.TriangleNameEn, ConstantKeys.TrianglesNameEn) },
                        { ShapeType.Trapezoid, new ShapeTranslation(ConstantKeys.TrapezoidNameEn, ConstantKeys.TrapezoidsNameEn) }
                    }
                },
                { ConstantKeys.LanguageIt, new Dictionary<ShapeType, ShapeTranslation>
                    {
                        { ShapeType.Square, new ShapeTranslation(ConstantKeys.SquareNameIt, ConstantKeys.SquaresNameIt) },
                        { ShapeType.Circle, new ShapeTranslation(ConstantKeys.CircleNameIt, ConstantKeys.CirclesNameIt) },
                        { ShapeType.Rectangle, new ShapeTranslation(ConstantKeys.RectangleNameIt, ConstantKeys.RectanglesNameIt) },
                        { ShapeType.Triangle, new ShapeTranslation(ConstantKeys.TriangleNameIt, ConstantKeys.TrianglesNameIt) },
                        { ShapeType.Trapezoid, new ShapeTranslation(ConstantKeys.TrapezoidNameIt, ConstantKeys.TrapezoidsNameIt) }
                    }
                }
            };

        public static string GetShapeName(ShapeType shape, string language, bool plural = false)
        {
            if (Translations.ContainsKey(language) && Translations[language].ContainsKey(shape))
            {
                var translation = Translations[language][shape];
                return plural ? translation.Plural : translation.Singular;
            }
            throw new ArgumentException("Is not supported language");
        }
    }

}
