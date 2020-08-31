using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboComTest
{
    public class Item
    {
        public string Name { get; set; }
        public ObservableCollection<Item> Items { get; set; }
    }
}
