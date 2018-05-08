using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOJ.WebAPI.Models
{
    public class Contabil
    {
        private int codigoJogador;
        private DateTime data;
        private Constantes.TipoContabil tipo;
        private decimal valor;
        private string descricao;

        public int CodigoJogador { get => codigoJogador; set => codigoJogador = value; }
        public DateTime Data { get => data; set => data = value; }
        public Constantes.TipoContabil Tipo { get => tipo; set => tipo = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}