/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Constants;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.ModelDtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Services
{
    public class ReportingService : IReportingService
    {
        public string PrintReport(List<IGeometricShape> shapes, string languageCode)
        {
            var sb = new StringBuilder();

            if (!shapes.Any())
            {
                sb.Append($"<h1>{GetEmptyListLine(languageCode)}</h1>");
                return sb.ToString();
            }

            sb.Append($"<h1>{GetTitle(languageCode)}</h1>");


            var groupShapes = shapes
                .GroupBy(s => s.GetType())
                .Select(s => new ShapesResponseDto
                {
                    Name = s.First().GetName(s.Count(), languageCode),
                    Quantity = s.Count(),
                    Area = s.Sum(x => x.GetArea()),
                    Perimeter = s.Sum(x => x.GetPerimeter())
                })
                .ToList(); ;

            foreach (var shape in groupShapes)
                sb.Append(GetLine(shape.Quantity, shape.Area, shape.Perimeter, shape.Name, languageCode));

            var totalShapes = groupShapes.Sum(s => s.Quantity);
            var totalArea = groupShapes.Sum(s => s.Area);
            var totalPerimeter = groupShapes.Sum(s => s.Perimeter);

            sb.Append($"TOTAL:<br/>{totalShapes} {GetSubTitle(languageCode)} ");
            sb.Append($"{GetPerimeterName(languageCode)} {LocalizeNumberFormat(totalPerimeter, languageCode)} ");
            sb.Append($"Area {LocalizeNumberFormat(totalArea, languageCode)}");

            return sb.ToString();
        }


        private static string GetEmptyListLine(string languageCode)
        {
            switch (languageCode)
            {
                case (ConstantKeys.LanguageEs):
                    return ConstantKeys.EmptyListEs;
                case (ConstantKeys.LanguageIt):
                    return ConstantKeys.EmptyListIt;
                case (ConstantKeys.LanguageEn):
                default:
                    return ConstantKeys.EmptyListEn;
            }
        }

        private static string GetTitle(string languageCode)
        {
            switch (languageCode)
            {
                case (ConstantKeys.LanguageEs):
                    return ConstantKeys.TitleEs;
                case (ConstantKeys.LanguageIt):
                    return ConstantKeys.TitleIt;
                case (ConstantKeys.LanguageEn):
                default:
                    return ConstantKeys.TitleEn;
            }
        }

        private static string GetLine(int quantity, decimal area, decimal perimeter, string shapeName, string languageCode)
        {
            if (quantity <= 0)
                return string.Empty;

            var areaFormatted = LocalizeNumberFormat(area, languageCode);
            var perimeterFormatted = LocalizeNumberFormat(perimeter, languageCode);

            string perimeterLabel;
            switch (languageCode)
            {
                case ConstantKeys.LanguageEs:
                    perimeterLabel = "Perímetro";
                    break;
                case ConstantKeys.LanguageIt:
                    perimeterLabel = "Perimetro";
                    break;
                case ConstantKeys.LanguageEn:
                default:
                    perimeterLabel = "Perimeter";
                    break;
            }

            return $"{quantity} {shapeName} | Area {areaFormatted} | {perimeterLabel} {perimeterFormatted} <br/>";
        }

        private static string GetSubTitle(string languageCode)
        {
            switch (languageCode)
            {
                case (ConstantKeys.LanguageEs):
                    return ConstantKeys.SubTitleEs;
                case (ConstantKeys.LanguageIt):
                    return ConstantKeys.SubTitleIt;
                case (ConstantKeys.LanguageEn):
                default:
                    return ConstantKeys.SubTitleEn;
            }
        }

        private static string GetPerimeterName(string languageCode)
        {
            switch (languageCode)
            {
                case (ConstantKeys.LanguageEs):
                    return ConstantKeys.PerimetroEs;
                case (ConstantKeys.LanguageIt):
                    return ConstantKeys.PerimetroIt;
                case (ConstantKeys.LanguageEn):
                default:
                    return ConstantKeys.PerimetroEn;
            }
        }

        private static string LocalizeNumberFormat(decimal value, string language)
        {
            var culture = language.Equals(ConstantKeys.LanguageEn, StringComparison.OrdinalIgnoreCase)
                ? CultureInfo.InvariantCulture
                : new CultureInfo("es-ES");

            return value.ToString("#,##0.##", culture);
        }
    }
}
