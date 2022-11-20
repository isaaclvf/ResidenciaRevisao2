namespace Exercicio5
{
    public class Motor
    {
        private readonly float cilindrada;

        private bool instalado;

        public Motor(float cilindrada)
        {
            this.cilindrada = cilindrada;
            this.instalado = false;
        }

        public void Instalar()
        {
            if (Instalado)
                throw new Exception("O motor já está instalado.");

            Instalado = true;
        }

        public float Cilandra { get => cilindrada; }

        public bool Instalado { get => instalado; private set { instalado = value; } }
    }
}
