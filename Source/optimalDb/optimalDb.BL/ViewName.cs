using optimalDb.Interfaces;

namespace optimalDb.BL;

public class ViewName : IViewName
{
    public string Schema { get; }
    public string Name { get; }
    public string Fullname => Schema + ".[" + Name + "]";

    public ViewName(string schema, string name)
    {
        Schema = schema;
        Name = name;
    }
}