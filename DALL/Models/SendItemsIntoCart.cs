﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.Models
{
    public class SendItemsIntoCart
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }
    }
}
