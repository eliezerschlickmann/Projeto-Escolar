using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Alunos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Aulas
{
    public class Aula
    {
        [Key]
        public int Id { get;private set; }
        public DateTime Data { get; private set; }
        public int QuantidadesAulas { get; private set; }
        public TimeOnly ?Comeco { get; private set; }
        public TimeOnly? Fim { get; private set; }
        private List<Tuple<Aluno, int?>> presenca;
        public Aula() { }
        public Aula(int id, DateTime data, int quantidadeAula,TimeOnly comeco,TimeOnly fim)
        {
            Id = id;
            Data = data;
            QuantidadesAulas = quantidadeAula;
            Comeco = comeco;
            Fim = fim;
        }
        public Aula(int id,DateTime data,int quantidadeAula)
        {
            Id = id;
            Data = data;
            QuantidadesAulas = quantidadeAula;
        }
        public Aula(int id,DateTime data, TimeOnly comeco,TimeOnly fim,int quantidadeAula,List<Aluno> alunos)
        {
            Id = id;
            Data = data;
            QuantidadesAulas = quantidadeAula;
            Comeco = comeco;
            Fim = fim;
            presenca = new List<Tuple<Aluno, int?>>();
            foreach(Aluno aluno in alunos)
            {
                presenca.Add(new Tuple <Aluno,int?>(aluno, null) );
            }
        }
        public void InserirAlunoNovo(Aluno aluno)
        {
            presenca.Add(new Tuple<Aluno,int?>(aluno, null));
        }
        public int GetQuantidadeDeFaltas(Aluno aluno)
        {
            int ?faltas = GetQuantidadedeAulas();
            try
            {
                faltas = presenca.Find(x => x.Item1.IDAluno == aluno.IDAluno).Item2;
                if (faltas == null)
                    faltas = GetQuantidadedeAulas();
            }
	        catch (System.Exception)
            {

            }
            return GetQuantidadedeAulas()-(int)faltas;
        }
        public void SetPresenca(List<Tuple<Aluno,int?>> tupla)
        {
            presenca = tupla;
        }
        public int GetQuantidadedeAulas() => QuantidadesAulas;
        public override bool Equals(object? obj)
        {
            if (obj is Aula)
            {
                return ((Aula)obj).Id == Id;
            }
            else if (obj is int)
            {
                return ((int)obj) == Id;
            }
            else
                return false;
        }

    }
}
