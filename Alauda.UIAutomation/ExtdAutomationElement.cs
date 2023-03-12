namespace Alauda.UIAutomation;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;


/// <summary></summary>
public static class ExtdAutomationElement
{
    /// <summary></summary>
    public static IntPtr ToHandle(this AutomationElement ae) =>
        new IntPtr(ae.Current.NativeWindowHandle);

    /// <summary></summary>
    public static AutomationElement? FindByAutomationIds(
            this AutomationElement aeRoot,
            params string[] automationIds)
    {
        if(! automationIds.Any())
            return null;

        AutomationElement? aeChild = aeRoot;

        foreach(var automationId in automationIds)
        {
            var ae = aeChild.FindFirst(
                    scope: TreeScope.Children,
                    condition: new PropertyCondition(
                        AutomationElement.AutomationIdProperty,
                        automationId));

            if(ae == null)
                break;

            aeChild = ae;
        }

        return (aeChild == aeRoot) ? null : aeChild;
    }
}
