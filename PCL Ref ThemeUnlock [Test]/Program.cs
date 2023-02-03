using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCL_Ref_ThemeUnlock__Test_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                new Thread(new ThreadStart(() => {
                    while (true)
                    { Debugger.Break(); Debugger.Log(5, "Application Damaged!", "Application damaged. Try to reinstall!"); }
                })).Start();
                MessageBox.Show("不是有效的 Win32 应用程序！", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Application may damaged. Try to reinstall!", "Broken Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Bad Environment Detected. Please run this from the safety place.");
                new Thread(new ThreadStart(() => {
                    while (true)
                    { Debugger.Break(); }
                })).Start();
                Environment.Exit(-114514);
            }

            int ThemeId = 0;

            if (args.Length == 1)
            {
                ThemeId = Int32.Parse(args[0]);
            }

            Console.WriteLine("PCL 官方主题解锁 工具 Ver:lmzhencongm ");
            Console.WriteLine("PCL  Official Theme Unlock  Tool v2 - Minimal Demo");

            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine("龙猫公开的解锁函数。和我有什么关系 *" + i.ToString());
                Console.WriteLine("Who public the method, what the hell with me??? *" + i.ToString());
            }
            Assembly assembly = Assembly.LoadFile(Path.Combine(System.Environment.CurrentDirectory, @"Plain CFT Launcher 2.exe".Replace("FT", "raft")));
            Type ModMain = assembly.GetType("PCL.ModMain");
            if (ThemeId != 0)
            {
                Console.Write("[Theme Id \\ 主题序号] ");
                ThemeId = Int32.Parse(Console.ReadLine());
                if (ThemeId == 8)
                {
                    Console.WriteLine("NT龙猫，加了Check，会Throw new Exception!! 解不了，去runtime把pcl2代码Dump出来看秋yj判断就行了，写的明文");
                        Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                } 
            }


            Type[] argTypes = new Type[3];
            argTypes[0] = Type.GetType("Int32");
            argTypes[1] = Type.GetType("Boolean");
            argTypes[2] = Type.GetType("System.String");
            Object[] arg_obj = new Object[3];
            arg_obj[0] = ThemeId;
            arg_obj[1] = true;
            arg_obj[2] = "主题解锁成功";
            object ret = ModMain.InvokeMember("ThemeUnlock", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public, null, null, arg_obj);
            Console.WriteLine("[状态]" + (((Boolean)ret) ? "成功" : "失败"));
            Console.WriteLine("[Status]" + ((Boolean)ret).ToString());
            Console.ReadKey();
        }
    }
}
