namespace UnitTestProject.Models
{
    public class Part
    {
        public string PartName { get; set; }
        public int PartId { get; set; }

        public Part(int id)
        {
            PartId = id;
        }
    }
}