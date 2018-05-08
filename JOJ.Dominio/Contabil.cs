using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JOJ.Dominio.Constantes;

namespace JOJ.Dominio
{
    public class Contabil
    {
        private int codigoJogador;
        private DateTime data;
        private TipoContabil tipo;
        private decimal valor;
        private string descricao;

        public int CodigoJogador { get => codigoJogador; set => codigoJogador = value; }
        public DateTime Data { get => data; set => data = value; }
        public TipoContabil Tipo { get => tipo; set => tipo = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public string Descricao { get => descricao; set => descricao = value; }

        public DataTable ConvertToDataTable(string filePath, int numberOfColumns)
        {
            DataTable tbl = new DataTable();

            for (int col = 0; col < numberOfColumns; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));


            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var cols = line.Split('#');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < 3; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }

            return tbl;
        }
    }
}
