using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Products.Domain.Configuration;

namespace WooliesX.Products.Domain.Config
{
    public class AppConfig
    {
        public string Token { get; set; }
        public string BaseAddress { get; set; }
        public string Timeout { get; set; }
        public string UrlPathBase { get; set; }
        public string ProductEndpoint { get; set; }
        public string ShopperHistoryEndpoint { get; set; }
        public string TrolleyCalculatorEndpoint { get; set; }
    }
}
