using System;
using GraphicEditor.Interfaces;

namespace GraphicEditor.Models
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}