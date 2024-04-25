public interface ICompanion
{
    List<Companion> SearchCompanions(string origin, string destination);
    void AddCompanion(Companion companion);
    void DeleteCompanion(int id);
}