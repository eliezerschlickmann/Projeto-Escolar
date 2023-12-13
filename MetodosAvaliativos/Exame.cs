using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Provas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.MetodosAvaliativos
{
    public class Exame : MetodoPadrao
    {

        private Prova? adicional = null;
        public Exame(int id) : base(id) { }
        public new float GetNotaFinal()
        {
            try
            {
                float nota = base.GetNotaFinal(), peso = 0;
                foreach (Prova p in provas)
                {
                    peso += p.Peso;
                }
                if (adicional != null && nota < 6.0)
                {
                    nota = (nota + getNotaProva(adicional)) / 2;
                }
                return nota;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public new  void IncluiProvaAdicional(Prova prova)
        {
            adicional = prova;
        }

    }
}
