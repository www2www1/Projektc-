using System.Windows.Forms;

namespace projekt.classes
{
   public  class Episode
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Episode(string Description, string Name)
        {
            this.Name = Name;
            this.Description = Description;

        }
        public Episode() { }

        public  ListViewItem TolistViewItem()
        {
            var listView = new ListViewItem(new[] {
                Name,
                Description
                
            });
            return listView;
        }
    }
}
