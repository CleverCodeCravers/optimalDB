namespace optimalDb.Interfaces;

public interface IViewName
{
    string Schema { get; }
    string Name { get; }
    string Fullname { get; }
}