using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.Tree;

namespace ReSharperPlugin.OptionPages;

[ElementProblemAnalyzer(typeof(ITreeNode),
    HighlightingTypes = new[] { typeof(CopyrightHighlighting) })]

public class CopyrightProblemAnalyzer : ElementProblemAnalyzer<ITreeNode>
{
    protected override void Run(ITreeNode element, ElementProblemAnalyzerData data, IHighlightingConsumer consumer)
    {
        var isFirstLine = element.GetDocumentRange().StartOffset.Offset == 0;
        if (!isFirstLine)
        {
            return;
        }

        if (!element.GetText().StartsWith(Settings.TempCopyright))
        {
            consumer.AddHighlighting(new CopyrightHighlighting(element));
        }
    }
}