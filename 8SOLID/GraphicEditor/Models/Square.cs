using System.Text;
using GraphicEditor.Interfaces;

namespace GraphicEditor.Models
{
    public class Square : IShape
    {
        private readonly int sideLength;

        public Square(int sideLength)
        {
            this.sideLength = sideLength;
        }

        public string Draw()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('*', this.sideLength));

            for (int i = 0; i < this.sideLength - 2; i++)
            {
                sb.AppendLine($"{'*'}{new string(' ', this.sideLength - 2)}{'*'}");
            }

            sb.AppendLine(new string('*', this.sideLength));

            return sb.ToString();
        }
    }
}