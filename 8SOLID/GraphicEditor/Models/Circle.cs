using System.Text;
using GraphicEditor.Interfaces;

namespace GraphicEditor.Models
{
    public class Circle : IShape
    {
        private readonly int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public string Draw()
        {
            StringBuilder sb = new StringBuilder();

            double r_in = this.radius - 0.4;
            double r_out = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < r_out; x += 0.5)
                {
                    double value = (x * x) + (y * y);

                    if (value >= r_in * r_in && value <= r_out * r_out)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}