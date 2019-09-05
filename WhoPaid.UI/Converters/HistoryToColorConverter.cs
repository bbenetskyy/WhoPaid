using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MvvmCross.Forms.Converters;
using WhoPaid.Core.Models;
using WhoPaid.UI.Resources;

namespace WhoPaid.UI.Converters
{
    public class HistoryToColorConverter : MvxFormsValueConverter<List<Payment>, object>
    {
        protected override object Convert(List<Payment> value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.Count == 0)
                return StylesCache.Colors["Red"];

            return value.Last().IsPaid ? StylesCache.Colors["Green"] : StylesCache.Colors["Red"];
        }
    }
}
