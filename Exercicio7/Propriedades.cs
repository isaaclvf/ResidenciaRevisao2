namespace Exercicio7
{
    public class Propriedades
    {
        private readonly Dictionary<string, string> propriedades;

        public Propriedades()
        {
            propriedades = new Dictionary<string, string>();
        }

        public Propriedades(string path) : this()
        {
            string[] linhas;

            try
            {
                linhas = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao ler arquivo: {e.Message}");
            }

            foreach (string linha in linhas)
            {
                var sublinha = linha.Split('=');

                if (propriedades.ContainsKey(sublinha[0]))
                    throw new Exception("Existem duas propriedades com a mesma chave no arquivo");

                propriedades[sublinha[0]] = sublinha[1];
            }
        }

        public string RecuperarValor(string chave)
        {
            return propriedades[chave];
        }

        public void AlterarValor(string chave, string novoValor)
        {
            if (!propriedades.ContainsKey(chave))
                throw new Exception("Não existe uma propriedade com essa chave");
            propriedades[chave] = novoValor;
        }

        public bool ChaveExiste(string chave)
        {
            return propriedades.ContainsKey(chave);
        }

        public void AddChave(string chave, string valor = "")
        {
            if (propriedades.ContainsKey(chave))
                throw new Exception("Já existe uma propriedade com essa chave");
            propriedades[chave] = valor;
        }

        // https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter
        public void Salvar(string path)
        {
            using (StreamWriter sw = new StreamWriter(path)
            {
                foreach (var item in propriedades)
                {
                    sw.WriteLine(item.Key + '=' + item.Value);
                }
            }
        }
    }
}