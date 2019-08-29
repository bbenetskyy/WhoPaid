using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoPaid.UI.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhoPaid.UI.Controls
{
    public partial class StateControl : Label
    {
        public static readonly BindableProperty IsPaidProperty
            = BindableProperty.Create(nameof(IsPaid), typeof(bool), typeof(InitialsControl),
                false, BindingMode.TwoWay);

        public Color IsPaid
        {
            get => (Color)GetValue(IsPaidProperty);
            set => SetValue(IsPaidProperty, value);
        }

        public StateControl()
        {
            InitializeComponent();
        }
    }
}