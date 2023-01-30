using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.Tree;

namespace ReSharperPlugin.OptionPages;

//todo: add navigation through camel case words
[RegisterConfigurableSeverity(CopyrightHighlighting.SeverityId,
null,
HighlightingGroupIds.CodeStyleIssues,
"Add Copyright Notice",
"Any source file (.h, .cpp, .xaml, etc.) provided by Epic for distribution must contain a copyright notice as the first line in the file.",
Severity.SUGGESTION)]
[ConfigurableSeverityHighlighting(SeverityId, CSharpLanguage.Name, OverlapResolve = OverlapResolveKind.WARNING)]
public class CopyrightHighlighting : IHighlighting
{
    public ITreeNode FirstLine { get; set; }
    private const string SeverityId = "AddCopyrightNotice";

    public CopyrightHighlighting(ITreeNode firstLine)
    {
        FirstLine = firstLine;
    }

    public DocumentRange CalculateRange() => FirstLine.GetDocumentRange();

    public string ToolTip => "No copyright notice found.";

    public string ErrorStripeToolTip => ToolTip;

    public bool IsValid() => FirstLine == null || FirstLine.IsValid();
    
    
}