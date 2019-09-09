using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using Xamarin.Forms;

namespace WhoPaid.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
        protected override void RunAppStart(object hint = null)
        {
            base.RunAppStart(hint);

            FormsMaterial.Init();
        }
    }
}
