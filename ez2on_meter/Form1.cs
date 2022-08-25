using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 추가
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

// C:\Program Files (x86)\Windows Kits\10\UnionMetadata\10.0.19041.0\Windows.winmd
//using Windows.Graphics.Imaging;
//using Windows.Media.Ocr;

// C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Runtime.WindowsRuntime.dll

namespace ez2on_meter
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// EZ2ON Process Name
        /// </summary>
        private readonly static string m_ro_strEZ2ONProcessName = "EZ2ON";

        /// <summary>
        /// EZ2ON Point
        /// </summary>
        private Point m_pointEZ2ON = new Point();
        
        /// <summary>
        /// EZ2ON Size
        /// </summary>
        private Size m_sizeEZ2ON = new Size();

        /// <summary>
        /// EZ2ON OCR Text
        /// </summary>
        // private string m_strEZ2ONOCR = ""; // SUSPEND

        /// <summary>
        /// Form2 관련 변수
        /// </summary>
        private Form m_form2 = null;
        public static Bitmap m_bitmap = null;
        public static int m_iInterval = 100;


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OCR Language 체크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //// Check Extention Pack
            //if (OcrEngine.AvailableRecognizerLanguages.Count > 0)
            //{
            //    button_start.Enabled = true;
            //    button_stop.Enabled = false;
            //    label_message.ForeColor = Color.Blue;
            //    label_message.Text = "OCR LANGUAGE OK!";
            //}
            //else
            //{
            //    button_start.Enabled = false;
            //    button_stop.Enabled = false;
            //    label_message.ForeColor = Color.Red;
            //    label_message.Text = "OCR LANGUAGE FAIL! PLEASE INSTALL LANGUAGE PACK WITH OCR ENGINE!";
            //}

            button_start.Enabled = true;
            button_stop.Enabled = false;
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_Click(object sender, EventArgs e)
        {
            int iFlag = 1;

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if (process.ProcessName.Contains(m_ro_strEZ2ONProcessName))
                {
                    iFlag = 0;
                    break;
                }
            }

            if (iFlag == 0)
            {
                m_form2 = new Form2();
                m_form2.Show();

                button_start.Enabled = false;
                button_stop.Enabled = true;
                label_message.ForeColor = Color.Green;
                label_message.Text = "START!";
                timer.Start();
                timer_position.Start();
            }
            else
            {
                // MessageBox.Show("Process Error!");
                label_message.ForeColor = Color.Red;
                label_message.Text = "EZ2ON PROCESS ERROR!";
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_stop_Click(object sender, EventArgs e)
        {
            m_form2.Close();

            button_start.Enabled = true;
            button_stop.Enabled = false;
            label_message.ForeColor = Color.Green;
            label_message.Text = "STOP!";
            timer.Stop();
            timer_position.Stop();
        }

        /// <summary>
        /// EZ2ON Position 타이머 (1s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_position_Tick(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        /// <summary>
        /// 이미지 캡처 타이머 (가변)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            // await ImageToText(ImageCapture()); // SUSPEND
            ImageCapture();
        }

        /// <summary>
        /// EZ2ON Position 갱신
        /// </summary>
        private void UpdatePosition()
        {
            GetWindowPos(FindWindow(null, m_ro_strEZ2ONProcessName), ref m_pointEZ2ON, ref m_sizeEZ2ON);

            StringBuilder sb = new StringBuilder();
            sb.Append(m_ro_strEZ2ONProcessName);
            sb.Append(" X : ");
            sb.Append(m_pointEZ2ON.X.ToString("D4"));
            sb.Append(", Y : ");
            sb.Append(m_pointEZ2ON.Y.ToString("D4"));
            sb.Append(", W : ");
            sb.Append(m_sizeEZ2ON.Width.ToString("D4"));
            sb.Append(", H : ");
            sb.Append(m_sizeEZ2ON.Height.ToString("D4"));

            label_ez2on.Text = sb.ToString();
        }

        /// <summary>
        /// Image -> Text
        /// </summary>
        /// <param name="stream">Stream Image</param>
        /// <returns>Task</returns>
        //private async Task ImageToText(Stream stream)
        //{
        //    // HRRESULT
        //    try
        //    {
        //        // 구성 요소 인식
        //        BitmapDecoder bitmapDecoder = await BitmapDecoder.CreateAsync(stream.AsRandomAccessStream());

        //        // 이미지 헤더 인식
        //        SoftwareBitmap softwareBitmap = await bitmapDecoder.GetSoftwareBitmapAsync();

        //        // OS Default
        //        OcrEngine engine = OcrEngine.TryCreateFromUserProfileLanguages();
        //        OcrResult result = await engine.RecognizeAsync(softwareBitmap).AsTask();

        //        // m_strEZ2ONOCR = result.Text; // SUSPEND
        //    }
        //    catch (Exception)// ex)
        //    {

        //    }
        //}

        /// <summary>
        /// 이미지 캡처
        /// </summary>
        /// <returns>MemoryStream</returns>
        private Stream ImageCapture()
        {
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                /*
                정확한 좌표 값이 아님...

                2560 : 190 = 100 : x
                2560x = 19000
                x = 7.421875

                2560 : 300 = 100 : x
                2560x = 30000
                x = 11.71875

                1440 : 1300 = 100 : x
                1440x = 130000
                x = 90.27

                1440 : 1370 = 100 : x
                1440x = 137000
                x = 95.138

                1920 : 175 = 100 : x
                1920x = 17500
                x = 9.114583

                1080 : 75 = 100 : x
                1080x = 75 * 100
                x = 6.94
                */

                Bitmap bitmap = new Bitmap(Convert.ToInt32(m_sizeEZ2ON.Width * 0.09114583d), Convert.ToInt32(m_sizeEZ2ON.Height * 0.0694d));
                double dX = (m_sizeEZ2ON.Width * 0.08) + m_pointEZ2ON.X;
                int iX = Convert.ToInt32(dX);
                double dY = (m_sizeEZ2ON.Height * 0.89) + m_pointEZ2ON.Y;
                int iY = Convert.ToInt32(dY);

                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(iX, iY, 0, 0, bitmap.Size);

                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                // pictureBox.Image = bitmap;
                m_bitmap = bitmap;

                memoryStream.Position = 0;

                if (m_form2 != null)
                {
                    Size size = new Size(bitmap.Width + 5, bitmap.Height + 30);
                    m_form2.Size = size;
                }
            }
            catch (Exception)// ex)
            {
                label_message.ForeColor = Color.Red;
                label_message.Text = "MEMORY STREAM ERROR!";
            }

            return memoryStream;
        }

        /// <summary>
        /// 이미지 갱신 주기 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_refresh_Scroll(object sender, EventArgs e)
        {
            m_iInterval = trackBar_refresh.Value * 10;
            timer.Interval = m_iInterval;

            StringBuilder sb = new StringBuilder();
            sb.Append("REFRESH : ");
            sb.Append(m_iInterval);
            sb.Append(" ms");

            label_refresh.Text = sb.ToString();
        }

        /// <summary>
        /// Form2 투명도 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_opacity_Scroll(object sender, EventArgs e)
        {
            int itmp = trackBar_opacity.Value * 10;

            StringBuilder sb = new StringBuilder();
            sb.Append("OPACITY : ");
            sb.Append(itmp);
            sb.Append(" %");

            label_opacity.Text = sb.ToString();

            if (m_form2 != null)
            {
                m_form2.Opacity = itmp / 100d;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 핸들러 찾기
        /// </summary>
        /// <param name="class_name"></param>
        /// <param name="window_name"></param>
        /// <returns>Window Handler</returns>
        [DllImport("USER32.DLL", SetLastError = true)]
        public static extern IntPtr FindWindow(string class_name, string window_name);

        /// <summary>
        /// Window Position 반환
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="placement"></param>
        /// <returns>Position Info</returns>
        [DllImport("user32.dll")]
        internal static extern bool GetWindowPlacement(IntPtr handle, ref WINDOWPLACEMENT placement);

        /// <summary>
        /// Window Position 계산
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="point"></param>
        /// <param name="size"></param>
        private void GetWindowPos(IntPtr hwnd, ref Point point, ref Size size)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);

            GetWindowPlacement(hwnd, ref placement);

            size = new Size(placement.normal_position.Right - (placement.normal_position.Left * 2), placement.normal_position.Bottom - (placement.normal_position.Top * 2));
            point = new Point(placement.normal_position.Left, placement.normal_position.Top);
        }
    }

    /// <summary>
    /// Status
    /// </summary>
    internal enum SHOW_WINDOW_COMMANDS : int
    {
        HIDE = 0,
        NORMAL = 1,
        MINIMIZED = 2,
        MAXIMIZED = 3,
    }

    /// <summary>
    /// Position Info
    /// </summary>
    internal struct WINDOWPLACEMENT
    {
        public int length;
        public int flags;
        public SHOW_WINDOW_COMMANDS showc_cmd;
        public Point min_position;
        public Point max_position;
        public Rectangle normal_position;
    }
}
