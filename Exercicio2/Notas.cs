namespace Exercicio2
{
    public class Notas
    {
        private float p1;

        private float p2;

        public float P1
        {
            get => p1;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("A nota precisa estar entre 0 e 10");
                p1 = value;
            }
        }
        public float P2
        {
            get => p2;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("A nota precisa estar entre 0 e 10");
                p2 = value;
            }
        }

        public float NF { get { return (P1 + P2) / 2; } }
    }
}
