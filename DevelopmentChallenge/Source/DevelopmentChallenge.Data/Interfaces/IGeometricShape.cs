using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IGeometricShape
    {
        string GetName(int quantity, string codeLanguage);
        decimal GetArea();
        decimal GetPerimeter();
    }
}
