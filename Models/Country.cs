namespace Test3.Models
{
    //creating country class to turn json text to an actual c# object
    public class Country
    {
        public string name { get; set; }
        public string capital { get; set; }
        public string region  { get; set; }
        public long population { get; set; }
        public double area { get; set; }

    }
}
