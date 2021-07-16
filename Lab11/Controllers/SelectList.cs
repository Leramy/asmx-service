using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab11.Controllers
{
    internal class SelecList : SelectList
    {
        public SelecList(IEnumerable items) : base(items)
        {
        }
    }
}