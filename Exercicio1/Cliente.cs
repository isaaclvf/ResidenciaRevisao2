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

        public void SetCPF(String cpfString)
        {
            // Validação
            // 11 dígitos
            if (cpfString.Length != 11)
                throw new Exception("CPF deve ter exatamente 11 dígitos");

            /* Os caracteres não podem ser todos iguais
             * https://stackoverflow.com/questions/16027475/determine-if-all-characters-in-a-string-are-the-same
             * https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all
             */
            if (cpfString.All(digito => digito == cpfString[0]))
                throw new Exception("Os dígitos do CPF não podem ser todos iguais");

            // Checar primeiro dígito verificador (j)
            int j = 0;
            int somaJ = 0;
            for (int i = 0; i < 9; i++)
                // https://www.techiedelight.com/convert-char-to-int-csharp/
                somaJ += (int)Char.GetNumericValue(cpfString[i]) * (10 - i);

            if (!(somaJ % 11 == 0 || somaJ % 11 == 1))
                j = 11 - (somaJ % 11);

            if ((int)Char.GetNumericValue(cpfString[9]) != j)
                throw new Exception("CPF inválido");

            // Checar segundo dígito verificador (k)
            int k = 0;
            int somaK = 0;
            for (int i = 0; i < 9; i++)
                somaK += (int)Char.GetNumericValue(cpfString[i]) * (11 - i);

            if (!(somaK % 11 == 0 || somaK % 11 == 1))
                k = 11 - (somaK % 11);

            if ((int)Char.GetNumericValue(cpfString[10]) != k)
                throw new Exception("CPF inválido");

            // Salvar no campo como float
            cpf = Convert.ToInt64(cpfString);
        }

        public string GetCPF()
        {
            // Preservar zeros à esquerda
            var CPFString = cpf.ToString();

            if (CPFString.Length == 11) return CPFString;

            return CPFString.PadLeft(11, '0');
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
