﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Voucher
    {
        public string CodVoucher { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCanje { get; set; }
        public int IdArticulo{ get; set; }
    }
}
