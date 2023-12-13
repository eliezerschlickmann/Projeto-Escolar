using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;

[assembly: InternalsVisibleTo("Banco de Dados")]
namespace Biblioteca_de_Classes_de_Gerenciamneto_Escolar.Professores
{
    public class Professor
    {

        [Key]
        public int IDProfessor { get; private set; }
        public string Nome { get; private set; }
        public byte[] Fotografia { get; private set; }
        public string Senha { get;  set; }

        private string senha = "";
        public Professor() { }
        public Professor(int iDProfessor, string nome, string senha,byte[] foto )
        {
            IDProfessor = iDProfessor;
            Nome = nome;
            this.senha = senha;
            this.Senha = senha;
            Fotografia = foto;
        }
        public void SetFoto(Image image)
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
        public void SetSenha(string antiga, string nova)
        {
            if (ConfirirSenha(antiga))
            {
                senha = nova;
                Senha = nova;
            }
            else
                throw new Exception("Senha não bate com a antiga");
        }
        public bool ConfirirSenha(string senha)
        {
            return this.Senha.Equals(senha);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Professor)
            {
                return ((Professor)obj).IDProfessor == IDProfessor;
            }
            else if (obj is int)
            {
                return ((int)obj) == IDProfessor;
            }
            else
                return false;
        }
    }

}
