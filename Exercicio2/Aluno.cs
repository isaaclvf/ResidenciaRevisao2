﻿namespace Exercicio2
{
    public class Aluno
    {
        static int contAlunos; // Para gerar a matrícula

        private readonly string nome;

        private readonly string matricula;

        public Aluno(String nome)
        {
            if (nome == null)
                throw new Exception("Nome do aluno é obrigatório");
            if (nome.Length < 5)
                throw new Exception("Nome do aluno precisa ter pelo menos 5 letras");

            this.nome = nome;
            ++contAlunos;
            matricula = contAlunos.ToString().PadLeft(5, '0');
        }

        public String Nome { get { return nome; } }

        public String Matricula { get { return matricula; } }
    }
}