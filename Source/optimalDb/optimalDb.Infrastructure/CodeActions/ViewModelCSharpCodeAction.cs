using optimalDb.BL;

namespace optimalDb.Infrastructure.CodeActions;

public class ViewModelCSharpCodeAction : CSharpCodeAction
{

    public ViewModelCSharpCodeAction() :
        base("C# ViewModel")
    {
    }

    public override string Execute(
        string connectionString,
        string database,
        string databaseObjectSchema,
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        var databaseAccessor = new DatabaseAccessor(connectionString, database);
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        if (databaseObjectTypeEnum != DatabaseObjectTypeEnum.Table &&
            databaseObjectTypeEnum != DatabaseObjectTypeEnum.View)
        {
            return "";
        }

        var className = DotNetClassName(databaseObjectName);
        var columns = schemaRepository.GetColumnList(databaseObjectSchema, databaseObjectName);

        var columnParameters = string.Join(Environment.NewLine,
            columns.Select(x => "    public " + DotNetDataType(x) + " " + DotNetNamePascalCase(x) + " { get; }")
        );

        var columnArguments =
            string.Join("," + Environment.NewLine,
                columns.Select(x => "        " + DotNetDataType(x) + " " + DotNetNameCamelCase(x))
            );

        var parameterAssignment =
            string.Join(Environment.NewLine,
                columns.Select(x => "        " + DotNetNamePascalCase(x) + " = " + DotNetNameCamelCase(x) + ";")
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