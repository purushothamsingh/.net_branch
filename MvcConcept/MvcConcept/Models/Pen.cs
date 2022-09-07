namespace MvcConcept.Models
{
    public class Pen
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Cost { get; set; }


        public Pen() { }
        public Pen(int id , string name,int cost)
        {
            this.Id = id;   
            this.Name = name;
            this.Cost = cost;
        }

        public static List<Pen> pens =  new List<Pen>();
        public static List<Pen> getAllPens()
        {
            pens.Add(new Pen(1, "parker", 500));
            pens.Add(new Pen(2, "reynolds", 400));

            return pens;
        }
         
    }
}
