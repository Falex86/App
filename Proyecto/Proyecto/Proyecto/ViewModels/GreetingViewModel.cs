using System.ComponentModel;
using Proyecto.Models;

namespace Proyecto.ViewModels
{
    public class GreetingViewModel : INotifyPropertyChanged
    {
        private GreetingModel _greetingModel;

        public string GreetingMessage
        {
            get { return _greetingModel.Message; }
            set
            {
                if (_greetingModel.Message != value)
                {
                    _greetingModel.Message = value;
                    OnPropertyChanged(nameof(GreetingMessage));
                }
            }
        }

        public GreetingViewModel()
        {
            _greetingModel = new GreetingModel();
            _greetingModel.Message = "Hello, World from MVVM!";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

