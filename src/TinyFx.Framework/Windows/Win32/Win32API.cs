using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace TinyFx.Windows.Win32
{
    /// <summary>
    /// ���� Windows API ��������
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
        /// �޸ĵ�ǰʱ��
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
        /// ������Դ�����и���һ��λͼ��Ŀ����Σ���Ҫʱ��ĿǰĿ���豸���õ�ģʽ����ͼ��������ѹ��
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�BOOL StretchBlt(HDC hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeighDest, HDC hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, DWORD dwRop)��
        /// </remarks>
        /// <param name="hdcDest">ָ��Ŀ���豸�����ľ��</param>
        /// <param name="nXOriginDest">ָ��Ŀ��������Ͻǵ�X�����꣬���߼���λ��ʾ����</param>
        /// <param name="nYOriginDest">ָ��Ŀ��������Ͻǵ�X�����꣬���߼���λ��ʾ����</param>
        /// <param name="nWidthDest">ָ��Ŀ����εĿ�ȣ����߼���λ��ʾ���</param>
        /// <param name="nHeighDest">ָ��Ŀ����εĸ߶ȣ����߼���λ��ʾ����</param>
        /// <param name="hdcSrc">ָ��Դ�豸�����ľ��</param>
        /// <param name="nXOriginSrc">ָ��Դ�����������Ͻǵ�X�����꣬���߼���λ��ʾ����</param>
        /// <param name="nYOriginSrc">ָ��Դ�����������Ͻǵ�Y�����꣬���߼���λ��ʾ����</param>
        /// <param name="nWidthSrc">ָ��Դ���εĿ�ȣ����߼���λ��ʾ���</param>
        /// <param name="nHeightSrc">ָ��Դ���εĸ߶ȣ����߼���λ��ʾ�߶�</param>
        /// <param name="dwRop">ָ��Ҫ���еĹ�դ��������դ�����붨����ϵͳ�������������������ɫ����Щ��������ˢ�ӡ�Դλͼ��Ŀ��λͼ�ȶ��󡣲ο�BitBlt���˽ⳣ�õĹ�դ�������б�</param>
        /// <returns>�������ִ�гɹ�����ô����ֵΪ���㣬�������ִ��ʧ�ܣ���ô����ֵΪ�㡣Windows NT�������ø���Ĵ�����Ϣ�������GetLastError����</returns>
        [DllImport("gdi32.dll")]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeighDest
            , IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop);
        
        /// <summary>
        /// �ú�������һ����ָ���豸���ݵ��ڴ��豸�����Ļ�����DC����
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�HDC CreateCompatibleDC(HDC hdc)��
        /// ע�ͣ��ڴ��豸�����Ļ����ǽ����ڴ��д��ڵ��豸�����Ļ��������ڴ��豸�����Ļ���������ʱ��������ʾ�����Ǳ�׼��һ����ɫ���ؿ��һ����ɫ���ظߣ���һ��Ӧ�ó������ʹ���ڴ��豸�����Ļ������л�ͼ����֮ǰ��������ѡ��һ���ߺͿ���ȷ��λͼ���豸�����Ļ����У������ͨ��ʹ��CreateCompatibleBitmap����ָ���ߡ����ɫ����������㺯�����õ���Ҫ��
        /// ��һ���ڴ��豸�����Ļ�������ʱ�����е����Զ���Ϊȱʡֵ���ڴ��豸�����Ļ�����Ϊһ����ͨ���豸�����Ļ���ʹ�ã���ȻҲ����������Щ����Ϊ��ȱʡֵ���õ��������Եĵ�ǰ���ã�Ϊ��ѡ�񻭱ʣ�ˢ�Ӻ�����
        /// CreateCompatibleDc����ֻ������֧�ֹ�դ�������豸��Ӧ�ó������ͨ������GetDeviceCaps������ȷ��һ���豸�Ƿ�֧����Щ������
        /// ��������Ҫ�ڴ��豸�����Ļ���ʱ���ɵ���DeleteDc����ɾ������
        /// ICM�����ͨ���ú�����hdc�������͸��ú����豸�����Ļ���(Dc)���ڶ�����ɫ����ICM�������õģ���ú����������豸�����Ļ���(Dc)��ICM���õģ���Դ��Ŀ����ɫ�������Dc�ж��塣
        /// </remarks>
        /// <param name="hdc">�����豸�����Ļ����ľ��������þ��ΪNULL���ú�������һ����Ӧ�ó���ĵ�ǰ��ʾ�����ݵ��ڴ��豸�����Ļ���</param>
        /// <returns>����ɹ����򷵻��ڴ��豸�����Ļ����ľ�������ʧ�ܣ��򷵻�ֵΪNULL</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        
        /// <summary>
        /// �ú���������ָ�����豸������ص��豸���ݵ�λͼ
        /// </summary>
        /// <remarks>
        ///  ����ԭ�ͣ�HBITMAP CreateCompatibleBitmap(HDC hdc,int nWidth,int nHeight)��
        /// ��CreateCompatibleBitmap����������λͼ����ɫ��ʽ���ɲ���hdc��ʶ���豸����ɫ��ʽƥ�䡣��λͼ����ѡ������һ����ԭ�豸���ݵ��ڴ��豸�����С������ڴ��豸���������ɫ�͵�ɫ����λͼ����˵�ָ�����豸�������ڴ��豸����ʱ����CreateCompatibleBitmap�������ص�λͼ��ʽ��ͬ��Ȼ��Ϊ���ڴ��豸���������ļ���λͼͨ��ӵ����ͬ����ɫ��ʽ������ʹ����ָ�����豸����һ����ɫ�ʵ�ɫ�塣
        /// </remarks>
        /// <param name="hdc">�豸�������</param>
        /// <param name="nWidth">ָ��λͼ�Ŀ�ȣ���λΪ����</param>
        /// <param name="nHeight">ָ��λͼ�ĸ߶ȣ���λΪ���ء�</param>
        /// <returns>�������ִ�гɹ�����ô����ֵ��λͼ�ľ�����������ִ��ʧ�ܣ���ô����ֵΪNULL�������ȡ���������Ϣ�������GetLastError</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        
        /// <summary>
        /// �ú���ѡ��һ����ָ�����豸�����Ļ����У����¶����滻��ǰ����ͬ���͵Ķ���
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�HGDIOBJ SelectObject(HDC hdc, HGDIOBJ hgdiobj)��
        /// �ú���������ǰָ�����͵�ѡ�����һ��Ӧ�ó�������ʹ���¶�����л������֮��Ӧ�����¶����滻ԭʼ��ȱʡ�Ķ���
        /// Ӧ�ó�����ͬʱѡ��һ��λͼ������豸�����Ļ����С�
        /// ICM�������ѡ��Ķ����ǻ��ʻ�ʣ���ô��ִ����ɫ����
        /// </remarks>
        /// <param name="hdc">�豸�����Ļ����ľ����</param>
        /// <param name="hgdiobj">
        /// ��ѡ��Ķ���ľ��ͣ���ָ��������������µĺ���������
        /// λͼ��CreateBitmap, CreateBitmapIndirect, CreateCompatible Bitmap, CreateDIBitmap, CreateDIBsection��ֻ���ڴ��豸�����Ļ�����ѡ��λͼ��������ͬһʱ��ֻ��һ���豸�����Ļ���ѡ��λͼ����
        /// ���ʣ�CreateBrushIndirect, CreateDIBPatternBrush, CreateDIBPatternBrushPt, CreateHatchBrush, CreatePatternBrush, CreateSolidBrush��
        /// ���壺CreateFont, CreateFontIndirect��
        /// �ʣ�CreatePen, CreatePenIndirect��
        /// ����CombineRgn, CreateEllipticRgn, CreateEllipticRgnIndirect, CreatePolygonRgn, CreateRectRgn, CreateRectRgnIndirect��
        /// </param>
        /// <returns>
        /// ���ѡ������������Һ���ִ�гɹ�����ô����ֵ�Ǳ�ȡ���Ķ���ľ�������ѡ������������Һ���ִ�гɹ�����������һֵ��
        /// SIMPLEREGION�������ɵ���������ɣ�COMPLEXREGION�������ɶ��������ɡ�NULLREGION������Ϊ�ա�
        /// �������������ѡ�������һ��������ô����ֵΪNULL�����򷵻�GDI_ERROR��
        /// </returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        
        /// <summary>
        /// �ú�����ָ����Դ�豸���������е����ؽ���λ�飨bit_block��ת�����Դ��͵�Ŀ���豸������
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�BOOL BitBlt(HDC hdcDest,int nXDest,int nYDest,int nWidth,int nHeight,HDC hdcSrc,int nXSrc,int nYSrc,DWORD dwRop)��
        /// �����Դ�豸�����п���ʵ����ת����б任����ô����BitBlt����һ������������������任������Ŀ���豸������ƥ��任��Ч������ôĿ���豸�����еľ�����������Ҫʱ�������졢ѹ������ת��
        /// ���Դ��Ŀ���豸��������ɫ��ʽ��ƥ�䣬��ôBitBlt������Դ��������ɫ��ʽת��������Ŀ���ʽƥ��ĸ�ʽ�������ڼ�¼һ����ǿ��ͼԪ�ļ�ʱ�����Դ�豸������ʶΪһ����ǿ��ͼԪ�ļ��豸��������ô����ִ������Դ��Ŀ���豸��������ͬ���豸����ôBitBlt�������ش���
        /// </remarks>
        /// <param name="hdcDest">ָ��Ŀ���豸�����ľ��</param>
        /// <param name="nXDest">ָ��Ŀ������������Ͻǵ�X���߼�����</param>
        /// <param name="nYDest">ָ��Ŀ������������Ͻǵ�Y���߼�����</param>
        /// <param name="nWidth">ָ��Դ��Ŀ�����������߼����</param>
        /// <param name="nHeight">ָ��Դ��Ŀ�����������߼��߶�</param>
        /// <param name="hdcSrc">ָ��Դ�豸�����ľ��</param>
        /// <param name="nXSrc">ָ��Դ�����������Ͻǵ�X���߼�����</param>
        /// <param name="nYSrc">ָ��Դ�����������Ͻǵ�Y���߼�����</param>
        /// <param name="dwRop">ָ����դ�������롣��Щ���뽫����Դ�����������ɫ���ݣ������Ŀ������������ɫ������������������ɫ</param>
        /// <returns>��������ɹ�����ô����ֵ���㣻�������ʧ�ܣ��򷵻�ֵΪ��</returns>
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight
            , IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
        
        /// <summary>
        /// �ú���ɾ��ָ�����豸�����Ļ�����Dc��
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�BOOL DeleteDC(HDC hdc)��
        /// ���һ���豸�����Ļ����ľ����ͨ������GetDC�����õ��ģ���ôӦ�ó�����ɾ�����豸�����Ļ�������Ӧ�õ���ReleaseDC�������ͷŸ��豸�����Ļ���
        /// </remarks>
        /// <param name="hdc">�豸�����Ļ����ľ��</param>
        /// <returns>�ɹ������ط���ֵ��ʧ�ܣ�������</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteDC(IntPtr hdc);
        
        /// <summary>
        /// �ú���ʹ�õ�ǰѡ��ָ���豸�����е�ˢ�ӻ��Ƹ����ľ�������ͨ��ʹ�ø����Ĺ�դ�������Ը�ˢ�ӵ���ɫ�ͱ�����ɫ�������
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�BOOL PatBlt(HDC hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, DWORD dwRop)��
        /// ��ע���ú����Ĳ���dwRopȡֵ�޶�Ϊȫ��256����Ԫ��դ���������Ӽ����ر�أ��漰Դ���εĲ����벻��ʹ�á�
        /// ���������豸��֧��PalBlt�������йظ������Ϣ����ο�����GetDeviceCaps���й�RC_BITBLT���Ե�������
        /// </remarks>
        /// <param name="hdc">�豸�������</param>
        /// <param name="nXLeft">ָ��Ҫ���ľ������Ͻǵ�X�����꣬���갴�߼���λ��ʾ</param>
        /// <param name="nYLeft">ָ��Ҫ���ľ������Ͻǵ�Y�����꣬���갴�߼���λ��ʾ</param>
        /// <param name="nWidth">ָ�����εĿ�ȣ����߼���λ��ʾ���</param>
        /// <param name="nHeight">ָ�����εĸ߶ȣ����߼���λ��ʾ�߶�</param>
        /// <param name="dwRop">
        /// ָ����դ�����롣�ò��������ȡ����ֵ����Щֵ�ĺ������£�
        ///    PATCOPY����ָ����ģʽ������Ŀ��λͼ�С�
        ///    PATINVERT��ʹ�ò���OR���򣩲�������ָ��ģʽ����ɫ��Ŀ����ε���ɫ������ϡ�
        ///    DSTINVERT����Ŀ����η���
        ///    BLACKNESS��ʹ�������ɫ����������0��ص���ɫ���Ŀ����Ρ�������ȱʡ�������ɫ����ԣ�����ɫΪ��ɫ����
        ///    WHITENESS��ʹ�������ɫ����������1�йص���ɫ�����Ŀ����Ρ�������ȱʡ�������ɫ����ԣ�����ɫΪ��ɫ����
        /// </param>
        /// <returns>�������ִ�гɹ����򷵻�ֵΪ���㣻�������ִ��ʧ�ܣ��򷵻�ֵΪ0</returns>
        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, uint dwRop);
        
        /// <summary>
        /// �ú���ɾ��һ���߼��ʡ����ʡ����塢λͼ��������ߵ�ɫ�壬�ͷ�������ö����йص�ϵͳ��Դ���ڶ���ɾ��֮��ָ���ľ��Ҳ��ʧЧ��
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�BOOL DeleteObject(HGDIOBJ hObject)��
        /// ע�ͣ���һ���滭������ʻ򻭱ʣ���ǰ��ѡ��һ���豸�����Ļ���ʱ��Ҫɾ���ö��󡣵�һ����ɫ�廭�ʱ�ɾ��ʱ����û�����ص�λͼ������ɾ������ͼ���뵥����ɾ����
        /// Windows CE���������ڵ�ǰ��ѡ��һ���豸�����Ļ���ʱ��DeleteObject�������ش���
        /// </remarks>
        /// <param name="hObject">�߼��ʡ����ʡ����塢λͼ��������ߵ�ɫ��ľ��</param>
        /// <returns>�ɹ������ط���ֵ�����ָ���ľ����Ч�������ѱ�ѡ���豸�����Ļ������򷵻�ֵΪ��</returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        
        /// <summary>
        /// �ú�������ָ�����������ص�RGB��ɫֵ
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�COLORREF GetPixel(HDC hdc, int nXPos, int nYPos)��
        /// ��ע�������ص�����ڵ�ǰ�������ı߽�֮�ڡ������������豸��֧��GetPixel������Ӧ�ó���Ӧ����GetDeviceCaps������ȷ��ָ�����豸�Ƿ�֧�ָú�����
        /// </remarks>
        /// <param name="hdc">�豸�������</param>
        /// <param name="nXPos">ָ��Ҫ�������ص���߼�X������</param>
        /// <param name="nYPos">ָ��Ҫ�������ص���߼�Y������</param>
        /// <returns>����ֵ�Ǹ�������RGBֵ�����ָ�������ص��ڵ�ǰ������֮�⣻��ô����ֵ��CLR_INVALID</returns>
        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
        
        /// <summary>
        /// �ú�������ָ���豸������ӳ�䷽ʽ��ӳ�䷽ʽ�����˽��߼���λת��Ϊ�豸��λ�Ķ�����λ�����������豸��X��Y��ķ���
        /// </summary>
        /// ����ԭ�ͣ�int SetMapMode(HDC hdc, int fnMapMode)��
        /// ��ע��MM_TEXT��ʽ����Ӧ�ó������豸����Ϊ��λ�����������صĴ�С�����豸��ͬ����ͬ��MM_HIENLISH, MM_HIMETRIC, MM_LOENGLISH, MM_LOMETRIC��MM_TWIPS��ʽ�Ա������������嵥λ����Ӣ�����ף���ͼ��Ӧ�ó����Ƿǳ����õġ�MM_ISOTROPIC��ʽ��֤��1��1���ݺ�ȡ�MM_HIENLISH��ʽ�����X��Y����ֱ���е���
        /// <remarks>
        /// </remarks>
        /// <param name="hdc">ָ���豸�����ľ��</param>
        /// <param name="fnMapMode">
        /// ָ���µ�ӳ�䷽ʽ���˲��������������г����κ�һ��ֵ��
        ///   MM_ANISOTROPIC���߼���λת���ɾ����������������ⵥλ����SetWindowExtEx��SetViewportExtEx������ָ����λ������ͱ�����
        ///   MM_HIENGIISH��ÿ���߼���λת��Ϊ0.001Ӣ�磬X�����������ң�Y�����������ϡ�
        ///   MM_HIMETRIC��ÿ���߼���λת��Ϊ0.01���ף�X���������ң�Y�����������ϡ�
        ///   MM_ISOTROPIC���߼���λת���ɾ��о��ȱ���������ⵥλ������X���һ����λ������Y���һ����λ���úͺ�������ָ������ĵ�λ�ͷ���ͼ���豸���棨GDI����Ҫ���е������Ա�֤X��Y�ĵ�λ������ͬ��С�������ô��ڷ�Χʱ���ӿڽ��������Դﵽ��λ��С��ͬ����
        ///   MM_LOENGIISH��ÿ���߼���λת��ΪӢ�磬X���������ң�Y���������ϡ�
        ///   MM_LOMETRIC��ÿ���߼���λת��Ϊ���ף�X���������ң�Y���������ϡ�
        ///   MM_TEXT��ÿ���߼���λת��Ϊһ�����ñ��أ�X���������ң�Y���������¡�
        ///   MM_TWIPS��ÿ���߼���λת��Ϊ��ӡ���1��20����1��1400Ӣ�磩��X���������ң�Y�������ϡ�
        /// </param>
        /// <returns>����������óɹ�������ֵָ����ǰ��ӳ�䷽ʽ�����򣬷���ֵΪ�㣬�����ø��������Ϣ�������GetLastError����</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetMapMode(IntPtr hdc, int fnMapMode);
        
        /// <summary>
        /// �ú���ȷ��ָ�����������
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�DWORD GetObjectType(HGDIOBJ h)��
        /// </remarks>
        /// <param name="h">ͼ�ζ���ľ��</param>
        /// <returns>
        /// ����ɹ�������ֵ��ʶ�ö�������ȡ����ֵ��
        ///   OBJ_BITMAP��λͼ��Bitmap����OBJ_BRUSH�����ʣ�Brush����OBJ_FONT�����壨Font����OBJ_PAL����ɫ�壨palette����
        ///   OBJ_EXTPEN����չ�ʣ�Extendedpen����OBJ_REGION������Region����OBJ_DC���豸�����Ļ�����Devicecontext����
        ///   OBJ_MEMDC�����豸�����Ļ�����OBJ_METAFILE��ͼԪ�ļ���OBJ_ENHMETAFILE����ǿͼԪ�ļ���
        ///   OBJ_ENHMETADC����ǿͼԪ�ļ��豸�����Ļ�����
        /// ���ʧ�ܣ�����ֵΪ�㣬�����ø��������Ϣ�������GetLastError������
        /// Windows CE��Windows CE��֧�����з���ֵ��
        ///   OBJ_EXTPEN��OBJ_METADC��OBJ_METAFILE��OBJ_ENHMETAFILE��OBJ-ENHMETADC
        /// </returns>
        [DllImport("gdi32.dll")]
        public static extern int GetObjectType(IntPtr h);
        
        /// <summary>
        /// �ú�������Ӧ�ó������ֱ��д��ġ����豸�޹ص�λͼ��DIB�����ú����ṩһ��ָ�룬��ָ��ָ��λͼλ����ֵ�ĵط������Ը��ļ�ӳ������ṩ���������ʹ���ļ�ӳ�����������λͼ��������ϵͳΪλͼ�����ڴ�
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�HBITMAP CreateDIBSection(HDC hdc,CONST BITMAPINFO *pbmi,UINT iUsage,VOID *ppvBits,HANDLE hSection,DWORD dwOffset)��
        /// ��ע�����������ᵽ�������hSectionΪNULL����ôϵͳΪDIB�����ڴ档���Ժ�ͨ������DeleteObject����ɾ����DIBʱ��ϵͳ���ر�ָ����Ӧ�ڴ�ľ�������Hsection��ΪNULL����ô�ڵ���DeleteObjectɾ����λͼ֮�󣬱����Լ��ر�hSection�ڴ�����
        /// </remarks>
        /// <param name="hdc">�豸������������iUsage��ֵ��DIB��PAL��COLORS����ô����ʹ�ø��豸�������߼���ɫ������豸�޹�λͼ����ɫ���г�ʼ��</param>
        /// <param name="pbmi">ָ��BITMAPINFO�ṹ��ָ�룬�ýṹָ�������豸�޹�λͼ�ĸ������ԣ����а���λͼ��ά������ɫ</param>
        /// <param name="iUsage">ָ����pbmi����ָ����BITMAPINFO�ṹ�еĳ�ԱbmiColors����������������ͣ�Ҫô���߼���ɫ������ֵ��Ҫô��ԭ�ĵ�RGBֵ��</param>
        /// <param name="ppvBits">ָ��һ��������ָ�룬�ñ�������һ��ָ��DIBλ����ֵ��ָ��</param>
        /// <param name="hSection">�ļ�ӳ�����ľ����������ʹ�øö���������DIB�����豸�޹�λͼ�����ò���������NULL</param>
        /// <param name="dwOffset">ָ����hSection���õ��ļ�ӳ�����ʼ�������ƫ�������������ƫ�����ĵط�����λͼ��λ����ֵ��ʼ��ŵĵط�����hSectionΪNULLʱ���Ը�ֵ��λͼ��λ����ֵ����DWORDΪ��λ�����</param>
        /// <returns>�������ִ�гɹ�����ô����ֵ��һ��ָ��ոմ��������豸�޹�λͼ�ľ��������*ppvBitsָ���λͼ��λ����ֵ���������ִ��ʧ�ܣ���ô����ֵΪNULL������*ppvBitҲΪNULL�������ø��������Ϣ�������GetLastError����</returns>
        [DllImport("gdi32")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO_FLAT pbmi, int iUsage, ref int ppvBits, IntPtr hSection, int dwOffset);
        
        /// <summary>
        /// GetDIBits������ȡָ��λͼ����Ϣ����������ָ����ʽ���Ƶ�һ����������
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�int GetDIBits(HDC hdc, HBITMAP hbmp, UINT uStartScan, UINT cScanLines, LPVOID lpvBits, LPBITMAPINFO lpbi, UINT uUsage)��
        /// </remarks>
        /// <param name="hdc">�豸�������</param>
        /// <param name="hbmp">λͼ���</param>
        /// <param name="uStartScan">ָ�������ĵ�һ��ɨ����</param>
        /// <param name="cScanLines">ָ��������ɨ������</param>
        /// <param name="lpvBits">ָ����������λͼ���ݵĻ�������ָ�롣����˲���ΪNULL����ô��������λͼ��ά�����ʽ���ݸ�lpbi����ָ���BITMAPINFO�ṹ</param>
        /// <param name="lpbi">ָ��һ��BITMAPINFO�ṹ��ָ�⣬�˽ṹȷ�����豸����λͼ�����ݸ�ʽ</param>
        /// <param name="uUsage">
        /// ָ��BITMAPINFO�ṹ��bmiColors��Ա�ĸ�ʽ��������Ϊ����ȡֵ��
        ///   DIB_PAL_COLORS����ɫ����ָ��ǰ�߼���ɫ���16λ����ֵ���鹹�ɡ�
        ///   DIB_RGB_COLORS����ɫ���ɺ졢�̡�����RGB������ֱ��ֵ���ɡ�
        /// </param>
        /// <returns>���lpvBits�����ǿգ����Һ������óɹ�����ô����ֵΪ��λͼ���Ƶ�ɨ������</returns>
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
        /// �ú�������һָ�����ڵĿͻ������������Ļ����ʾ�豸�����Ļ����ľ�����Ժ������GDI������ʹ�øþ�������豸�����Ļ����л�ͼ
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�HDC GetDC(HWND hWnd)��
        /// </remarks>
        /// <param name="hWnd">�豸�����Ļ����������Ĵ��ڵľ���������ֵΪNULL��GetDC�����������Ļ���豸�����Ļ���</param>
        /// <returns>����ɹ�������ָ�����ڿͻ������豸�����Ļ��������ʧ�ܣ�����ֵΪNull</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        
        /// <summary>
        /// �����ͷ��豸�����Ļ�����DC��������Ӧ�ó���ʹ�á�������Ч�����豸�����Ļ��������йء���ֻ�ͷŹ��õĺ��豸�����Ļ������������˽�е�������
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�int ReleaseDC(HWND hWnd, HDC hdc)��
        /// ע�ͣ�ÿ�ε���GetWindowDC��GetDC�������������豸�����Ļ���֮��Ӧ�ó���������ReleaseDC�������ͷ��豸�����Ļ�����
        /// Ӧ�ó����ܵ���ReleaseDC�������ͷ���CreateDC�����������豸�����Ļ�����ֻ��ʹ��DeleteDC������
        /// </remarks>
        /// <param name="hWnd">ָ��Ҫ�ͷŵ��豸�����Ļ������ڵĴ��ڵľ��</param>
        /// <param name="hdc">ָ��Ҫ�ͷŵ��豸�����Ļ����ľ��</param>
        /// <returns>����ֵ˵�����豸�����Ļ����Ƿ��ͷţ�����ͷųɹ����򷵻�ֵΪ1�����û���ͷųɹ����򷵻�ֵΪ0</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);
        
        /// <summary>
        /// �ú����������洰�ڵľ�������洰�ڸ���������Ļ�����洰����һ��Ҫ�����ϻ������е�ͼ����������ڵ�����
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�HWND GetDesktopWindow��VOID��
        /// </remarks>
        /// <returns>�����������洰�ڵľ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();
        
        /// <summary>
        /// �ú�������ָ�����ڵ���ʾ״̬
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�BOOL ShowWindow��HWND hWnd��int nCmdShow����
        /// </remarks>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="nCmdShow">ָ�����������ʾ���������Ӧ�ó���ĳ����ṩ��STARTUPINFO�ṹ����Ӧ�ó����һ�ε���ShowWindowʱ�ò��������ԡ������ڵ�һ�ε���ShowWindow����ʱ����ֵӦΪ�ں���WinMain��nCmdShow�����������ĵ����У��ò�������ΪShowWindowStylesֵ֮һ
        /// </param>
        /// <returns>���������ǰ�ɼ����򷵻�ֵΪ���㡣���������ǰ�����أ��򷵻�ֵΪ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, short nCmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool UpdateWindow(IntPtr hWnd);
        
        /// <summary>
        /// �ú���������ָ�����ڵ��߳����õ�ǰ̨�����Ҽ���ô��ڡ���������ת��ô��ڣ���Ϊ�û��ĸ��ֿ��ӵļǺš�ϵͳ������ǰ̨���ڵ��̷߳����Ȩ���Ը��������߳�
        /// </summary>
        /// <remarks>
        /// ����ԭ�ͣ�BOOL SetForegroundWindow��HWND hWnd��
        /// ��ע��ǰ̨������z�򶥲��Ĵ��ڣ����û��Ĺ������ڡ���һ��������������ռ�����У�Ӧ���û�����ǰ̨���ڡ�
        /// </remarks>
        /// <param name="hWnd">�������������ǰ̨�Ĵ��ھ��</param>
        /// <returns>�������������ǰ̨������ֵΪ���㣻�������δ������ǰ̨������ֵΪ��</returns>
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
