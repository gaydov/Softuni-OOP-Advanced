using System;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Height
    {
        get { return height; }
        private set { height = value; }
    }

    public int Width
    {
        get { return this.width; }
        private set { this.width = value; }
    }

    // Drawing algorithm given in the description of the task:

    public void Draw()
    {
        this.DrawLine(this.Width, '*', '*');

        for (int i = 1; i < this.Height - 1; i++)
        {
            this.DrawLine(this.Width, '*', ' ');
        }

        this.DrawLine(this.Width, '*', '*');
    }

    // Drawing algorithm given in the description of the task:

    private void DrawLine(int width, char end, char mid)
    {
        Console.Write(end);

        for (int i = 1; i < width - 1; ++i)
        {
            Console.Write(mid);
        }

        Console.WriteLine(end);
    }
}

