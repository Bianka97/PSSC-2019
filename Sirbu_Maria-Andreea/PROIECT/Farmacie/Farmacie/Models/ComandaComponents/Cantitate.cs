﻿using Farmacie.Models.CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmacie.Models.ComandaComponents
{
    public class Cantitate
    {
        private Number cant;

        public Cantitate(Number ct)
        {

            cant = ct;
        }
        public Number getCantitate { get { return cant; } }
    }
}
