﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ArmyTechTask.Models
{
    public partial class InvoiceDetail
    {
        public long Id { get; set; }
        public long InvoiceHeaderId { get; set; }
        public string ItemName { get; set; }
        public double ItemCount { get; set; }
        public double ItemPrice { get; set; }

        public virtual InvoiceHeader InvoiceHeader { get; set; }
    }
}
