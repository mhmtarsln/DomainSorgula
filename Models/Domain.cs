using DomainSorgula.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainSorgula.Models
{
    public class Domain : INotifyPropertyChanged
    {
        private int _index;
        private string _name;
        private string _status;

        [DisplayName("No")]
        public int Index { get { return _index; } set { SetField(ref _index, value, "No"); } }
        [DisplayName("Domain")]
        public string Name { get { return _name; } 
            set { 
                SetField(ref _name, value, "Domain");
                Extension = RegexHelper.GetDomainExtension(value);
            }
        }

        [DisplayName("Durum")]
        public string Status { get { return _status; } set { SetField(ref _status, value, "Durum"); } }

        [Browsable(false)]
        public string Extension { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
