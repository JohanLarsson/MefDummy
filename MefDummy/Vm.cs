using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MefDummy.Annotations;

namespace MefDummy
{
    public class Vm :INotifyPropertyChanged
    {
        public Vm()
        {
            var catalog = new AggregateCatalog(new DirectoryCatalog("."),
            new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            var temp = Languages.ToList();
            //var languages = container.GetExportedValues<ILanguage>();
            //foreach (var language in languages)
            //{
            //    Languages.Add(language);
            //}
        }

        [ImportMany(typeof(ILanguage))]
        public IEnumerable<ILanguage> Languages { get; set; } 
        //private ObservableCollection<ILanguage> _languages;
        //public ObservableCollection<ILanguage> Languages
        //{
        //    get { return _languages ?? (_languages = new ObservableCollection<ILanguage>()); }
        //}

        private ILanguage _language;
        public ILanguage Language
        {
            get { return _language; }
            set
            {
                if (Equals(value, _language)) return;
                _language = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
