using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TinyFx.Windows.Components
{
    /// <summary>
    /// TextBox控件Trace侦听器
    /// </summary>
    public class TextBoxTraceListener : TraceListener
    {
        /// <summary>
        /// 抛出的异常
        /// </summary>
        public bool ThrowException { get; set; }
        private TextBox _control;
        private Action<string> _outputString;
        /// <summary>
        /// 最大行数
        /// </summary>
        public int MaxLines { get; set; } = 500;
        /// <summary>
        /// 空最大行数
        /// </summary>
        public bool EmptyOnMaxLines { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="target"></param>
        public TextBoxTraceListener(TextBox target)
        {
            ThrowException = false;
            EmptyOnMaxLines = false;
            _control = target;
            _outputString = OutputString;
        }
        /// <summary>
        /// 创建一个侦听器并添加到侦听器集合中
        /// </summary>
        /// <param name="target"></param>
        public static void AddTraceListeners(TextBox target)
        {
            var listener = new TextBoxTraceListener(target);
            Trace.Listeners.Add(listener);
        }
        private void OutputString(string message)
        {
            if (MaxLines != 0 && _control.Lines.Length > MaxLines)
            {
                if (EmptyOnMaxLines)
                {
                    _control.Text = string.Empty;
                }
                else
                {
                    int start = _control.GetFirstCharIndexFromLine(0);
                    int end = _control.GetFirstCharIndexFromLine(1);
                    _control.Select(start, end);
                    _control.SelectedText = string.Empty;
                }
            }
            _control.AppendText(message);
        }
        /// <summary>
        /// 写入信息
        /// </summary>
        /// <param name="message"></param>
        public override void Write(string message)
        {
            try
            {
                _control.Invoke(_outputString, message);

            }
            catch
            {
                if (ThrowException)
                    throw;
            }
        }
        /// <summary>
        /// 写行信息
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message)
        {
            try
            {
                _control.Invoke(_outputString, message + Environment.NewLine);

            }
            catch
            {
                if (ThrowException)
                    throw;
            }
        }
    }

}
