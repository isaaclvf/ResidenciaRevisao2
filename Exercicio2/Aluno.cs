namespace Exercicio2
{
    public class Aluno
    {
        static int contAlunos; // Para gerar a matrícula

        private readonly string nome;

        private readonly string matricula;

        public Aluno(string nome)
        {
            if (nome == null)
                throw new Exception("Nome do aluno é obrigatório");
            if (nome.Length < 5)
                throw new Exception("Nome do aluno precisa ter pelo menos 5 letras");

            this.nome = nome;
            ++contAlunos;
            matricula = contAlunos.ToString().PadLeft(5, '0');
        }

        public string Nome { get { return nome; } }

        public string Matricula { get { return matricula; } }
    }
}