using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JOJ.Dominio.Constantes;

namespace JOJ.Dominio
{
    public class Jogador
    {
        #region Constantes
        private readonly string[] _jogador = { "codigo","nome", "posicao", "tipo" };
        #endregion
        #region Propriedades

        private int codigo;
        private string nome;
        private PosicaoJogador posicao;
        private TipoJogador tipo;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public PosicaoJogador Posicao { get => posicao; set => posicao = value; }
        public TipoJogador Tipo { get => tipo; set => tipo = value; }

        #endregion

        public List<Jogador> ObterTodosJogadores()
        {
            
            List<Jogador> listJogadores = new List<Jogador>();
            string filePath = @"C:\Temp\jogador.txt";
            Jogador jogador;
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    var cols = line.Split('#');

                    jogador = new Jogador()
                    {
                        codigo = int.Parse(cols[0]),
                        nome = cols[1],
                        posicao = (PosicaoJogador)int.Parse(cols[2]),
                        tipo = (TipoJogador)int.Parse(cols[3])
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
