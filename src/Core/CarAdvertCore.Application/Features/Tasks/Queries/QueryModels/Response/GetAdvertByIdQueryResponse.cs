
using CarAdvertCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response
{
    public class GetAdvertByIdQueryResponse
    {
        public long id { get; set; }
        public long memberId { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int townID { get; set; }
        public string townName { get; set; }
        public int modelId { get; set; }
        public string modelName { get; set; }
        public int year { get; set; }
        public decimal price { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
        public long km { get; set; }
        public string color { get; set; }
        public string gear { get; set; }
        public string fuel { get; set; }
        public string firstPhoto { get; set; }
        public string secondPhoto { get; set; }
        public string userInfo { get; set; }
        public string userPhone { get; set; }
        public string text { get; set; }
    }
}
