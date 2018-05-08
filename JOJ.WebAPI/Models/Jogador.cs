using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JOJ.WebAPI.Models
{
    public class Jogador
    {
        #region Constantes
        private readonly string[] _jogador = { "codigo", "nome", "posicao", "tipo" };
        private readonly string _arquivo = @"C:\Temp\jogador.txt";
        #endregion

        #region Propriedades

        private int codigo;
        private string nome;
        private Constantes.PosicaoJogador posicao;
        private Constantes.TipoJogador tipo;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public Constantes.PosicaoJogador Posicao { get => posicao; set => posicao = value; }
        public Constantes.TipoJogador Tipo { get => tipo; set => tipo = value; }

        #endregion

        #region Construtor
        public Jogador()
        {
            if (!File.Exists(_arquivo))
                using (FileStream fs = File.Create(_arquivo, 1024)) { }
        }

        #endregion

        public List<Jogador> ObterTodosJogadores()
        {
            List<Jogador> listJogadores = new List<Jogador>();
            string filePath = _arquivo;
            Jogador jogador;
            string line;
            try
            {
                using (StreamReader lines = new StreamReader(filePath))
                {
                    while ((line = lines.ReadLine()) != null)
                    {
                        var cols = line.Split('#');

                        jogador = new Jogador()
                        {
                            codigo = int.Parse(cols[0]),
                            nome = cols[1],
                            posicao = (Constantes.PosicaoJogador)int.Parse(cols[2]),
                            tipo = (Constantes.TipoJogador)int.Parse(cols[3])
                        };

                        listJogadores.Add(jogador);
                    }
                }
                return listJogadores;
            }
            catch (Exception ex)
            {
                return listJogadores;
            }


        }

        public int BuscarProximoSequencial()
        {
            List<Jogador> listJogadores = ObterTodosJogadores();
            if (listJogadores.Count == 0)
                return 1;

            return listJogadores.Max(x => x.codigo) + 1;
        }
        public Boolean Cadastro(int codigo, string nome, int posicao, int tipo)
        {
            if (ObterTodosJogadores().FirstOrDefault(x => x.Nome == nome) is null)
            {
                using (StreamWriter file = new StreamWriter(_arquivo, true))
                {
                    file.WriteLine(string.Format("{0}#{1}#{2}#{3}", codigo, nome, posicao, tipo));
                }
                return true;
            }
            else
                return false;
        }
    }
}