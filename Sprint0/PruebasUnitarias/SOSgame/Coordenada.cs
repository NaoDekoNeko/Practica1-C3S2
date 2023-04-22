namespace Sprint0
{
    public class Coordenada
    {
        double x;
        double y;
        //Clase coordenada en el plano XY
        public Coordenada(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double getX() { return x; }
        public double getY() { return y; }
    }
}