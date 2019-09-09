using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using WhoPaid.Core.Models;
using WhoPaid.ReactiveUI.Interop;

namespace WhoPaid.Core.ViewModels
{
    public class UserViewModel : MvxReactiveViewModel<Unit, TaxPayer>
    {
        private readonly IMvxNavigationService _navigationService;

        public UserViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(Unit parameter)
        {
        }

        public override void ViewAppeared()
        {
            //_navigationService.Close(this, new TaxPayer
            //{
            //    MonthRate = 300,
            //    FullName = "Test",
            //    PaymentHistory = new List<Payment>
            //    {
            //        new Payment {IsPaid = true}
            //    }
            //});
        }
    }
}
