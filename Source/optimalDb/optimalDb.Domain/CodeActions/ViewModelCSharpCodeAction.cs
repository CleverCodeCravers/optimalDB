using optimalDb.Contracts;
using optimalDb.Persistence;

namespace optimalDb.Domain.CodeActions;

public class ViewModelCSharpCodeAction : CSharpCodeAction
{

    public ViewModelCSharpCodeAction() :
        base("C# ViewModel")
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
        var columns = schemaRepository.GetColumnList(databaseObjectSchema, databaseObjectName);

        var columnParameters = string.Join(Environment.NewLine,
            columns.Select(x => "    public " + NamingHelper.DotNetDataType(x) + " " + NamingHelper.DotNetNamePascalCase(x) + " { get; }")
        );

        var columnArguments =
            string.Join("," + Environment.NewLine,
                columns.Select(x => "        " + NamingHelper.DotNetDataType(x) + " " + NamingHelper.DotNetNameCamelCase(x))
            );

        var parameterAssignment =
            string.Join(Environment.NewLine,
                columns.Select(x => "        " + NamingHelper.DotNetNamePascalCase(x) + " = " + NamingHelper.DotNetNameCamelCase(x) + ";")
            );

        var template = $@"
public class {className}ViewModel
{{
{columnParameters}
    ValidationMessages ValidationMessages {{ get; }}

    public {className}ViewModel(
{columnArguments},
        ValidationMessages validationMessages = null
    )
    {{
{parameterAssignment}

        ValidationMessages = validationMessages;
        if (ValidationMessages == null)
            ValidationMessages = new ValidationMessages(Array.Empty<ValidationMessage>());
    }}
}}
        ";

        return template;
    }
}