namespace Exercicio4
{
    public class Pessoa
    {
        private string nome;

        private Certidao? certidao;

        public Pessoa(string nome)
        {
            this.nome = nome;
        }

        public string Nome { get { return nome; } }

        public Certidao? Certidao { get { return certidao; } }

        public void AddCertidao(Certidao certidao)
        {
            if (Certidao != null)
                throw new Exception("Essa pessoa já tem certidão");

            this.certidao = certidao;
        }
    }
}