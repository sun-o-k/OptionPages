using JetBrains.Application.UI.Controls.FileSystem;
using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.OptionsDialog;
using JetBrains.IDE.UI;
using JetBrains.IDE.UI.Options;
using JetBrains.Lifetimes;
using JetBrains.ReSharper.Feature.Services.Daemon.OptionPages;
using JetBrains.ReSharper.UnitTestFramework.Resources;

namespace ReSharperPlugin.OptionPages;

[OptionsPage(PID, PageTitle, typeof(UnitTestingThemedIcons.Session), ParentId = CodeInspectionPage.PID)]
public class SashaPage : BeSimpleOptionsPage
{

    private const string PID = nameof(SashaPage);
    private const string PageTitle = "Pretty little page";
    
    public SashaPage(Lifetime lifetime,
        OptionsPageContext optionsPageContext,
        OptionsSettingsSmartContext optionsSettingsSmartContext,
        IconHostBase iconHost,
        ICommonFileDialogs dialogs)
        : base(lifetime, optionsPageContext, optionsSettingsSmartContext)
    {
        AddText("Kill me, please.");
    }
}