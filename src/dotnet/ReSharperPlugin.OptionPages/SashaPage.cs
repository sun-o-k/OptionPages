using System;
using System.Linq.Expressions;
using JetBrains.Application.Settings;
using JetBrains.Application.UI.Controls.FileSystem;
using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.OptionsDialog;
using JetBrains.DataFlow;
using JetBrains.IDE.UI;
using JetBrains.IDE.UI.Extensions;
using JetBrains.IDE.UI.Options;
using JetBrains.Lifetimes;
using JetBrains.ReSharper.Feature.Services.Daemon.OptionPages;
using JetBrains.ReSharper.UnitTestFramework.Resources;
using JetBrains.Rider.Model.UIAutomation;

namespace ReSharperPlugin.OptionPages;

[OptionsPage(PID, PageTitle, typeof(UnitTestingThemedIcons.Session), ParentId = CodeInspectionPage.PID)]
public class SashaPage : BeSimpleOptionsPage
{

    private const string PID = nameof(SashaPage);
    private const string PageTitle = "Pretty little page";

    private readonly Lifetime _lifetime;
    
    public SashaPage(Lifetime lifetime,
        OptionsPageContext optionsPageContext,
        OptionsSettingsSmartContext optionsSettingsSmartContext,
        IconHostBase iconHost,
        ICommonFileDialogs dialogs)
        : base(lifetime, optionsPageContext, optionsSettingsSmartContext)
    {
        _lifetime = lifetime;
        AddTextBox((Settings x) => x.CopyrightNotice, "Copyright notice");
    }

    private BeTextBox AddTextBox<TKeyClass>(Expression<Func<TKeyClass, string>> lambdaExpression, string description)
    {
        var property = new Property<string>(description);
        OptionsSettingsSmartContext.SetBinding(_lifetime, lambdaExpression, property);
        var control = property.GetBeTextBox(_lifetime);
        AddControl(control.WithDescription(description, _lifetime));
        return control;
    }
}