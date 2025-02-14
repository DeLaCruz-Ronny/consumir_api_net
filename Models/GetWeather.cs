using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumir_api.Models
{
    public class GetWeather
    {
        public DateOnly date { get; set; }
        public int temperatureC { get; set; }
        public int temperatureF => 32 + (int)(temperatureC / 0.5556);
        public string ? summary { get; set; }
    }
}
