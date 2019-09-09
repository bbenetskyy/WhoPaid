using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using WhoPaid.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhoPaid.UI.Pages
{
    public partial class UserPage : MvxContentPage<UserViewModel>
    {
        public UserPage()
        {
            InitializeComponent();
        }
    }
}