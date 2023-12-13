using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.AnosLetivos
{
    public class AnoLetivo
    {
        [Key]
        public int IDAnoLetivo { get; private set; }
        public string TipoEnsino { get; private set; }
        public int Ano { get;private set; }
        public AnoLetivo(int iDAnoLetivo, string tipoEnsino, int ano)
        {
            IDAnoLetivo = iDAnoLetivo;
            TipoEnsino = tipoEnsino;
            Ano = ano;
        }
        public override bool Equals(object? obj)
        {
            if (obj is AnoLetivo)
            {
                return ((AnoLetivo)obj).IDAnoLetivo == IDAnoLetivo;
            }
            else
                return false;
        }
    }
}
