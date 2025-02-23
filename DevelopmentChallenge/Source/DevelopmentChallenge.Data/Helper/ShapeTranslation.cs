namespace DevelopmentChallenge.Data.Helper
{
    public class ShapeTranslation
    {
        public string Singular { get; }
        public string Plural { get; }

        public ShapeTranslation(string singular, string plural)
        {
            Singular = singular;
            Plural = plural;
        }
    }
}
