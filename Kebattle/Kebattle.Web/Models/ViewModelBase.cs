using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kebattle.Web.Models
{
    public class ViewModelBase
    {
        protected static List<SelectListItem> GetSelectList<T>(IEnumerable<T> items, bool includeEmptySelectItem = true, string emptySelectItemText = "Select", string defaultValue = "", bool orderAlphabetically = true)
        {
            var retList = new List<SelectListItem>();
            if (includeEmptySelectItem)
            {
                retList.Add(new SelectListItem() { Text = String.Format("-- {0} --", emptySelectItemText), Value = defaultValue });
            }
            if (orderAlphabetically)
            {
                items = items.OrderBy(c => ((dynamic)c).Name);
            }
            retList.AddRange(items.Select(a => new SelectListItem() { Text = ((dynamic)a).Name, Value = ((dynamic)a).Id.ToString() }));
            return retList;
        }
    }
}