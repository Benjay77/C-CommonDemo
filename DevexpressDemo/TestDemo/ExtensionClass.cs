using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TestDemo
{
    static class ExtensionClass
    {
        /// <summary>
        /// 跨线程方法
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        static public void UIThread(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
                return;
            }
            action.Invoke();
        }
    }
}
