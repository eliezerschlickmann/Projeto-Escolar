using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Alunos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Provas
{
    public class Prova
    {
        [Key]
        public int IDProva { get; private set; }
        public Aluno? AlunoAvaliado { get; private set; }
        public string Descricao { get; private set; }
        public DateTime ?DataDaAplicacao { get; private set; }
        public float Peso { get; private set; }
        public float ?Valor { get; private set; }
        public Prova(string descricao,float peso)
        {
            Descricao = descricao;
            Peso = peso;
        }
        public Prova(int idProva, string descricao,
                     DateTime data,float peso,
                     Aluno? aluno,float? valor)
        {   
            IDProva = idProva;
            Descricao = descricao;
            DataDaAplicacao = data;
            Peso = peso;
            Valor = valor;
            AlunoAvaliado = aluno;
        }
        public void SetAluno(Aluno aluno) 
        {
            if (AlunoAvaliado == null)
                AlunoAvaliado = aluno;
            else
                throw new Exception("já existe um aluno avaliado");
        }
        public void SetValor(float? nota)
        {
            if (nota >= 0 && nota <= 10)
                Valor = nota;
            else throw new Exception("Nota fora do intervalo de 0 a 10");
        }
        public void SetPeso(float peso) 
        {
            if (peso > 0)
                Peso = peso;
            else throw new Exception("Peso da prova tem que ser maior que zero");
        }
        public override bool Equals(object? obj)
        {
            if (obj is Prova)
            {
                return ((Prova)obj).IDProva == IDProva;
            }
            else if (obj is int)
            {
                return ((int)obj) == IDProva;
            }
            else return false;
        }
    }

}
