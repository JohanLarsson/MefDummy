using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MefDummy;

namespace Swedish
{
    [Export(typeof(ILanguage))]
    public class Swedish : ILanguage
    {
        public string Name { get { return "Swedish"; }}
        public string ClickCommandName { get { return "Klicka här"; } }
    }
}
