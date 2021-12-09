using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        [DllImport("testDLL.dll")]
        public static extern void test1();
        [DllImport("testDLL.dll")]
        public static extern double test2(int a, double b);
        [DllImport("testDLL.dll")]
        public static extern IntPtr test3(byte[] str);

        static unsafe string MarshalUtf8ToUnicode(IntPtr pStringUtf82)
        {
            var pStringUtf8 = (byte*)pStringUtf82;
            var len = 0;
            while (pStringUtf8[len] != 0)
                len++;
            return Encoding.UTF8.GetString(pStringUtf8, len);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test1();
            var ret1 = test2(3, 0.8f);
            Console.WriteLine(ret1);
            var pStr = test3(Encoding.UTF8.GetBytes("탕수육"));
            string str = MarshalUtf8ToUnicode(pStr);
            Console.WriteLine(str);

        }
    }
}
