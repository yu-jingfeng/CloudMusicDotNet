using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Infrastructure
{
    public class DtoParseService : IDtoParseService
    {
        private readonly HttpContext _httpContext;

        public DtoParseService(IHttpContextAccessor httpContextAccesor)
        {
            _httpContext = httpContextAccesor.HttpContext;
        }

        public string Parse(object dto)
        {
            JObject json;

            if (dto == null)
                json = new JObject();
            else
                json = JObject.FromObject(dto);

            var csrfToken = _httpContext.Request.Cookies["_csrf"];

            if (!string.IsNullOrWhiteSpace(csrfToken))
            {
                json.Add("csrf_token", csrfToken);
            }

            return json.ToString(Formatting.None);
        }
    }
}
