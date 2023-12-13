using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Provas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.MetodosAvaliativos
{
    public class Substitutiva : MetodoPadrao
    {
        private Prova? adicional;
        public Substitutiva(int id):base(id)
        {

            adicional = null;
        }
        public new float GetNotaFinal()
        {
            try
            {
                float nota = 0, peso = 0;
                nota = base.GetNotaFinal();
                foreach (Prova p in provas)
                {
                    peso += p.Peso;
                }
                if (nota < 6.0 && adicional != null)
                {

                    for (int i = 0; i < provas.Count; i++)
                    {
                        float notacalculada = 0;
                        for (int j = 0; j < provas.Count; j++)
                        {
                            if (i == j)
                            {
                                notacalculada += getNotaProva(adicional) * provas[j].Peso;
                            }
                            else
                                notacalculada += getNotaProva(provas[j]) * provas[j].Peso;
                        }
                        notacalculada /= peso;
                        if (nota < notacalculada)
                        {
                            nota = notacalculada;
                            adicional.SetPeso(provas[i].Peso);
                        }
                    }

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
