using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuricataLogViewer.Models
{
    public class SideBarElement : INotifyPropertyChanged
    {
        public delegate void SideBarHandler();

        public static event SideBarHandler Notify;

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string CurrentName
        {
            get
            {
                return UseFullName ? FullName : ShortName;
            }
        }

        private static bool useFullName;

        public static bool UseFullName
        {
            get
            {
                return useFullName;
            }
            set
            {
                if (useFullName != value)
                {
                    useFullName = value;
                    Notify?.Invoke();
                }
            }
        }

        public SideBarElement()
        {
            Notify += OnNotify;
        }

        private void OnNotify()
        {
            OnPropertyChanged("CurrentName");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
