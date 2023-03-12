namespace Alauda.UIAutomation.Test;

using Alauda.Native;
using Alauda.UIAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Automation;


/// <summary></summary>
[TestClass]
public class UIButtonTest
{
    /// <summary></summary>
    [TestMethod]
    [DataRow("UIA Example Window", "clearMessageButton")]
    [DataRow("UIA Example Window", "decideButton")]
    public void ClickTest(
            string targetWindowText,
            string buttonId)
    {
        var wi = Find(targetWindowText);
        Debug.WriteLine($"DEBUG | Handle = {wi.Handle.ToInt():X}");

        var aeButton = AutomationElement.FromHandle(wi.Handle)
            .FindByAutomationIds(buttonId) ?? throw new NullReferenceException();

        Debug.WriteLine($"DEBUG | Button Handle = {aeButton.ToHandle():X}");
    }

    [TestMethod]
    [DataRow("Alauda Example Window", "exampleCheck", true)]
    [DataRow("Alauda Example Window", "exampleCheck", false)]
    [DataRow("UIA", "exampleCheckBox", false)]
    public void CheckTest(string w, string a, bool state)
    {
        var hCheckBox = AutomationElement.FromHandle(Find(w).Handle)
            .FindByAutomationIds(a)?
            .ToHandle() ?? throw new NullReferenceException();

        var prev = UIButton.IsChecked(hCheckBox);
        var ret  = UIButton.Check(hCheckBox, state);

        //Debug.WriteLine(User32.GetClassName(hCheckBox));
        Debug.WriteLine($"DEBUG | {hCheckBox.ToInt():X}(PREV#{prev}) ret = {ret}");
    }

    //
    private WindowInfo Find(string s) => WindowInfo
        .Get()
        .FirstOrDefault(wi => wi.Text?.Contains(s) ?? false) ?? throw new NullReferenceException();
}
