﻿namespace Dsp.Web.Areas.House.Models
{
    using Dsp.Data.Entities;
    using System.Collections.Generic;

    public class MyWorkOrdersModel
    {
        public IEnumerable<WorkOrder> CreatedWorkOrders { get; set; }
        public IEnumerable<WorkOrder> InvolvedWorkOrders { get; set; }
    }
}