namespace Exercicio2
{

    public class Turma
    {
        private List<Aluno> alunos;

        private Dictionary<string, Notas> notas;

        // contTurmas e anoAtual servem para criar o código da turma
        private static int contTurmas;

        private static string? anoAtual;

        private readonly string codigo;

        public Turma()
        {
            alunos = new List<Aluno>();
            notas = new Dictionary<string, Notas>();

            // Cria códigos para a turma como 2022.01, 2022.02 até 2022.99

            anoAtual ??= DateTime.Now.Year.ToString(); // ??== null-coalescing assignment

            // A contagem de turmas recomeça se o ano tiver mudado
            if (anoAtual != DateTime.Now.Year.ToString())
            {
                anoAtual = DateTime.Now.Year.ToString();
                contTurmas = 0;
            }
            
            contTurmas = (contTurmas + 1) % 100; // de 01 a 99
            codigo = anoAtual + '.' + contTurmas.ToString().PadLeft(2, '0');
        }

        public string Codigo { get => codigo; }

        public List<Aluno> Alunos { get => alunos; }

        public void AddAluno(Aluno aluno)
        {
            if (!alunos.Exists(a => aluno.Equals(a)))
            {
                alunos.Add(aluno);

                string matricula = aluno.Matricula;
                notas.Add(matricula, new Notas());
            }
        }

        public void RemoveAluno(Aluno aluno)
        {
            // https://stackoverflow.com/questions/10018957/how-to-remove-item-from-list-in-c
            var alunoParaRemover = alunos.SingleOrDefault(a => aluno.Equals(a));
            if (alunoParaRemover != null)
                alunos.Remove(alunoParaRemover);
        }

        public void LancarP1(Aluno aluno, float nota)
        {
            string matricula = aluno.Matricula;
            notas[matricula].P1 = nota;
        }

        public void LancarP2(Aluno aluno, float nota)
        {
            string matricula = aluno.Matricula;
            notas[matricula].P2 = nota;
        }

        public void ImprimirAlunos()
        {
            // https://stackoverflow.com/questions/188141/listt-orderby-alphabetical-order
            var listaAlfabetica = alunos.OrderBy(a => a.Nome).ToList();

            foreach (var aluno in listaAlfabetica)
                Console.Write(aluno.Nome);
        }

        public void ImprimirAlunosComNF()
        {
            var listaAlfabetica = alunos.OrderBy(a => a.Nome).ToList();

            foreach (var aluno in listaAlfabetica)
                Console.Write(aluno.Nome + " - " + notas[aluno.Matricula].NF.ToString());
        }

        public void ImprimirEstatisticas()
        {
            float totalP1 = notas.Values.Sum(n => n.P1);
            float mediaP1 = (float)Math.Round((totalP1 / notas.Count), 2);

            float totalP2 = notas.Values.Sum(n => n.P2);
            float mediaP2 = (float)Math.Round((totalP2 / notas.Count), 2);

            float totalNF = notas.Values.Sum(n => n.NF);
            float mediaNF = (float)Math.Round((totalNF / notas.Count), 2);

            Console.WriteLine("Média P1: " + mediaP1.ToString());
            Console.WriteLine("Média P2: " + mediaP2.ToString());
            Console.WriteLine("Média NF: " + mediaNF.ToString());

            var maiorNota = notas.Values.MaxBy(nota => nota.NF);

            // Mais de um aluno pode ter a maior nota
            foreach (var nota in notas)
            {
                if (nota.Value.NF == maiorNota?.NF)
                {
                    Console.WriteLine(nota.Key + " - " + nota.Value.NF.ToString());
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Turma turma
                && this.Codigo == turma.Codigo;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
