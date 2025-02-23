using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Services
{
    public interface IReportingService
    {
        string PrintReport(List<IGeometricShape> shapes, string languageCode);
    }
}
