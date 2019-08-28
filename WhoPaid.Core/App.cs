using MvvmCross.IoC;
using MvvmCross.ViewModels;
using WhoPaid.Core.ViewModels.Home;

namespace WhoPaid.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
