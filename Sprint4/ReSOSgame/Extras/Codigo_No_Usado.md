#Dibujar Grid para TicTacToe
```C#
            protected void DrawGridLines(Graphics g)
            {
                for (int row = 0; row < tamanio; row++)
                {
                    FillRoundedRectangle(g, 0, CANVAS_WIDTH / tamanio * row - GRID_WIDTH_HALF, CANVAS_WIDTH, GRID_WIDTH, GRID_WIDTH);
                }
                for (int col = 0; col < tamanio; col++)
                {
                    FillRoundedRectangle(g, CANVAS_HEIGHT / tamanio * col - GRID_WIDTH_HALF, 0, GRID_WIDTH, CANVAS_HEIGHT, GRID_WIDTH);
                }
            }
            public static void FillRoundedRectangle(Graphics graphics, float x, float y, float width, float height, float radius)
            {
                // Crea un rectángulo que tenga el mismo tamaño que el rectángulo redondeado
                RectangleF rectangle = new RectangleF(x, y, width, height);

                // Crea un rectángulo redondeado usando la clase GraphicsPath
                GraphicsPath path = new GraphicsPath();
                path.AddLine(rectangle.X + radius, rectangle.Y, rectangle.X + rectangle.Width - (radius * 2), rectangle.Y);
                path.AddArc(rectangle.X + rectangle.Width - (radius * 2), rectangle.Y, radius * 2, radius * 2, 270, 90);
                path.AddLine(rectangle.X + rectangle.Width, rectangle.Y + radius, rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height - (radius * 2));
                path.AddArc(rectangle.X + rectangle.Width - (radius * 2), rectangle.Y + rectangle.Height - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddLine(rectangle.X + rectangle.Width - (radius * 2), rectangle.Y + rectangle.Height, rectangle.X + radius, rectangle.Y + rectangle.Height);
                path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.AddLine(rectangle.X, rectangle.Y + rectangle.Height - (radius * 2), rectangle.X, rectangle.Y + radius);
                path.AddArc(rectangle.X, rectangle.Y, radius * 2, radius * 2, 180, 90);
                path.CloseFigure();

                // Llena el rectángulo redondeado con el pincel especificado
                graphics.FillPath(Brushes.Black, path);
            }
```            