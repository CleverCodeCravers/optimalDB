using optimalDb.Contracts;
using optimalDb.Persistence;

namespace optimalDb.Domain.CodeActions;

public class DataTransferRecordCSharpCodeAction : CSharpCodeAction
{

    public DataTransferRecordCSharpCodeAction() :
        base("C# Record")
    {
    }

    public override string Execute(
        IDatabaseAccessor databaseAccessor,
        string connectionString,
        string database,
        string databaseObjectSchema,
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        if (databaseObjectTypeEnum != DatabaseObjectTypeEnum.Table &&
            databaseObjectTypeEnum != DatabaseObjectTypeEnum.View)
        {
            return "";
        }

        var className = NamingHelper.DotNetClassName(databaseObjectName);
        var columns = schemaRepository.GetColumnsIncludingPrimaryKeys(databaseObjectSchema, databaseObjectName);

        //var properties = columns.Select(x => $"    public {NamingHelper.DotNetDataType(x)} {NamingHelper.DotNetNamePascalCase(x)} {{ get; init; }}");
        var constructorParameters = columns.Select(x => $"{NamingHelper.DotNetDataType(x)} {NamingHelper.DotNetNamePascalCase(x)}");

        var template = $@"
public record {className}(
    {string.Join($", {Environment.NewLine}    ", constructorParameters)}
);
";

        return template;
    }
}