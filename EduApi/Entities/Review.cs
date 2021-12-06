namespace EduApi.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Text { get; set; }
        public int Digit { get; set; }


        public Material Material { get; set; }
        public int MaterialId { get; set; }
    }
}