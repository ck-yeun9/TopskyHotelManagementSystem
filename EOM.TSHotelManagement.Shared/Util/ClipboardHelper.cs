using System.Runtime.InteropServices;
using System.Text;

namespace EOM.TSHotelManagement.Shared;
public class ClipboardHelper
{
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool CloseClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool EmptyClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GlobalLock(IntPtr hMem);

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GlobalUnlock(IntPtr hMem);

    private const uint CF_UNICODETEXT = 13;

    private const uint GMEM_MOVEABLE = 0x0002;
    private const uint GMEM_ZEROINIT = 0x0040;
    private const uint GMEM_DDESHARE = 0x2000;

    /// <summary>
    /// 将文本复制到剪贴板
    /// </summary>
    public static bool SetTextToClipboard(string text)
    {
        if (string.IsNullOrEmpty(text))
            return false;

        try
        {
            if (!OpenClipboard(IntPtr.Zero))
                return false;

            EmptyClipboard();

            var textBytes = Encoding.Unicode.GetBytes(text + '\0');
            uint allocSize = (uint)(textBytes.Length * sizeof(byte));
            IntPtr hGlobal = GlobalAlloc(GMEM_MOVEABLE | GMEM_DDESHARE | GMEM_ZEROINIT, (UIntPtr)allocSize);

            if (hGlobal == IntPtr.Zero)
                return false;

            try
            {
                IntPtr pGlobal = GlobalLock(hGlobal);
                if (pGlobal == IntPtr.Zero)
                    return false;

                try
                {
                    Marshal.Copy(textBytes, 0, pGlobal, textBytes.Length);
                }
                finally
                {
                    GlobalUnlock(hGlobal);
                }

                return SetClipboardData(CF_UNICODETEXT, hGlobal) != IntPtr.Zero;
            }
            finally
            {
            }
        }
        finally
        {
            CloseClipboard();
        }
    }
}