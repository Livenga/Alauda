namespace Alauda.Native.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;


/// <summary></summary>
[TestClass]
public class WindowInfoTest
{
    /// <summary></summary>
    [TestMethod]
    public void GetTest()
    {
        var windowInfos = WindowInfo.Get();
        foreach(var wi in windowInfos
                .Where(wi => wi.IsVisible))
        {
            Debug.WriteLine($"{wi.Text} {wi.Handle.ToInt():X} {wi.ProcessId}#{wi.ThreadId}");
            try
            {
                var className = User32.GetClassName(wi.Handle);
                Debug.WriteLine($"\t{className}");
            }
            catch { }
        }
    }
}
