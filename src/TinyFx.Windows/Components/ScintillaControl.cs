using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;
using System.Drawing;

namespace TinyFx.Windows.Components
{
    /// <summary>
    /// ScintillaNET封装控件
    /// </summary>
    public partial class ScintillaControl : Scintilla
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ScintillaControl()
        {
            InitializeComponent();
            SetStyle();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="container"></param>
        public ScintillaControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            SetStyle();
        }

        private void SetStyle()
        {
            Dock = System.Windows.Forms.DockStyle.Fill;
            HScrollBar = true;
            WrapMode = WrapMode.Whitespace;

            #region C#

            Lexer = Lexer.Cpp;
            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            StyleResetDefault();
            Styles[Style.Default].Font = "Consolas";
            Styles[Style.Default].Size = 10;
            StyleClearAll();

            // Configure the CPP (C#) lexer styles
            Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            Lexer = Lexer.Cpp;

            // Set the keywords
            SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
            #endregion

            #region 行号

            Margins[0].Cursor = MarginCursor.ReverseArrow;
            Margins[0].Type = MarginType.Number;
            Margins[0].Width = 35;
            TabIndex = 4;
            #endregion

            // Instruct the lexer to calculate folding
            SetProperty("fold", "1");
            SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            Margins[2].Type = MarginType.Symbol;
            Margins[2].Mask = Marker.MaskFolders;
            Margins[2].Sensitive = true;
            Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                Markers[i].SetForeColor(SystemColors.ControlLightLight);
                Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private int _maxLineNumberCharLength;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this._maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            Margins[0].Width = TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this._maxLineNumberCharLength = maxLineNumberCharLength;

            base.OnTextChanged(e);
        }
    }
}
