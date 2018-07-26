using FluidUserInterfaces_AsyncAwait.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluidUserInterfaces_AsyncAwait.ViewModels
{
    class MainViewModel:INotifyPropertyChanged
    {
       
        

        public MainViewModel()
        {
            Speakers = new ObservableCollection<string>();
            Sessions = new ObservableCollection<string>();

            LoadCommand = new DelegateCommand(p=>  BoxIsChecked = false ,n=>BoxIsChecked==true);
            

        }


       
        private bool _BoxIsChecked;
        public bool BoxIsChecked
        {
            get { return _BoxIsChecked; }
            set
            {
                if (value != _BoxIsChecked)
                {
                    _BoxIsChecked = value;
                    OnPropertyChanged("BoxIsChecked");
                    ((DelegateCommand)LoadCommand).RaiseCanExecuteChanged();

                    //  isDirty = true;
                }
            }
        }
            



        private string _OutPut;
        public string OutPut
        {
            get { return _OutPut; }
            set
            {
                if (value != _OutPut)
                {
                    _OutPut = value;
                    OnPropertyChanged("OutPut");
                    //  isDirty = true;
                }
            }
        }


        public void TryTestAction()
        {
            OutPut = "Text wurde gesetzt";
        }

        public ICommand LoadCommand { get; set; }
        public ObservableCollection<string> Speakers { get; set; }
        public ObservableCollection<string> Sessions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }

        }



    }
}
