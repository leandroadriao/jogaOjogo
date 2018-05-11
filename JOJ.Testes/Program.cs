using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOJ.Testes
{
    public class Program
    {
        private static bool BalancearTimes(Dictionary<int, List<Dominio.Jogador>> times)
        {
            int count = 0;
            int time1 = 0, time2 = 0;
            foreach (var obj in times)
            {
                if (count == 0)
                {
                    foreach (var values in obj.Value)
                    {
                        if (values.Posicao == Dominio.Constantes.PosicaoJogador.Ataque)
                            time1 = time1 + 1;
                        else
                            time1 = time1 + 2;

                    }
                }
                if (count == 1)
                {
                    foreach (var values in obj.Value)
                    {
                        if (values.Posicao == Dominio.Constantes.PosicaoJogador.Ataque)
                            time2 = time2 + 1;
                        else
                            time2 = time2 + 2;
                    }
                }
                count++;

            }
            Console.WriteLine(time1 - time2);
            if (time1 - time2 == 0)
                return true;
            else
                return false;

        }
        static void TiraTime(List<Dominio.Jogador> listaJogadores, int qtdeJogadores)
        {
            int limiteqtdeJogadores = 0;
            int qtdeTimes = 0;
            Dictionary<int, List<Dominio.Jogador>> times = new Dictionary<int, List<Dominio.Jogador>>();
            List<Dominio.Jogador> listatimes = new List<Dominio.Jogador>();
            var rnd = new Random();

            //var result = listaJogadores.OrderBy(item => rnd.Next());
            Shuffle(listaJogadores);
           // Shuffle(listaJogadores);

            //var ataque = listaJogadores.Where(x => x.Posicao == Dominio.Constantes.PosicaoJogador.Ataque).OrderBy(item => rnd.Next());
            //var defesa = listaJogadores.Where(x => x.Posicao == Dominio.Constantes.PosicaoJogador.Defesa).OrderBy(item => rnd.Next());

            foreach (var obj in listaJogadores)
            {
                if (limiteqtdeJogadores == 0)
                {
                    qtdeTimes++;
                    listatimes = new List<Dominio.Jogador>();
                    times.Add(qtdeTimes, listatimes);
                    limiteqtdeJogadores = 0;
                }

                limiteqtdeJogadores++;
                listatimes.Add(obj);

                if (limiteqtdeJogadores == qtdeJogadores)
                {
                    //qtdeTimes++;
                    //times.Add(qtdeTimes, listatimes);
                    //listatimes = new List<Dominio.Jogador>();
                    limiteqtdeJogadores = 0;
                }

                //Console.WriteLine(string.Format("{0}-{1}", obj.Nome, obj.Posicao.ToString()));
            }

            while (!BalancearTimes(times))
            {
                // Console.WriteLine("Tentativa");
                // Shuffle(listaJogadores);
                times[1].Add(times[2][0]);
                times[1].Add(times[2][1]);
                times[2].RemoveAt(0);
                times[2].RemoveAt(1);

                times[2].Add(times[1][0]);
                times[2].Add(times[1][1]);
                times[1].RemoveAt(0);
                times[1].RemoveAt(1);

            }

            foreach (var obj in times)
            {
                Console.WriteLine(string.Format("Time:{0}", obj.Key));

                foreach (var values in obj.Value)
                {
                    //int.Parse((Dominio.Constantes.PosicaoJogador)values.Posicao);
                    Console.WriteLine(string.Format("{0}-{1}", values.Nome, values.Posicao));
                }

            }

            // limiteqtdeJogadores = 0;
            //qtdeTimes = 0;
            //Console.WriteLine();
            //Console.WriteLine();

            //foreach (var obj in ataque)
            //{
            //    Console.WriteLine(string.Format("{0}-{1}", obj.Nome, obj.Posicao.ToString()));
            //}

            //limiteqtdeJogadores = 0;
            //qtdeTimes = 0;
            //Console.WriteLine();
            //Console.WriteLine();

            //foreach (var obj in defesa)
            //{
            //    Console.WriteLine(string.Format("{0}-{1}", obj.Nome, obj.Posicao.ToString()));
            //}
        }
        static void Main(string[] args)
        {

            // Aqui você deve pegar os valores da sua lista:
            //string[] array = { "Alaor", "Joseval", "Salustiano", "Gomide", "Castro" };
            //// Embaralhamos a lista...
            //Shuffle(array);
            //// ... e, uma vez embaralhada a lista, não precisa sortear novamente.
            //// basta ir pegando os resultados um por um, que os nomes não se repetirão:
            //foreach (string value in array)
            //{
            //    Console.WriteLine(value);
            //}
            //Console.WriteLine(); Shuffle(array);
            //// ... e, uma vez embaralhada a lista, não precisa sortear novamente.
            //// basta ir pegando os resultados um por um, que os nomes não se repetirão:
            //foreach (string value in array)
            //{
            //    Console.WriteLine(value);
            //}
            //Console.WriteLine(); Shuffle(array);
            //// ... e, uma vez embaralhada a lista, não precisa sortear novamente.
            //// basta ir pegando os resultados um por um, que os nomes não se repetirão:
            //foreach (string value in array)
            //{
            //    Console.WriteLine(value);
            //}
            //////
            Dominio.Jogador joga = new Dominio.Jogador();

            var source = joga.ObterTodosJogadores();

            TiraTime(source, 6);
            //Console.WriteLine();
            //TiraTime(source, 6);
            Console.Read();
        }

        static Random _random = new Random();

        public static void Shuffle<T>(List<T> array)
        {
            var random = _random;
            for (int i = array.Count(); i > 1; i--)
            {
                int j = random.Next(i);
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
        }
    }
}
