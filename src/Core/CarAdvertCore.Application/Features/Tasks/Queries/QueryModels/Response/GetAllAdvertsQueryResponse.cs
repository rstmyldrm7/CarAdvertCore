using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response
{
    public class GetAllAdvertsQueryResponse
    {
        public int total { get; set; }
        public int page {get; set;}
        public List<AdvertsDto> adverts { get; set; }
    }

    public class AdvertsDto
    {
        public string id { get; set; }
        public string modelName { get; set; }
        public string category { get; set; }
        public string year {  get; set; }
        public string price { get; set; }
        public string title { get; set; }
        public string date {  get; set; }
        public string km { get; set; }
        public string color { get; set; }
        public string gear { get; set; }
        public string fuel {  get; set; }
        public string firstPhoto {  get; set; }
    }
}
