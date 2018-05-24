using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace JOJ.APP.Deserialize
{
    public class Times
    {
        public ObservableCollection<Time> ListaTimes { get; set; }
        public Times()
        {
            ListaTimes = new ObservableCollection<Time>();
            Grouping<string, Jogador> teste = new Grouping<string, Jogador>("", new List<Jogador>());
        }
    }
    public class Time
    {
        public string Nome { get; set; }
        public ObservableCollection<Jogador> Jogadores { get; set; }
    }

    public class SelectCategoryViewModel
    {
        public Jogador Category { get; set; }
        public bool Selected { get; set; }
    }

    public class Grouping<TK, T> : ObservableCollection<T>
    {
        public TK Key { get; private set; }

        public Grouping(TK key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
