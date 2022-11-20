namespace Exercicio5
{
    public class Carro
    {
        private readonly string placa;

        private readonly string modelo;

        private Motor motor;

        private readonly int velocidadeMax;

        public Carro(string placa, string modelo, Motor motor)
        {
            this.placa = placa;
            this.modelo = modelo;

            this.motor = motor;
            this.motor.Instalar();

            var cilindrada = Motor.Cilandra;

            if (cilindrada <= 1.0)
                velocidadeMax = 140;
            if (cilindrada > 1.0 && cilindrada <= 1.6)
                velocidadeMax = 160;
            if (cilindrada > 1.6 && cilindrada <= 2.0)
                velocidadeMax = 180;
            if (cilindrada > 2.0)
                velocidadeMax = 220;
        }

        public string Placa { get { return placa; } }

        public string Modelo { get { return modelo; } }
        public int VelocidadeMax { get => velocidadeMax; }

        public Motor Motor { 
            get => motor; 
            set 
            {
                if (value.Instalado)
                    throw new Exception("Esse motor já está instalado em outro carro");

                motor = value;
                value.Instalar();
            } 
        }
    }
}