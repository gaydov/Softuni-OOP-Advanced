using GraphicEditor.Models;

namespace GraphicEditor
{
    public class Launcher
    {
        public static void Main()
        {
            Models.GraphicEditor editor = new Models.GraphicEditor();
            Circle circle = new Circle(4);
            Rectangle rect = new Rectangle(4, 8);
            Square square = new Square(5);

            editor.DrawShape(circle);
            editor.DrawShape(rect);
            editor.DrawShape(square);
        }
    }
}
