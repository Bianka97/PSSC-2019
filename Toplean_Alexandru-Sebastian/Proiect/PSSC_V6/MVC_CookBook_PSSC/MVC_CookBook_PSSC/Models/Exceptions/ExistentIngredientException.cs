﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CookBook_PSSC.Models.Exceptions
{
    public class ExistentIngredientException:SystemException
    {
        public ExistentIngredientException(String errMsg)
        {

        }
    }
}
