public class ManagerCompanion : ICompanion
{
    private readonly ContextCompanion _context;

    public ManagerCompanion(ContextCompanion context)
    {
        _context = context;
    }

    public List<Companion> SearchCompanions(string origin, string destination)
    {
        return _context.Companions.Where(c => c.origin == origin && c.destination == destination).ToList();
    }

    public void AddCompanion(Companion companion)
    {
        _context.Companions.Add(companion);
        _context.SaveChanges();
    }

    public void DeleteCompanion(int id)
    {
        var companion = _context.Companions.FirstOrDefault(c => c.id == id);
        if (companion != null)
        {
            _context.Companions.Remove(companion);
            _context.SaveChanges();
        }
    }
}