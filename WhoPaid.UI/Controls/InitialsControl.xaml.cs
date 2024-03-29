﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoPaid.UI.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhoPaid.UI.Controls
{
    public partial class InitialsControl : Grid
    {
        public static readonly BindableProperty BackColorProperty
            = BindableProperty.Create(nameof(BackColor), typeof(Color), typeof(InitialsControl),
                StylesCache.Colors["Red"], propertyChanged: (b, _, newValue) => (b as InitialsControl)?.SetBackColor((Color)newValue));

        public Color BackColor
        {
            get => (Color)GetValue(BackColorProperty);
            set => SetValue(BackColorProperty, value);
        }

        public static readonly BindableProperty NameProperty
            = BindableProperty.Create(nameof(Name), typeof(string), typeof(InitialsControl), string.Empty, propertyChanged: (b, _, newValue) => (b as InitialsControl)?.SetName((string)newValue));

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public InitialsControl()
        {
            InitializeComponent();
        }

        private void SetBackColor(Color color)
        {
            ContentBoxView.BackgroundColor = color;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ContentLabel.Text = string.Empty;
                return;
            }

            var words = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 1)
            {
                ContentLabel.Text = words[0][0].ToString();
            }
            else if (words.Length > 1)
            {
                var initialsString = words[0][0] + words[words.Length - 1][0].ToString();
                ContentLabel.Text = initialsString;
            }
            else
            {
                ContentLabel.Text = string.Empty;
            }
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Math.Abs(WidthRequest - (-1)) < 0.01 || Math.Abs(HeightRequest - (-1)) < 0.01)
            {
                InitControl(50);
            }
            else
            {
                InitControl(Math.Min(WidthRequest, HeightRequest));
            }
        }

        private void InitControl(double size)
        {
            ContentBoxView.HeightRequest = size;
            ContentBoxView.WidthRequest = size;

            ContentBoxView.CornerRadius = size / 2;

            ContentBoxView.BackgroundColor = BackColor;

            ContentLabel.FontSize = size / 2 - 5;

            if (!string.IsNullOrEmpty(Name))
                SetName(Name);
        }
    }
}