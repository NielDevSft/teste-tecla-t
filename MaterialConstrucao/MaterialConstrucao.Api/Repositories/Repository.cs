using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialConstrucao.Api.Repositories
{
    public abstract class Repository<TModel>
    {
        protected List<TModel> GetListObjectFromJson(string path)
        {
            var json = GetJsonObject(path);

            var data = json["data"][typeof(TModel).Name];

            return data.ToObject<List<TModel>>();
        }
        private JObject GetJsonObject(string path)
        {
            try
            {
                return JObject.Parse(File.ReadAllText(path));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
