using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using WhoPaid.Core.Models;
using WhoPaid.Core.Services;
using WhoPaid.ReactiveUI.Interop;
using ReactiveUI;

namespace WhoPaid.Core.ViewModels
{
    public class HomeViewModel : MvxReactiveViewModel
    {
        private readonly ObservableAsPropertyHelper<List<TaxPayer>> _taxPayers;
        public List<TaxPayer> TaxPayers => _taxPayers.Value;

        public ReactiveCommand<Unit, List<TaxPayer>> LoadTaxPayersCommand { get; }

        public HomeViewModel()
        {
            LoadTaxPayersCommand = ReactiveCommand.Create<Unit, List<TaxPayer>>(_ => LoadTaxPayers());
            //LoadTaxPayersCommand.ThrownExceptions.Subscribe(DisplayError);

            _taxPayers = LoadTaxPayersCommand.ToProperty(this, nameof(TaxPayers));
        }

        public override Task Initialize()
        {
            LoadTaxPayersCommand.Execute().Subscribe();
            return base.Initialize();
        }

        private List<TaxPayer> LoadTaxPayers()
        {
            return new List<TaxPayer>
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
            };
        }
    }
}
