using System.Text;
using GraphicEditor.Interfaces;

namespace GraphicEditor.Models
{
    public class Rectangle : IShape
    {
        private readonly int height;
        private readonly int length;

        public Rectangle(int height, int length)
        {
            this.height = height;
            this.length = length;
        }

        public string Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('*', this.length));

            for (int i = 0; i < this.height - 2; i++)
            {
                sb.AppendLine($"{'*'}{new string(' ', this.length - 2)}{'*'}");
            }

            sb.AppendLine(new string('*', this.length));

            return sb.ToString();
        }
    }
}