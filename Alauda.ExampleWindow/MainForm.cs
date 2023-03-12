namespace Alauda.ExampleWindow;

using Alauda.ExampleWindow.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary></summary>
public partial class MainForm : Form
{
    /// <summary></summary>
    public MainForm()
    {
        InitializeComponent();
    }


    /// <summary></summary>
    private void OnCommonTextChanged(object source, EventArgs e)
    {
        if(source is TextBox tbx)
        {
            statusLabel.Text = $"[{DateTime.Now.ToString("MM-dd HH:mm:ss.ff")}] {tbx.Name}.TextChanged ({tbx.Text})";
        }
    }

    /// <summary></summary>
    private void OnCommonValidated(object source, EventArgs e)
    {
    }

    /// <summary></summary>
    private void OnExitMenuClick(object source, EventArgs e)
    {
        Close();
    }

    /// <summary></summary>
    private void OnLoad(object source, EventArgs e)
    {
    }

    /// <summary></summary>
    private void OnShown(object source, EventArgs e)
    {
    }

    /// <summary></summary>
    private void OnExampleCheckCheckedChanged(object source, EventArgs e)
    {
        if(source is CheckBox cbx)
        {
            statusLabel.Text = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff")}] {cbx.Name} CheckedChanged {cbx.Checked}";
        }
    }

    /// <summary></summary>
    private void OnClearMessageClick(object source, EventArgs e)
    {
        statusLabel.Text = "###";
    }

    /// <summary></summary>
    private void OnApplyClick(object source, EventArgs e)
    {
    }


    /// <summary></summary>
    protected override void WndProc(ref Message m)
    {
        Debug.WriteLine($"{m.HWnd.ToInt():X} 0x{m.Msg:X8} {(ulong)m.WParam.ToInt():X} {(ulong)m.LParam.ToInt():X}");

        if(m.Msg == 0x0111)
        {
            var code = m.WParam.ToInt32();
            var cid = code & 0xffff;
            var message = (code >> 16) & 0xffff;

            var _cid = Alauda.Native.User32.GetDlgCtrlID(m.LParam);
            Debug.WriteLine($"\t0x{message:X4} {cid}({cid:X4})");
            Debug.WriteLine($"\t{Alauda.Native.User32.GetParent(m.LParam):X} {_cid:X}");
        }

        base.WndProc(ref m);
    }
}
