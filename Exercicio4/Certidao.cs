namespace Exercicio4
{
    public class Certidao
    {
        private readonly Pessoa pessoa;

        private readonly DateTime dataEmissao;

        public Certidao(Pessoa pessoa)
        {
            if (pessoa.Certidao != null)
                throw new Exception("Essa pessoa já tem certidão");

            this.pessoa = pessoa;
            dataEmissao = DateTime.Today;

            pessoa.AddCertidao(this);
        }

        public Pessoa Pessoa { get { return pessoa; } }

        public DateTime DataEmissao { get { return dataEmissao; } }
    }
}
