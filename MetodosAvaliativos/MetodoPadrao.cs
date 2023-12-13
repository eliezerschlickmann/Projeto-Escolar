using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Alunos;
using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Provas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.MetodosAvaliativos
{
    public class MetodoPadrao
    {
        [Key]
        public int IDMetodo { get; private set; }
        protected List<Prova> provas;
        public Aluno? AlunoAvaliado { get; private set; }
        public MetodoPadrao(int iDMetodo)
        {
            provas = new List<Prova>();
            IDMetodo = iDMetodo;
            AlunoAvaliado = null;
        }
        public MetodoPadrao(int iDMetodo,Aluno aluno)
        {
            provas = new List<Prova>();
            IDMetodo = iDMetodo;
            AlunoAvaliado =aluno;
        }
        public float GetNotaFinal()
        {
            float nota=0,peso=0;
            foreach(Prova prova in provas) 
            {
                nota += getNotaProva(prova) * prova.Peso;
                peso += prova.Peso;
            }
            return nota/peso;
        }

        public void IncluiProvaAdicional(Prova prova)
        {
            throw new Exception("Método Padrão não possui prova adicional");
        }

        public void SetAvaliacao(Prova prova)
        {
            if (prova.AlunoAvaliado.Equals(AlunoAvaliado)&& prova.AlunoAvaliado!=null)
                provas.Add(prova);
            else
                throw new Exception("Aluno avaliado não corresponde com o aluno que fez a prova");
        }
        public override bool Equals(object? obj)
        {
            if (obj is MetodoPadrao)
            {
                return ((MetodoPadrao)obj).IDMetodo == IDMetodo;
            }
            else if (obj is int)
            {
                return ((int)obj) == IDMetodo;
            }
            else
                return false;
        }
        public void SetAluno(Aluno aluno)
        {
            if (AlunoAvaliado != null)
                throw new Exception("já existe um aluno avaliado");
            else
                AlunoAvaliado = aluno;
        }
        protected float getNotaProva(Prova prova)
        {
            if (prova.Valor == null)
                return 0;
            return (float)prova.Valor;
        }
    }
}
