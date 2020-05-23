namespace covid19.Data
{
    public class City 
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int Infected {get; set;}
        public int Dead {get; set;}
        public Province Province{get; set;}
    }
}