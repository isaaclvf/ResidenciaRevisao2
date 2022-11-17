namespace Exercicio1
{
    public class Cliente
    {
        private string? nome;

        private long cpf;

        private DateTime nascimento;

        private float renda;

        private char estadoCivil;

        private int dependentes;

        public string? Nome
        {
            get { return nome; }
            set
            {
                if (value?.Length < 5)
                    throw new ArgumentException("Nome deve ter pelo menos 5 caracteres");
                nome = value;
            }
        }

        public long CPF
        {
            get { return cpf; }
            set
            {
                // Isso não funciona se o primeiro dígito for 0, como resolver?
                if (value.ToString().Length != 11)
                    throw new ArgumentException("CPF deve ter exatamente 11 dígitos");
                cpf = value;
            }
        }

        public DateTime Nascimento
        {
            get { return nascimento; }
            set
            {
                TimeSpan idade = DateTime.Today - value;
                if ((idade.TotalDays / 365) < 18)
                    throw new ArgumentException("O cliente deve ter pelo menos 18 anos na data atual");

                nascimento = value;
            }
        }

        public float Renda
        {
            get { return renda; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Renda não pode ser negativa");

                renda = value;
            }
        }

        public char EstadoCivil
        {
            get { return estadoCivil; }
            set
            {
                if (Char.ToLower(value) != 'c' &&
                    Char.ToLower(value) != 's' &&
                    Char.ToLower(value) != 'v' &&
                    Char.ToLower(value) != 'd')
                    throw new ArgumentException("EstadoCivil precisa ser C, S, V ou D");

                estadoCivil = value;
            }
        }

        public int Dependentes
        {
            get { return dependentes; }
            set
            {
                if (!(value >= 0 && value <= 10))
                    throw new ArgumentException("Dependentes precisa estar entre 0 e 10");

                dependentes = value;
            }
        }
    }
}
