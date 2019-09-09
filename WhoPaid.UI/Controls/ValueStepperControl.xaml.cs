using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhoPaid.UI.Controls
{
    public partial class ValueStepperControl : ContentView
    {
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value),
            typeof(int), typeof(ValueStepperControl), 0, BindingMode.TwoWay,
            propertyChanged: OnValueChanged);

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public ValueStepperControl()
        {
            InitializeComponent();
        }

        private void Button_Minus_OnClicked(object sender, EventArgs e)
        {
            Value--;
        }

        private void Button_Plus_OnClicked(object sender, EventArgs e)
        {
            Value++;
        }

        private static void OnValueChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is ValueStepperControl stepper)
            {
                stepper.ValueLabel.Text = stepper.Value.ToString();
            }
        }

    }
}