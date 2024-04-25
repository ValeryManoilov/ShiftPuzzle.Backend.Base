public class Companion
{
    public int id { get; set; }
    public string name { get; set; }
    public DateTime date { get; set; }
    public int reward { get; set; }
    public string origin { get; set; }
    public string destination { get; set; }

    public Companion(){}

    public Companion(int Id, string Name, DateTime DDate, int Reward, string Origin, string Destination)
    {
        id = Id;
        name = Name;
        date = DDate;
        reward = Reward;
        origin = Origin;
        destination = Destination;
    }
}