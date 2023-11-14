using Common.Functions;
using Common.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extentions
{
    public static class GridExtensions
    {

        public static SysResult GetGridData<T>(this SysResult result, DataTableRequest request) where T : class
        {
            if (result.Value == null)
            {
                var resultData = new DataTableBulider<T>(request);
                result.Value = resultData.EmptyResponse();
            }
            else
            {

                if (result.Value.GetType().ToString().StartsWith("System.Collections.Generic.List"))
                {
                    var resultData = new DataTableBulider<T>((List<T>)result.Value, request);
                    resultData.SelectColumn(request.RequestColumns);
                    result.Value = resultData.ExecuteQuery();
                }
                else
                {
                    var resultData = new DataTableBulider<T>((IQueryable<T>)result.Value, request);
                    resultData.SelectColumn(request.RequestColumns);
                    result.Value = resultData.ExecuteQuery();
                }
            }
            return result;
        }

    }
}
