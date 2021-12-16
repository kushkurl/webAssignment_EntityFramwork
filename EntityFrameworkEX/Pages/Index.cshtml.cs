using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkEX.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkEX.Pages
{
    public class IndexModel : PageModel
    {

        private Data.EntityFrameworkEXContext db = new Data.EntityFrameworkEXContext();

        public IList<Models.Product> Product { get; set; }

        public Models.Product prod { get; set; }

        public IList<Models.SaleItem> SaleItem { get; set; }

        public Models.SaleItem saleitem { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Data.EntityFrameworkEXContext.Initialize(db);
        }

        

        public async Task OnGetAsync()
        { 
            Product =  db.Product.ToList();
            SaleItem =  db.SaleItem.ToList();
        }

    }
}
