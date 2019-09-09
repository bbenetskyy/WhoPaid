using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using WhoPaid.Core.Models;
using WhoPaid.Core.Services;
using WhoPaid.ReactiveUI.Interop;
using ReactiveUI;

namespace WhoPaid.Core.ViewModels
{
    public class HomeViewModel : MvxReactiveViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ObservableAsPropertyHelper<MvxObservableCollection<TaxPayer>> _taxPayers;
        public MvxObservableCollection<TaxPayer> TaxPayers => _taxPayers.Value;

        public ReactiveCommand<Unit, MvxObservableCollection<TaxPayer>> LoadTaxPayersCommand { get; }

        public ReactiveCommand<Unit, TaxPayer> AddTaxPayerCommand { get; }

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            LoadTaxPayersCommand = ReactiveCommand.Create<Unit, MvxObservableCollection<TaxPayer>>(_ => LoadTaxPayers());
            //LoadTaxPayersCommand.ThrownExceptions.Subscribe(DisplayError);

            AddTaxPayerCommand = ReactiveCommand.CreateFromTask<Unit, TaxPayer>(_ =>
                _navigationService.Navigate<UserViewModel, TaxPayer>());
            //AddTaxPayerCommand.ThrownExceptions.Subscribe(DisplayError);
            AddTaxPayerCommand.Subscribe(x => TaxPayers.Add(x));

            _taxPayers = LoadTaxPayersCommand.ToProperty(this, nameof(TaxPayers));
        }

        public override Task Initialize()
        {
            LoadTaxPayersCommand.Execute().Subscribe();
            return base.Initialize();
        }

        private MvxObservableCollection<TaxPayer> LoadTaxPayers()
        {
            return new MvxObservableCollection<TaxPayer>(new List<TaxPayer>
            {
                new TaxPayer
                {
                    FullName = "Bohdan Benetskyi",
                    MonthRate = 120,
                    PaymentHistory = new List<Payment>
                    {
                        new Payment{IsPaid = true},
                        new Payment{IsPaid = true},
                        new Payment{IsPaid = false},
                        new Payment{IsPaid = false},
                    }
                },
                new TaxPayer
                {
                    FullName = "Iia Benetskya",
                    MonthRate = 500,
                    PaymentHistory = new List<Payment>
                    {
                        new Payment{IsPaid = true},
                        new Payment{IsPaid = true},
                        new Payment{IsPaid = true},
                    }
                },
                new TaxPayer
                {
                    FullName = "Ruslan Benetskyi",
                    MonthRate = 0,
                    PaymentHistory = new List<Payment>
                    {
                        new Payment{IsPaid = true},
                        new Payment{IsPaid = true},
                        new Payment{IsPaid = true},
                        new Payment{IsPaid = true},
                        new Payment{IsPaid = false},
                        new Payment{IsPaid = false},
                        new Payment{IsPaid = false},
                        new Payment{IsPaid = false},
                        new Payment{IsPaid = false},
                    }
                }
            });
        }
    }
}
