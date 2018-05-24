using System;
using System.Collections.Generic;
using System.Text;

namespace JOJ.APP.ViewModels
{
    public class Times
    {
        public class Time {
            public string Nome { get; set; }
            public bool Selected { get; set; }

        }
        public class SelectTimeViewModel
        {
            public Time Time { get; set; }
            public bool Selected { get; set; }
        }
    }
}
