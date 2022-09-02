namespace optimalDb.Interfaces;

public interface IDatabaseSchemaRepository
{
    IViewName[] GetViewList();
    string GetCode(string name);
}