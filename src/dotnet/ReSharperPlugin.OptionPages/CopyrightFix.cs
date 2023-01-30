using System;
using JetBrains.Annotations;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Cpp.QuickFixes;
using JetBrains.ReSharper.Feature.Services.QuickFixes;
using JetBrains.ReSharper.Psi.Cpp.Parsing;
using JetBrains.ReSharper.Psi.Cpp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.TextControl;
using JetBrains.Util;

namespace ReSharperPlugin.OptionPages;

[QuickFix]
public class CopyrightFix : CppQuickFixBase
{
    private ITreeNode Node;
    
    public override string Text => "Add copyright notice.";

    public CopyrightFix(ITreeNode node)
    {
        Node = node;
    }

    public CopyrightFix([NotNull] CopyrightHighlighting highlighting)
    {
        Node = highlighting.FirstLine;
    }

    private static Action<ITextControl> ExecutePsiTransactionImpl(ITreeNode node)
    {
        var copyrightComment = new CppCommentTokenNode(CppTokenNodeTypes.GENERATED_COMMENT, Settings.TempCopyright);
        using (WriteLockCookie.Create("CopyrightFix.cs"))
        {
            //todo: add copyright at the beginning of the file(get beginning from node)
            CppModificationUtil.AddChildBefore(node, copyrightComment, false);
        }
        return null;
    }

    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        return ExecutePsiTransactionImpl(Node);
    }

    public override bool IsAvailable(IUserDataHolder cache)
    {
        return true;
    }
}