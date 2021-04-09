using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.Repositori;

namespace WpfApp1.ViewModel
{
    class CursViewModel:ViewModelBase//страдания и боль
    {
        private DateTime _Date;
        private double _User_Value;//вводимое значение
        private double _Converted_Value;//переведенное в другую волюту, значение

        private Valute _userSelected1;
        private Valute _userSelected2;

        private Curs _curs;
        private ObservableCollection<Valute> _ValuteList;

        private Implimentation _Implimentation;
        public DateTime Date { get => _Date; 
            set { 
                _Date = value;
                OnPropertyChanged();//сообщаю об изменениях
                GetCurs(value);
            } }
        public double User_Value { get => _User_Value; 
            set {
                _User_Value = value;
                OnPropertyChanged();
                Converted_Value = _User_Value;
            } }
        public double Converted_Value { get => _Converted_Value; 
            set { 
                _Converted_Value = Convert(value); 
                OnPropertyChanged(); } }
        public Valute UserSelected1 { get => _userSelected1; 
            set 
            { _userSelected1 = value;
                OnPropertyChanged();
                User_Value = User_Value;
            } }
        public Valute UserSelected2 { get => _userSelected2; 
            set 
            { _userSelected2 = value;
                OnPropertyChanged();
                User_Value = User_Value;
            } }
        public Curs Curs { get => _curs; 
            set 
            { _curs = value;
                OnPropertyChanged();
                ValuteList = ToCollection(value.Valute);
            } }
        public ObservableCollection<Valute> ValuteList { get => _ValuteList; 
            set 
            { _ValuteList = value;
                OnPropertyChanged();
                User_Value = User_Value;//костыли... костыли повсюду...
            } }

        private double Convert(double user_value)
        {
            if (UserSelected1 == null || UserSelected2 == null)
                return 0;
            double Valute1RealValue = UserSelected1.Value_Double / UserSelected1.Nominal1;
            double Valute2RealValue = UserSelected2.Value_Double / UserSelected2.Nominal1;

            double result = User_Value * Valute1RealValue / Valute2RealValue;//перевод из рубля в выбранную валюту; и послудующий перевод в другую валюту;

            return result;
        }

        private ObservableCollection<Valute> ToCollection(List<Valute> list)
        {
            ObservableCollection<Valute> collection = new ObservableCollection<Valute>();
            foreach(Valute val in list)
            {
                collection.Add(val);
            }
            return collection;
        }

        async private void GetCurs(DateTime? time)
        {
             Curs = await _Implimentation.GetCurs(time);
        }

        public CursViewModel()
        {
            _userSelected2 = _userSelected1;
            _Date = DateTime.Now;
            _Implimentation = new Implimentation();
            GetCurs(null);
        }
    }
}
