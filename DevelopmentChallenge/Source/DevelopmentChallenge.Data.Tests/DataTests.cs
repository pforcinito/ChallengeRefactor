using DevelopmentChallenge.Data.Constants;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Services;
using DevelopmentChallenge.Data.Shapes;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class DataTests
    {
        private IReportingService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ReportingService();
        }

        [TestCase]
        public void TestResumenListaVaciaCastellano()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                _service.PrintReport(new List<IGeometricShape>(), ConstantKeys.LanguageEs));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                _service.PrintReport(new List<IGeometricShape>(), ConstantKeys.LanguageEn));
        }

        [TestCase]
        public void TestResumenListaVaciaItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                _service.PrintReport(new List<IGeometricShape>(), ConstantKeys.LanguageIt));
        }

        [TestCase]
        public void TestResumenListaConUnCuadradoCastellano()
        {
            var squeres = new List<IGeometricShape> { new Square(5) };

            var resumen = _service.PrintReport(squeres, ConstantKeys.LanguageEs);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadradosEnglish()
        {
            var cuadrados = new List<IGeometricShape>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            var resumen = _service.PrintReport(cuadrados, ConstantKeys.LanguageEn);

            Assert.AreEqual("<h1>Shapes Report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IGeometricShape>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square(2),
                new Triangle(9),
                new Circle(2.75m),
                new Triangle(4.2m)
            };

            var resumen = _service.PrintReport(formas, ConstantKeys.LanguageEn);

            Assert.AreEqual(
                "<h1>Shapes Report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IGeometricShape>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square(2),
                new Triangle(9),
                new Circle(2.75m),
                new Triangle(4.2m)
            };

            var resumen = _service.PrintReport(formas, ConstantKeys.LanguageEs);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 13,01 | Perímetro 18,06 <br/>3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void Rectangle_Trapezoid_EnCastellano()
        {
            var formas = new List<IGeometricShape>
            {
                new Rectangle(7, 4),
                new Trapezoid(15, 8, 7, 6, 6),
            };

            var resumen = _service.PrintReport(formas, ConstantKeys.LanguageEs);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Rectángulo | Area 28 | Perímetro 22 <br/>1 Trapecio | Area 80,5 | Perímetro 35 <br/>TOTAL:<br/>2 formas Perímetro 57 Area 108,5",
                resumen);
        }

        [TestCase]
        public void Rectangle_Trapezoid_EnIngles()
        {
            var formas = new List<IGeometricShape>
            {
                new Rectangle(7, 4),
                new Trapezoid(15, 8, 7, 6, 6),
            };

            var resumen = _service.PrintReport(formas, ConstantKeys.LanguageEn);

            Assert.AreEqual(
                "<h1>Shapes Report</h1>1 Rectangle | Area 28 | Perimeter 22 <br/>1 Trapezoid | Area 80.5 | Perimeter 35 <br/>TOTAL:<br/>2 shapes Perimeter 57 Area 108.5",
                resumen);
        }

        [TestCase]
        public void GetRectangle_InvalidSize_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => new Rectangle(-1, -1));
        }
    }
}
