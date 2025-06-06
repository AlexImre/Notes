// select line
```
using EnvDTE;
using EnvDTE80;

public class C : VisualCommanderExt.ICommand
{
    public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    {
        var ts = DTE.ActiveDocument.Selection as EnvDTE.TextSelection;
        if (!ts.ActivePoint.AtStartOfLine)
            ts.StartOfLine();
        ts.LineDown(true, 1);
    }
}
```