using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace lab1.Controllers
{
    internal class SelecList : SelectList
    {
        public SelecList(IEnumerable items) : base(items)
        {
        }
    }
}