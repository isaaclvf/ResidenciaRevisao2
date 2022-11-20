using Exercicio2;

namespace Exercicio3
{
    public class Curso
    {
        private readonly string nome;

        private readonly List<Aluno> alunos;

        private readonly List<Turma> turmas;

        private readonly Dictionary<Aluno, Turma?> vinculos;

        public Curso(string nome) 
        {
            alunos = new List<Aluno>();
            turmas = new List<Turma>();
            vinculos = new Dictionary<Aluno, Turma?>();
            this.nome = nome;
        }

        public string Nome { get => nome; }

        public void AddAluno(Aluno aluno)
        {
            if (!alunos.Contains(aluno))
            {
                alunos.Add(aluno);
                vinculos.Add(aluno, null); // Não associa a nenhuma turma
            }
        }

        public void RemoveAluno(Aluno aluno)
        {
            if (vinculos.ContainsKey(aluno))
                throw new Exception("O aluno está vinculado a uma turma e não pode ser removido do curso");

            if (alunos.Contains(aluno))
                alunos.Remove(aluno); 
        }

        public void AddTurma(Turma turma)
        {
            if (!turmas.Contains(turma))
                turmas.Add(turma);
        }

        public void RemoveTurma(Turma turma)
        {
            if (turma.Alunos.Count != 0)
                throw new Exception("A turma tem alunos associados a ela e não pode ser removida");

            if (turmas.Contains(turma))
                turmas.Remove(turma);
        }

        public void AddVinculo(Turma turma, Aluno aluno)
        {
            if (!alunos.Contains(aluno))
                throw new Exception("Aluno não está cadastrado no curso");

            if (!turmas.Contains(turma))
                throw new Exception("Turma não está cadastrada no curso");

            if (vinculos[aluno] != null)
                throw new Exception($"Aluno já está vinculado à turma {vinculos[aluno].Codigo}");

            vinculos[aluno] = turma;
        }

        public void RemoveVinculo(Aluno aluno)
        {
            if (!alunos.Contains(aluno))
                throw new Exception("Aluno não está cadastrado no curso");

            if (vinculos[aluno] == null)
                throw new Exception("Aluno não está vinculado a nenhuma turma");

            vinculos[aluno] = null;
        }

        public void ImprimirTurma(Turma turma)
        {
            // Só imprime se a turma já estiver cadastrada no curso
            if (turmas.Contains(turma))
                turma.ImprimirAlunos();
        }

        public void ImprimirTurmas()
        {
            var turmasOrdenadas = turmas.OrderBy(turma => turma.Codigo);
            foreach (var turma in turmasOrdenadas)
            {
                if (turma.Alunos.Count != 0)
                    turma.ImprimirAlunos();
            }
        }
    }
}