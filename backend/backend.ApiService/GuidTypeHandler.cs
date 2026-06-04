namespace backend.ApiService;

using System.Data;
using Dapper;

public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override void SetValue(IDbDataParameter parameter, Guid value)
    {
        parameter.Value = value.ToByteArray();
    }

    public override Guid Parse(object value)
    {
        return new Guid((byte[])value);
    }
}
