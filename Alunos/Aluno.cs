using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using Biblioteca_de_Classes_de_Gerenciamneto_Escolar.AnosLetivos;

[assembly: InternalsVisibleTo("Banco de Dados")]
namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Alunos
{
    
    public class Aluno
    {

        [Key]
        public int IDAluno {   get; private  set; }
        public string NomeAluno { get; private set; }
        public AnoLetivo AnoLetivo { get;private set; }
        public byte[] Fotografia { get; private set; }
        public Aluno() { }
        public Aluno(int iDAluno, string nomeAluno,byte[] image)
        {
            IDAluno = iDAluno;
            NomeAluno = nomeAluno;
            this.Fotografia=image;
        }
        public void SetAnoLetivo(AnoLetivo anoLetivo)
        {
            this.AnoLetivo = anoLetivo;
        }
        public void SetImagen(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Converta o MemoryStream em um array de bytes
                Fotografia = stream.ToArray();
            }
        }
        public Image GetFoto()
        {
            BinaryFormatter bf = new BinaryFormatter();

            // Crie um MemoryStream com seus dados binários
            using (MemoryStream ms = new MemoryStream(Fotografia))
            {
                // Desserialize o MemoryStream em uma Image
                return (Image)bf.Deserialize(ms);
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj is Aluno)
            {
                return ((Aluno)obj).IDAluno == IDAluno;
            }
            else if (obj is int)
            {
                return ((int)obj) == IDAluno;
            }
            else
                return false;
        }
    }

}
