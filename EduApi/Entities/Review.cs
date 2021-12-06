namespace EduApi.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Text { get; set; }
        public int Digit { get; set; }


        public MaterialType MaterialType { get; set; }
        public int MaterialTypeId { get; set; }
    }
}