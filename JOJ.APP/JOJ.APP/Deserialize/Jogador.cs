using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JOJ.APP.Deserialize
{
    public class Jogador
    {
        #region Constantes

        private readonly string[] _gamer = { "codigo", "nome", "posicao", "tipo" };
        private readonly string _file = "gamer.txt";
        private readonly string _directory = "Repository";
        private readonly IFile _ifile;
        #endregion

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Posicao { get; set; }
        public int Tipo { get; set; }
        public bool Selected { get; set; }

        #region Construtor
        public Jogador()
        {
            IFolder folder = FileSystem.Current.LocalStorage.CreateFolderAsync(_directory, CreationCollisionOption.OpenIfExists).Result;
            _ifile = folder.CreateFileAsync(_file, CreationCollisionOption.OpenIfExists).Result;
        }

        #endregion

        public async Task<string> ObterTodosJogadoresString()
        {
            return await _ifile.ReadAllTextAsync();
        }

        public async Task<List<Jogador>> ObterTodosJogadores()
        {
            List<Jogador> listJogadores = new List<Jogador>();
            Jogador jogador;
            string readAllText = await _ifile.ReadAllTextAsync();
            string [] jogadores = readAllText.Split(';');
            try
            {
                for (int i = 0; i < jogadores.Length; i++)
                {
                    var properties = jogadores[i].Split('#');

                    jogador = new Jogador()
                    {
                        Codigo = int.Parse(properties[0]),
                        Nome = properties[1],
                        Posicao = int.Parse(properties[2]),
                        Tipo = int.Parse(properties[3])
                    };

                    listJogadores.Add(jogador);
                }
                return listJogadores;
            }
            catch (Exception ex)
            {
                return listJogadores;
            }


        }

    }
}
