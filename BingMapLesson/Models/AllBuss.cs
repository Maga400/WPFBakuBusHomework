using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BingMapLesson.Models
{
    public static class AllBuss
    {
        static public ObservableCollection<AftoBus>? Buses { get; set; }
    }
}
