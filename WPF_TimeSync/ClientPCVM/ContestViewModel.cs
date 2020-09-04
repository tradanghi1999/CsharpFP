using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPCVM
{
    public class ContestViewModel : BaseViewModel
    {
        TFQuesViewModel _trueFalseQues;
        public TFQuesViewModel TrueFalseQuestion
        { 
            get => _trueFalseQues;
            set
            {
                _trueFalseQues = value;
                OnPropertyChanged("TrueFalseQuestion");
            }
        }

        public ContestViewModel()
        {
            TrueFalseQuestion = new TFQuesViewModel();
        }
    }
}
