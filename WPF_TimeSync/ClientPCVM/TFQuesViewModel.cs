using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientPCVM
{
    public class TFQuesViewModel
    {
        public Visibility Visibility { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public TFQuesViewModel()
        {
            Question = "(No Question)";
            Answer = "Emty Answer";
            Visibility = Visibility.Visible;
        }
    }
}
