using System.Collections.Generic;

namespace ArmyTechTask.Models.ModelView
{
    public class details_header_viewModel
    {
        public details_header_viewModel()
        {
            SumTotal = 0;
        }
        public IEnumerable<InvoiceDetail> InvoiceDetailList { get; set; }
        public IEnumerable<InvoiceHeader> InvoiceHeader { get; set; }

        public double SumTotal { get; set; }
    }
}
