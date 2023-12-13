using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Alunos;
using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Aulas;
using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.MetodosAvaliativos;
using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Professores;
using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Provas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Disciplinas
{
    public class Disciplina
    {
        [Key]
        public int IDDisciplina { get; private set; }
        public Professor? Professor { get; private set; }
        public string Nome { get; private set; }
        public string Ementa { get; private set; }
        public string PlanoDeEnsino { get; private set; }
        public List<Aula> Aulas { get; private set; }
        public List<MetodoPadrao> ?Alunos { get; private set; }

        public Disciplina(int iDDisciplina,string nome,string ementa,
            string planoDeEnsino)
        {
            IDDisciplina = iDDisciplina;
            Nome = nome;
            Ementa = ementa;
            PlanoDeEnsino = planoDeEnsino; 
            Aulas = new List<Aula>();
            Professor = null;

        }
        public Disciplina(int iDDisciplina, Professor professor, string nome,
                            string ementa, string planoDeEnsino, 
                            List<MetodoPadrao> metodos, List<Aulas.Aula> aulas)
        {
            IDDisciplina = iDDisciplina;
            Professor = professor;
            Nome = nome;
            Ementa = ementa;
            PlanoDeEnsino = planoDeEnsino;
            Alunos = metodos;
            Aulas = aulas;
        }
        public void SetProfessor(Professor professor)
        {
            Professor = professor;
        }
        public void InserirAluno(MetodoPadrao novoAluno)
        {
            foreach(Aulas.Aula aula in Aulas)
            {
                aula.InserirAlunoNovo(novoAluno.AlunoAvaliado);
            }
            Alunos.Add(novoAluno);
        }
        public void FazerChamada(Aula aula, List<Tuple<Aluno, int?>> chamada)
        {
            try
            {

                Aulas.Find(x => x.Id == aula.Id).SetPresenca(chamada);
            }
            catch (Exception)
            {

            }
        }
        public void AdicionarProva(List<Prova> ProvasAvaliadasPeloProfessor)
        {
            string retorno="";
            foreach(Prova prova in ProvasAvaliadasPeloProfessor)
            {
                try
                {

                    Alunos.Find(x => x.AlunoAvaliado.IDAluno == prova.AlunoAvaliado.IDAluno).SetAvaliacao(prova);

                }
                catch (Exception ex)
                {
                    retorno += ex.Message + "\n";
                    
                }
            }
            if(!String.IsNullOrEmpty(retorno))
                throw new Exception(retorno);

        }
        public void AdicionarProvaAdicional(List<Prova> provas)
        {
            foreach (Prova prova in provas)
            {
                try
                {
                    Alunos.Find(x => x.AlunoAvaliado.IDAluno == prova.AlunoAvaliado.IDAluno).
                        IncluiProvaAdicional(prova);

                }
                catch (Exception ex)
                {


                }
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj is Disciplina)
            {
                return ((Disciplina)obj).IDDisciplina == IDDisciplina;
            }
            else if (obj is int)
            {
                return ((int)obj) == IDDisciplina;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return Nome;
        }
    }

}
