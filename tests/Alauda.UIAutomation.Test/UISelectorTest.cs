namespace Alauda.UIAutomation.Test;

using Alauda.Native;
using Alauda.UIAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Automation;


/// <summary></summary>
[TestClass]
public class UISelectorTest
{ 
    // [TestMethod]
    // [DataRow("UIA Example Window", "clearMessageButton")]
    // [DataRow("UIA Example Window", "decideButton")]
    [TestMethod]
    [DataRow("Alauda Example Window", "exampleLayoutPanel,comboBox1")]
    [DataRow("Alauda Example Window", "comboBox2")]
    public void GetItemsTest(
            string windowText,
            string automationIds)
    {
        var aids = GetAutomationIds(automationIds);

        var wi = WindowInfo.Get().First(p => p.Text?.Contains(windowText) ?? false);
        var aeRoot = AutomationElement.FromHandle(wi.Handle);
        var aeSelector = aeRoot.FindByAutomationIds(aids) ?? throw new NullReferenceException();

        Debug.WriteLine($"DEBUG | {aeSelector.ToHandle().ToInt():X}");
        foreach(var item in UISelector.GetItems(aeSelector.ToHandle()))
        {
            Debug.WriteLine($"\tItem => {item}");
        }
    }

    /// <summary></summary>
    [TestMethod]
    [DataRow("Alauda Example Window", "exampleLayoutPanel,comboBox1", "#4")]
    [DataRow("Alauda Example Window", "comboBox2", "#1")]
    public void StringSelectTest(
            string windowText,
            string automationIds,
            string value)
    {
        var aids = GetAutomationIds(automationIds);
        var wi = WindowInfo.Get().First(wi => wi.Text?.Contains(windowText) ?? false);
        var aeRoot = AutomationElement.FromHandle(wi.Handle);
        var aeSelector = aeRoot.FindByAutomationIds(aids) ?? throw new NullReferenceException();

        var index = UISelector.StringSelect(aeSelector.ToHandle(), value, 0);

        Debug.WriteLine($"Result Index = {index}");
    }

    /// <summary></summary>
    [TestMethod]
    [DataRow("Alauda Example Window", "exampleLayoutPanel,comboBox1")]
    [DataRow("Alauda Example Window", "comboBox2")]
    public async Task ShowDropDownTest(
            string windowText,
            string automationIds)
    {
        var wi = FindWindowInfo(windowText);
        var aids = GetAutomationIds(automationIds);

        var ae = AutomationElement.FromHandle(wi.Handle)
            .FindByAutomationIds(aids) ?? throw new NullReferenceException();

        var ret = User32.SetForegroundWindow(wi.Handle);
        Debug.WriteLine($"SetForegroundWindow:PreviousWindowHandle {ret}");
        if(! ret)
            throw new System.ComponentModel.Win32Exception(Kernel32.GetLastError());

        UISelector.Expand(ae.ToHandle());

        await Task.Delay(1000);

        UISelector.Collapse(ae.ToHandle());
    }

    /// <summary></summary>
    private WindowInfo FindWindowInfo(string s) =>
        WindowInfo.Get().First(wi => wi.Text?.Contains(s) ?? false);

    /// <summary></summary>
    private string[] GetAutomationIds(
            string str,
            char c = ',') => str.Split(c)
        .Select(p => p.Trim())
        .Where(p => ! string.IsNullOrEmpty(p))
        .ToArray();
}
