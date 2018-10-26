namespace projekt.classes
{
    class Episode
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Episode(string Description, string Name)
        {
            this.Name = Name;
            this.Description = Description;

        }
    }
}
