using Catteria.Desktop.DTOs;
using Catteria.Desktop.Helpers;
using System;

using System.Collections.Generic;
using System.Text;

namespace Catteria.Desktop.Services
{
    public class CupomApiService
    {


        private readonly HttpClientHelper _http;

        public CupomApiService()
        {
            _http = HttpClientHelper.Instance;
        }

      
    }
}
