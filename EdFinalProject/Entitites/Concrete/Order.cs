﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Concrete
{
    public class Order : IEntity
    {

        [Key]
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public int employee_id { get; set; }
        public DateTime order_date { get; set; }
        public string ship_city { get; set; }



    }
}
