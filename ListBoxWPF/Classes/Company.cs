namespace ListBoxWPF
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;

    }
}