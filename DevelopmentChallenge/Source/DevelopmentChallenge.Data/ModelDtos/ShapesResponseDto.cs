using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.ModelDtos
{
    public class ShapesResponseDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Area { get; set; }
        public decimal Perimeter { get; set; }
    }
}
