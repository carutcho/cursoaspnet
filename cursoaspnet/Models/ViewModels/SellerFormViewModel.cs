﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cursoaspnet.Models.ViewModels {

    public class SellerFormViewModel {
        public Seller Seller { get; set; }
        public ICollection<Departament> Departaments { get; set; }
    }
}
