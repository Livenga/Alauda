namespace Alauda.UIAutomation;

using Alauda.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;


/// <summary></summary>
public static class UIButton
{
    /// <summary></summary>
    public static void Click(
            IntPtr hBtn,
            IntPtr hRoot = default(IntPtr))
    {
        IntPtr hPrev = IntPtr.Zero;
        if(IntPtr.Zero != hRoot)
            hPrev = User32.SetActiveWindow(hRoot);

        User32.SendMessage(
                hBtn,
                0x00F5/* BM_CLICK */,
                IntPtr.Zero,
                IntPtr.Zero);

        if(hPrev != IntPtr.Zero)
            User32.SetActiveWindow(hPrev);
    }

    /// <summary></summary>
    public static bool Check(
            IntPtr hWnd,
            bool   isCheck)
    {
        var togglePattern = AutomationElement.FromHandle(hWnd)
            .GetCurrentPattern(TogglePattern.Pattern) as TogglePattern ?? throw new NullReferenceException();

        switch(togglePattern.Current.ToggleState)
        {
            case ToggleState.On:
                if(! isCheck)
                    togglePattern.Toggle();
                break;

            case ToggleState.Off:
                if(isCheck)
                    togglePattern.Toggle();
                break;
        }

        // TODO イベント送信
        return true;
    }

    /// <summary></summary>
    public static bool IsChecked(IntPtr hWnd)
    {
        var togglePattern = AutomationElement.FromHandle(hWnd)
            .GetCurrentPattern(TogglePattern.Pattern) as TogglePattern ?? throw new NullReferenceException();

        return togglePattern.Current.ToggleState switch
        {
            ToggleState.On => true,
            _ => false
        };
    }
}
