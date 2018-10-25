using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt.classes
{
    class Episode
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Episode(string Name, string Description) {
            this.Description = Description;
            this.Name = Name;
        }
    }
}
