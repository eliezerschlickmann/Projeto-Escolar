using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Provas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.MetodosAvaliativos
{
    public class Recuperacao:MetodoPadrao
    {
        private Prova? provaAdicional;
        public Recuperacao(int id):base(id)
        {

            provaAdicional = null;
        }
        public new void IncluiProvaAdicional(Prova prova) 
        {
            provaAdicional = prova;
        }
        public new float GetNotaFinal()
        {
            try
            {
                float nota = base.GetNotaFinal();
                if (nota < 6.0 && provaAdicional != null)
                {
                    return getNotaProva(provaAdicional);
                }
                return nota;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
