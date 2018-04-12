using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace TinyFx.Windows.Win32
{
    /// <summary>
    /// 常用 Windows API 函数声明
    /// </summary>
    public static class Win32API
    {
        #region Constans values
        public const string TOOLBARCLASSNAME = "ToolbarWindow32";
        public const string REBARCLASSNAME = "ReBarWindow32";
        public const string PROGRESSBARCLASSNAME = "msctls_progress32";
        public const string SCROLLBAR = "SCROLLBAR";
        #endregion

        #region CallBacks
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Kernel32.dll functions
        /// <summary>
        /// 修改当前时间
        /// </summary>
        /// <param name="lpSystemTime"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetCurrentThreadId();
        #endregion

        #region Gdi32.dll functions
        /// <summary>
        /// 函数从源矩形中复制一个位图到目标矩形，必要时按目前目标设备设置的模式进行图像的拉伸或压缩
        /// </summary>
        /// <remarks>
        /// 函数原型：BOOL StretchBlt(HDC hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeighDest, HDC hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, DWORD dwRop)；
        /// </remarks>
        /// <param name="hdcDest">指向目标设备环境的句柄</param>
        /// <param name="nXOriginDest">指定目标矩形左上角的X轴坐标，按逻辑单位表示坐标</param>
        /// <param name="nYOriginDest">指定目标矩形左上角的X轴坐标，按逻辑单位表示坐标</param>
        /// <param name="nWidthDest">指定目标矩形的宽度，按逻辑单位表示宽度</param>
        /// <param name="nHeighDest">指定目标矩形的高度，按逻辑单位表示高茺</param>
        /// <param name="hdcSrc">指向源设备环境的句柄</param>
        /// <param name="nXOriginSrc">指向源矩形区域左上角的X轴坐标，按逻辑单位表示坐标</param>
        /// <param name="nYOriginSrc">指向源矩形区域左上角的Y轴坐标，按逻辑单位表示坐标</param>
        /// <param name="nWidthSrc">指定源矩形的宽度，按逻辑单位表示宽度</param>
        /// <param name="nHeightSrc">指定源矩形的高度，按逻辑单位表示高度</param>
        /// <param name="dwRop">指定要进行的光栅操作。光栅操作码定义了系统如何在输出操作中组合颜色，这些操作包括刷子、源位图和目标位图等对象。参考BitBlt可了解常用的光栅操作码列表</param>
        /// <returns>如果函数执行成功，那么返回值为非零，如果函数执行失败，那么返回值为零。Windows NT：若想获得更多的错误信息，请调用GetLastError函数</returns>
        [DllImport("gdi32.dll")]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeighDest
            , IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop);
        
        /// <summary>
        /// 该函数创建一个与指定设备兼容的内存设备上下文环境（DC）。
        /// </summary>
        /// <remarks>
        /// 函数原型：HDC CreateCompatibleDC(HDC hdc)；
        /// 注释：内存设备上下文环境是仅在内存中存在的设备上下文环境，当内存设备上下文环境被创建时，它的显示界面是标准的一个单色像素宽和一个单色像素高，在一个应用程序可以使用内存设备上下文环境进行绘图操作之前，它必须选择一个高和宽都正确的位图到设备上下文环境中，这可以通过使用CreateCompatibleBitmap函数指定高、宽和色彩组合以满足函数调用的需要。
        /// 当一个内存设备上下文环境创建时，所有的特性都设为缺省值，内存设备上下文环境作为一个普通的设备上下文环境使用，当然也可以设置这些特性为非缺省值，得到它的特性的当前设置，为它选择画笔，刷子和区域。
        /// CreateCompatibleDc函数只适用于支持光栅操作的设备，应用程序可以通过调用GetDeviceCaps函数来确定一个设备是否支持这些操作。
        /// 当不再需要内存设备上下文环境时，可调用DeleteDc函数删除它。
        /// ICM：如果通过该函数的hdc参数传送给该函数设备上下文环境(Dc)对于独立颜色管理（ICM）是能用的，则该函数创建的设备上下文环境(Dc)是ICM能用的，资源和目标颜色间隔是在Dc中定义。
        /// </remarks>
        /// <param name="hdc">现有设备上下文环境的句柄，如果该句柄为NULL，该函数创建一个与应用程序的当前显示器兼容的内存设备上下文环境</param>
        /// <returns>如果成功，则返回内存设备上下文环境的句柄；如果失败，则返回值为NULL</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        
        /// <summary>
        /// 该函数创建与指定的设备环境相关的设备兼容的位图
        /// </summary>
        /// <remarks>
        ///  函数原型：HBITMAP CreateCompatibleBitmap(HDC hdc,int nWidth,int nHeight)；
        /// 由CreateCompatibleBitmap函数创建的位图的颜色格式与由参数hdc标识的设备的颜色格式匹配。该位图可以选入任意一个与原设备兼容的内存设备环境中。由于内存设备环境允许彩色和单色两种位图。因此当指定的设备环境是内存设备环境时，由CreateCompatibleBitmap函数返回的位图格式不同。然而为非内存设备环境创建的兼容位图通常拥有相同的颜色格式，并且使用与指定的设备环境一样的色彩调色板。
        /// </remarks>
        /// <param name="hdc">设备环境句柄</param>
        /// <param name="nWidth">指定位图的宽度，单位为像素</param>
        /// <param name="nHeight">指定位图的高度，单位为像素。</param>
        /// <returns>如果函数执行成功，那么返回值是位图的句柄；如果函数执行失败，那么返回值为NULL。若想获取更多错误信息，请调用GetLastError</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        
        /// <summary>
        /// 该函数选择一对象到指定的设备上下文环境中，该新对象替换先前的相同类型的对象。
        /// </summary>
        /// <remarks>
        /// 函数原型：HGDIOBJ SelectObject(HDC hdc, HGDIOBJ hgdiobj)；
        /// 该函数返回先前指定类型的选择对象，一个应用程序在它使用新对象进行绘制完成之后，应该用新对象替换原始的缺省的对象。
        /// 应用程序不能同时选择一个位图到多个设备上下文环境中。
        /// ICM：如果被选择的对象是画笔或笔，那么就执行颜色管理。
        /// </remarks>
        /// <param name="hdc">设备上下文环境的句柄。</param>
        /// <param name="hgdiobj">
        /// 被选择的对象的句型，该指定对象必须由如下的函数创建。
        /// 位图：CreateBitmap, CreateBitmapIndirect, CreateCompatible Bitmap, CreateDIBitmap, CreateDIBsection（只有内存设备上下文环境可选择位图，并且在同一时刻只能一个设备上下文环境选择位图）。
        /// 画笔：CreateBrushIndirect, CreateDIBPatternBrush, CreateDIBPatternBrushPt, CreateHatchBrush, CreatePatternBrush, CreateSolidBrush。
        /// 字体：CreateFont, CreateFontIndirect。
        /// 笔：CreatePen, CreatePenIndirect。
        /// 区域：CombineRgn, CreateEllipticRgn, CreateEllipticRgnIndirect, CreatePolygonRgn, CreateRectRgn, CreateRectRgnIndirect。
        /// </param>
        /// <returns>
        /// 如果选择对象不是区域并且函数执行成功，那么返回值是被取代的对象的句柄；如果选择对象是区域并且函数执行成功，返回如下一值；
        /// SIMPLEREGION：区域由单个矩形组成；COMPLEXREGION：区域由多个矩形组成。NULLREGION：区域为空。
        /// 如果发生错误并且选择对象不是一个区域，那么返回值为NULL，否则返回GDI_ERROR。
        /// </returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        
        /// <summary>
        /// 该函数对指定的源设备环境区域中的像素进行位块（bit_block）转换，以传送到目标设备环境。
        /// </summary>
        /// <remarks>
        /// 函数原型：BOOL BitBlt(HDC hdcDest,int nXDest,int nYDest,int nWidth,int nHeight,HDC hdcSrc,int nXSrc,int nYSrc,DWORD dwRop)；
        /// 如果在源设备环境中可以实行旋转或剪切变换，那么函数BitBlt返回一个错误。如果存在其他变换（并且目标设备环境中匹配变换无效），那么目标设备环境中的矩形区域将在需要时进行拉伸、压缩或旋转。
        /// 如果源和目标设备环境的颜色格式不匹配，那么BitBlt函数将源场景的颜色格式转换成能与目标格式匹配的格式。当正在记录一个增强型图元文件时，如果源设备环境标识为一个增强型图元文件设备环境，那么会出现错误。如果源和目标设备环境代表不同的设备，那么BitBlt函数返回错误。
        /// </remarks>
        /// <param name="hdcDest">指向目标设备环境的句柄</param>
        /// <param name="nXDest">指定目标矩形区域左上角的X轴逻辑坐标</param>
        /// <param name="nYDest">指定目标矩形区域左上角的Y轴逻辑坐标</param>
        /// <param name="nWidth">指定源和目标矩形区域的逻辑宽度</param>
        /// <param name="nHeight">指定源和目标矩形区域的逻辑高度</param>
        /// <param name="hdcSrc">指向源设备环境的句柄</param>
        /// <param name="nXSrc">指定源矩形区域左上角的X轴逻辑坐标</param>
        /// <param name="nYSrc">指定源矩形区域左上角的Y轴逻辑坐标</param>
        /// <param name="dwRop">指定光栅操作代码。这些代码将定义源矩形区域的颜色数据，如何与目标矩形区域的颜色数据组合以完成最后的颜色</param>
        /// <returns>如果函数成功，那么返回值非零；如果函数失败，则返回值为零</returns>
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight
            , IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
        
        /// <summary>
        /// 该函数删除指定的设备上下文环境（Dc）
        /// </summary>
        /// <remarks>
        /// 函数原型：BOOL DeleteDC(HDC hdc)；
        /// 如果一个设备上下文环境的句柄是通过调用GetDC函数得到的，那么应用程序不能删除该设备上下文环境，它应该调用ReleaseDC函数来释放该设备上下文环境
        /// </remarks>
        /// <param name="hdc">设备上下文环境的句柄</param>
        /// <returns>成功，返回非零值；失败，返回零</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteDC(IntPtr hdc);
        
        /// <summary>
        /// 该函数使用当前选入指定设备环境中的刷子绘制给定的矩形区域。通过使用给出的光栅操作来对该刷子的颜色和表面颜色进行组合
        /// </summary>
        /// <remarks>
        /// 函数原型：BOOL PatBlt(HDC hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, DWORD dwRop)；
        /// 备注：该函数的参数dwRop取值限定为全部256个三元光栅操作有限子集。特别地，涉及源矩形的操作码不能使用。
        /// 并非所有设备都支持PalBlt函数。有关更多的信息，请参考函数GetDeviceCaps中有关RC_BITBLT特性的描述。
        /// </remarks>
        /// <param name="hdc">设备环境句柄</param>
        /// <param name="nXLeft">指定要填充的矩形左上角的X轴坐标，坐标按逻辑单位表示</param>
        /// <param name="nYLeft">指定要填充的矩形左上角的Y轴坐标，坐标按逻辑单位表示</param>
        /// <param name="nWidth">指定矩形的宽度，按逻辑单位表示宽度</param>
        /// <param name="nHeight">指定矩形的高度，按逻辑单位表示高度</param>
        /// <param name="dwRop">
        /// 指定光栅操作码。该操作码可以取下列值，这些值的含义如下：
        ///    PATCOPY：将指定的模式拷贝到目标位图中。
        ///    PATINVERT：使用布尔OR（或）操作符将指定模式的颜色与目标矩形的颜色进行组合。
        ///    DSTINVERT：将目标矩形反向。
        ///    BLACKNESS：使用物理调色板中与索引0相关的颜色填充目标矩形。（对于缺省的物理调色板而言，该颜色为黑色）。
        ///    WHITENESS：使用物理调色板中与索引1有关的颜色来填充目标矩形。（对于缺省的物理调色板而言，该颜色为白色）。
        /// </param>
        /// <returns>如果函数执行成功，则返回值为非零；如果函数执行失败，则返回值为0</returns>
        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, uint dwRop);
        
        /// <summary>
        /// 该函数删除一个逻辑笔、画笔、字体、位图、区域或者调色板，释放所有与该对象有关的系统资源，在对象被删除之后，指定的句柄也就失效了
        /// </summary>
        /// <remarks>
        /// 函数原型：BOOL DeleteObject(HGDIOBJ hObject)；
        /// 注释：当一个绘画对象（如笔或画笔）当前被选入一个设备上下文环境时不要删除该对象。当一个调色板画笔被删除时，与该画笔相关的位图并不被删除，该图必须单独地删除。
        /// Windows CE：当对象在当前被选入一个设备上下文环境时，DeleteObject函数返回错误。
        /// </remarks>
        /// <param name="hObject">逻辑笔、画笔、字体、位图、区域或者调色板的句柄</param>
        /// <returns>成功，返回非零值；如果指定的句柄无效或者它已被选入设备上下文环境，则返回值为零</returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        
        /// <summary>
        /// 该函数检索指定坐标点的像素的RGB颜色值
        /// </summary>
        /// <remarks>
        /// 函数原型：COLORREF GetPixel(HDC hdc, int nXPos, int nYPos)；
        /// 备注：该像素点必须在当前剪辑区的边界之内。并不是所有设备都支持GetPixel函数。应用程序应调用GetDeviceCaps函数来确定指定的设备是否支持该函数。
        /// </remarks>
        /// <param name="hdc">设备环境句柄</param>
        /// <param name="nXPos">指定要检查的像素点的逻辑X轴坐标</param>
        /// <param name="nYPos">指定要检查的像素点的逻辑Y轴坐标</param>
        /// <returns>返回值是该象像点的RGB值。如果指定的像素点在当前剪辑区之外；那么返回值是CLR_INVALID</returns>
        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
        
        /// <summary>
        /// 该函数设置指定设备环境的映射方式，映射方式定义了将逻辑单位转换为设备单位的度量单位，并定义了设备的X、Y轴的方向
        /// </summary>
        /// 函数原型：int SetMapMode(HDC hdc, int fnMapMode)；
        /// 备注：MM_TEXT方式允许应用程序以设备像素为单位来工作，像素的大小根据设备不同而不同。MM_HIENLISH, MM_HIMETRIC, MM_LOENGLISH, MM_LOMETRIC和MM_TWIPS方式对必须用物理意义单位（如英寸或毫米）制图的应用程序是非常有用的。MM_ISOTROPIC方式保证了1：1的纵横比。MM_HIENLISH方式允许对X和Y坐标分别进行调整
        /// <remarks>
        /// </remarks>
        /// <param name="hdc">指向设备环境的句柄</param>
        /// <param name="fnMapMode">
        /// 指定新的映射方式，此参数可以是下面列出的任何一个值。
        ///   MM_ANISOTROPIC：逻辑单位转换成具有任意比例轴的任意单位，用SetWindowExtEx和SetViewportExtEx函数可指定单位、方向和比例。
        ///   MM_HIENGIISH：每个逻辑单位转换为0.001英寸，X的正方面向右，Y的正方向向上。
        ///   MM_HIMETRIC：每个逻辑单位转换为0.01毫米，X正方向向右，Y的正方向向上。
        ///   MM_ISOTROPIC：逻辑单位转换成具有均等比例轴的任意单位，即沿X轴的一个单位等于沿Y轴的一个单位，用和函数可以指定该轴的单位和方向。图形设备界面（GDI）需要进行调整，以保证X和Y的单位保持相同大小（当设置窗口范围时，视口将被调整以达到单位大小相同）。
        ///   MM_LOENGIISH：每个逻辑单位转换为英寸，X正方向向右，Y正方向向上。
        ///   MM_LOMETRIC：每个逻辑单位转换为毫米，X正方向向右，Y正方向向上。
        ///   MM_TEXT：每个逻辑单位转换为一个设置备素，X正方向向右，Y正方向向下。
        ///   MM_TWIPS；每个逻辑单位转换为打印点的1／20（即1／1400英寸），X正方向向右，Y方向向上。
        /// </param>
        /// <returns>如果函数调用成功，返回值指定先前的映射方式，否则，返回值为零，若想获得更多错误信息，请调用GetLastError函数</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetMapMode(IntPtr hdc, int fnMapMode);
        
        /// <summary>
        /// 该函数确定指定对象的类型
        /// </summary>
        /// <remarks>
        /// 函数原型：DWORD GetObjectType(HGDIOBJ h)；
        /// </remarks>
        /// <param name="h">图形对象的句柄</param>
        /// <returns>
        /// 如果成功，返回值标识该对象，它可取如下值：
        ///   OBJ_BITMAP：位图（Bitmap）；OBJ_BRUSH：画笔（Brush）；OBJ_FONT：字体（Font）；OBJ_PAL：调色板（palette）；
        ///   OBJ_EXTPEN：扩展笔（Extendedpen）；OBJ_REGION：区域（Region）；OBJ_DC：设备上下文环境（Devicecontext）；
        ///   OBJ_MEMDC：存设备上下文环境；OBJ_METAFILE：图元文件；OBJ_ENHMETAFILE：增强图元文件；
        ///   OBJ_ENHMETADC：增强图元文件设备上下文环境；
        /// 如果失败，返回值为零，若想获得更多错误信息，请调用GetLastError函数。
        /// Windows CE：Windows CE不支持下列返回值：
        ///   OBJ_EXTPEN；OBJ_METADC；OBJ_METAFILE；OBJ_ENHMETAFILE；OBJ-ENHMETADC
        /// </returns>
        [DllImport("gdi32.dll")]
        public static extern int GetObjectType(IntPtr h);
        
        /// <summary>
        /// 该函数创建应用程序可以直接写入的、与设备无关的位图（DIB）。该函数提供一个指针，该指针指向位图位数据值的地方。可以给文件映射对象提供句柄，函数使用文件映射对象来创建位图，或者让系统为位图分配内存
        /// </summary>
        /// <remarks>
        /// 函数原型：HBITMAP CreateDIBSection(HDC hdc,CONST BITMAPINFO *pbmi,UINT iUsage,VOID *ppvBits,HANDLE hSection,DWORD dwOffset)；
        /// 备注：正如上面提到过，如果hSection为NULL，那么系统为DIB分配内存。当以后通过调用DeleteObject函数删除该DIB时，系统将关闭指向相应内存的句柄。如果Hsection不为NULL，那么在调用DeleteObject删除该位图之后，必须自己关闭hSection内存句柄。
        /// </remarks>
        /// <param name="hdc">设备环境句柄。如果iUsage的值是DIB＿PAL＿COLORS，那么函数使用该设备环境的逻辑调色板对与设备无关位图的颜色进行初始化</param>
        /// <param name="pbmi">指向BITMAPINFO结构的指针，该结构指定了与设备无关位图的各种属性，其中包括位图的维数和颜色</param>
        /// <param name="iUsage">指定由pbmi参数指定的BITMAPINFO结构中的成员bmiColors数组包含的数据类型（要么是逻辑调色板索引值，要么是原文的RGB值）</param>
        /// <param name="ppvBits">指向一个变量的指针，该变量接收一个指向DIB位数据值的指针</param>
        /// <param name="hSection">文件映射对象的句柄。函数将使用该对象来创建DIB（与设备无关位图）。该参数可以是NULL</param>
        /// <param name="dwOffset">指定从hSection引用的文件映射对象开始处算起的偏移量，超过这个偏移量的地方就是位图的位数据值开始存放的地方。在hSection为NULL时忽略该值。位图的位数据值是以DWORD为单位计算的</param>
        /// <returns>如果函数执行成功，那么返回值是一个指向刚刚创建的与设备无关位图的句柄，并且*ppvBits指向该位图的位数据值；如果函数执行失败，那么返回值为NULL，并且*ppvBit也为NULL，若想获得更多错误信息，请调用GetLastError函数</returns>
        [DllImport("gdi32")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO_FLAT pbmi, int iUsage, ref int ppvBits, IntPtr hSection, int dwOffset);
        
        /// <summary>
        /// GetDIBits函数检取指定位图的信息，并将其以指定格式复制到一个缓冲区中
        /// </summary>
        /// <remarks>
        /// 函数原型：int GetDIBits(HDC hdc, HBITMAP hbmp, UINT uStartScan, UINT cScanLines, LPVOID lpvBits, LPBITMAPINFO lpbi, UINT uUsage)；
        /// </remarks>
        /// <param name="hdc">设备环境句柄</param>
        /// <param name="hbmp">位图句柄</param>
        /// <param name="uStartScan">指定检索的第一个扫描线</param>
        /// <param name="cScanLines">指定检索的扫描线数</param>
        /// <param name="lpvBits">指向用来检索位图数据的缓冲区的指针。如果此参数为NULL，那么函数将把位图的维数与格式传递给lpbi参数指向的BITMAPINFO结构</param>
        /// <param name="lpbi">指向一个BITMAPINFO结构的指外，此结构确定了设备无在位图的数据格式</param>
        /// <param name="uUsage">
        /// 指定BITMAPINFO结构的bmiColors成员的格式。它必须为下列取值：
        ///   DIB_PAL_COLORS：颜色表由指向当前逻辑调色板的16位索引值数组构成。
        ///   DIB_RGB_COLORS：颜色表由红、绿、蓝（RGB）三个直接值构成。
        /// </param>
        /// <returns>如果lpvBits参数非空，并且函数调用成功，那么返回值为从位图复制的扫描线数</returns>
        [DllImport("gdi32")]
        public static extern int GetDIBits(IntPtr hdc, IntPtr hbmp, int uStartScan, int cScanLines, int lpvBits, BITMAPINFOHEADER lpbi, int uUsage);
        [DllImport("gdi32")]
        public static extern int GetDIBits(IntPtr hdc, IntPtr hbm, int StartScan, int ScanLines, int lpBits, ref BITMAPINFO_FLAT bmi, int usage);
        [DllImport("gdi32")]
        public static extern IntPtr GetPaletteEntries(IntPtr hpal, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport("gdi32")]
        public static extern IntPtr GetSystemPaletteEntries(IntPtr hdc, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport("gdi32")]
        public static extern uint SetDCBrushColor(IntPtr hdc, uint crColor);
        [DllImport("gdi32")]
        public static extern IntPtr CreateSolidBrush(uint crColor);
        [DllImport("gdi32")]
        public static extern int SetBkMode(IntPtr hDC, BackgroundMode mode);
        [DllImport("gdi32")]
        public static extern int SetViewportOrgEx(IntPtr hdc, int x, int y, int param);
        [DllImport("gdi32")]
        public static extern uint SetTextColor(IntPtr hDC, uint colorRef);
        [DllImport("gdi32")]
        public static extern int SetStretchBltMode(IntPtr hDC, int StrechMode);
        #endregion

        #region Uxtheme.dll functions
        [DllImport("uxtheme.dll")]
        static public extern int SetWindowTheme(IntPtr hWnd, string AppID, string ClassID);
        #endregion

        #region User32.dll functions
        /// <summary>
        /// 该函数检索一指定窗口的客户区域或整个屏幕的显示设备上下文环境的句柄，以后可以在GDI函数中使用该句柄来在设备上下文环境中绘图
        /// </summary>
        /// <remarks>
        /// 函数原型：HDC GetDC(HWND hWnd)；
        /// </remarks>
        /// <param name="hWnd">设备上下文环境被检索的窗口的句柄，如果该值为NULL，GetDC则检索整个屏幕的设备上下文环境</param>
        /// <returns>如果成功，返回指定窗口客户区的设备上下文环境；如果失败，返回值为Null</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        
        /// <summary>
        /// 函数释放设备上下文环境（DC）供其他应用程序使用。函数的效果与设备上下文环境类型有关。它只释放公用的和设备上下文环境，对于类或私有的则无数
        /// </summary>
        /// <remarks>
        /// 函数原型：int ReleaseDC(HWND hWnd, HDC hdc)；
        /// 注释：每次调用GetWindowDC和GetDC函数检索公用设备上下文环境之后，应用程序必须调用ReleaseDC函数来释放设备上下文环境。
        /// 应用程序不能调用ReleaseDC函数来释放由CreateDC函数创建的设备上下文环境，只能使用DeleteDC函数。
        /// </remarks>
        /// <param name="hWnd">指向要释放的设备上下文环境所在的窗口的句柄</param>
        /// <param name="hdc">指向要释放的设备上下文环境的句柄</param>
        /// <returns>返回值说明了设备上下文环境是否释放；如果释放成功，则返回值为1；如果没有释放成功，则返回值为0</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);
        
        /// <summary>
        /// 该函数返回桌面窗口的句柄。桌面窗口覆盖整个屏幕。桌面窗口是一个要在其上绘制所有的图标和其他窗口的区域
        /// </summary>
        /// <remarks>
        /// 函数原型：HWND GetDesktopWindow（VOID）
        /// </remarks>
        /// <returns>函数返回桌面窗口的句柄</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();
        
        /// <summary>
        /// 该函数设置指定窗口的显示状态
        /// </summary>
        /// <remarks>
        /// 函数原型：BOOL ShowWindow（HWND hWnd，int nCmdShow）；
        /// </remarks>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="nCmdShow">指定窗口如何显示。如果发送应用程序的程序提供了STARTUPINFO结构，则应用程序第一次调用ShowWindow时该参数被忽略。否则，在第一次调用ShowWindow函数时，该值应为在函数WinMain中nCmdShow参数。在随后的调用中，该参数可以为ShowWindowStyles值之一
        /// </param>
        /// <returns>如果窗口以前可见，则返回值为非零。如果窗口以前被隐藏，则返回值为零</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, short nCmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool UpdateWindow(IntPtr hWnd);
        
        /// <summary>
        /// 该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程
        /// </summary>
        /// <remarks>
        /// 函数原型：BOOL SetForegroundWindow（HWND hWnd）
        /// 备注：前台窗口是z序顶部的窗口，是用户的工作窗口。在一个多任务优先抢占环境中，应让用户控制前台窗口。
        /// </remarks>
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool CloseClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool EmptyClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr SetClipboardData(uint Format, IntPtr hData);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint Item, ref RECT rc);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref POINT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTON lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTONINFO lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref REBARBANDINFO lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TVITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref LVITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HDITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HD_HITTESTINFO hti);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetFocus(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int DrawText(IntPtr hdc, string lpString, int nCount, ref RECT lpRect, int uFormat);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int GetClientRect(IntPtr hWnd, ref RECT rc);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int InvalidateRect(IntPtr hWnd, IntPtr rect, int bErase);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool WaitMessage();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TranslateMessage(ref MSG msg);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool DispatchMessage(ref MSG msg);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetFocus();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern ushort GetKeyState(int virtKey);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, out STRINGBUFFER ClassName, int nMaxCount);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int FillRect(IntPtr hDC, ref RECT rect, IntPtr hBrush);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT wp);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, out STRINGBUFFER text, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int GetSystemMetrics(int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int SetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si, int fRedraw);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int EnableScrollBar(IntPtr hWnd, uint flags, uint arrows);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy,
            ref RECT rcScroll, ref RECT rcClip, IntPtr UpdateRegion, ref RECT rcInvalidated, uint flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int IsWindow(IntPtr hWnd);
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, //[in] Specifies the virtual-key code to be translated. 
            int uScanCode, // [in] Specifies the hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed). 
            byte[] lpbKeyState, // [in] Pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of one key. If the high-order bit of a byte is set, the key is down (pressed). The low bit, if set, indicates that the key is toggled on. In this function, only the toggle bit of the CAPS LOCK key is relevant. The toggle state of the NUM LOCK and SCROLL LOCK keys is ignored.
            byte[] lpwTransKey, // [out] Pointer to the buffer that receives the translated character or characters. 
            int fuState); // [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise.
        #endregion

        #region Common Controls functions
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControlsEx(INITCOMMONCONTROLSEX icc);
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControls();
        [DllImport("comctl32.dll", EntryPoint = "DllGetVersion")]
        public extern static int GetCommonControlDLLVersion(ref DLLVERSIONINFO dvi);
        [DllImport("comctl32.dll")]
        public static extern IntPtr ImageList_Create(int width, int height, uint flags, int count, int grow);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Destroy(IntPtr handle);
        [DllImport("comctl32.dll")]
        public static extern int ImageList_Add(IntPtr imageHandle, IntPtr hBitmap, IntPtr hMask);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Remove(IntPtr imageHandle, int index);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_BeginDrag(IntPtr imageHandle, int imageIndex, int xHotSpot, int yHotSpot);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_DragEnter(IntPtr hWndLock, int x, int y);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_DragMove(int x, int y);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_DragLeave(IntPtr hWndLock);
        [DllImport("comctl32.dll")]
        public static extern void ImageList_EndDrag();
        #endregion

        #region Win32 Macro-Like helpers
        public static int GET_X_LPARAM(int lParam)
        {
            return (lParam & 0xffff);
        }


        public static int GET_Y_LPARAM(int lParam)
        {
            return (lParam >> 16);
        }

        public static Point GetPointFromLPARAM(int lParam)
        {
            return new Point(GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam));
        }

        public static int LOW_ORDER(int param)
        {
            return (param & 0xffff);
        }

        public static int HIGH_ORDER(int param)
        {
            return (param >> 16);
        }

        #endregion

    }
}
