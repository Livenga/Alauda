namespace Alauda.UIAutomation.Test;

using Alauda.Native;
using Alauda.UIAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;


/// <summary></summary>
[TestClass]
public class UITextTest
{
    /// <summary></summary>
    [TestMethod]
    [DataRow("UIA Example Window", "exampleText", null)]
    [DataRow("Alauda Example Window", "normalText", null)]
    //[DataRow("Alauda", "textBox1", null)]
    public void SetTextTest(
            string windowText,
            string automationId,
            string? value)
    {
        var wi = Find(windowText);

        var hText = AutomationElement.FromHandle(wi.Handle)
            .FindByAutomationIds(ParseIds(automationId))?
            .ToHandle() ?? throw new NullReferenceException();

        UIText.SetText(hText, value ?? Guid.NewGuid().ToString());
    }


    /// <summary></summary>
    [TestMethod]
    [DataRow("Alauda Example Window", "normalText", 10)]
    [DataRow("Alauda Example Window", "exampleLayoutPanel,textBox1", 10)]
    public async Task ChangeTestAsync(string w, string i, int count)
    {
        var wi = Find(w);
        var aids = ParseIds(i);

        var hText = AutomationElement.FromHandle(wi.Handle)
            .FindByAutomationIds(aids)?
            .ToHandle() ?? throw new NullReferenceException();

        for(var idx = 0; idx < count; ++idx)
        {
            UIText.Change(hText);

            await Task.Delay(500, CancellationToken.None);
        }
    }

    /// <summary></summary>
    private WindowInfo Find(string s) => WindowInfo.Get().First(wi => wi.Text?.Contains(s) ?? false);

    /// <summary></summary>
    private string[] ParseIds(string s, char c = ',') => s.Split(c)
        .Select(s => s.Trim())
        .Where(s => ! string.IsNullOrEmpty(s)).ToArray();
}
