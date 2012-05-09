using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security.Permissions;
using System.Globalization;

namespace water
{
    public static class global
    {
        public static Sunisoft.IrisSkin.SkinEngine myskin;
        public static string skin_name;
        public static string AppPath;
        public static string sqlconstr;
        public static string current_user;
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);//读取INI配置文件
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(string section, string key, string val, string filePath);//写INI配置文件
    }
}
