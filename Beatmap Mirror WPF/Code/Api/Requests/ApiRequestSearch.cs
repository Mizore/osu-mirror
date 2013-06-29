using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Api.Requests
{
    public class ApiRequestSearch : ApiRequest
    {
        public ApiRequestSearch()
        {
            base.Request = "search";
            base.RequestMethod = ApiRequestMethod.Text;
        }

        protected override string BuildQuery()
        {
            string buff = this.Request;
            foreach (string param in this.Parameters)
                buff += "/" + param;

            return buff;
        }
    }
}
