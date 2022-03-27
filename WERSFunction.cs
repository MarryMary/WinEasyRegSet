using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEasyRegSet
{
    internal class WERSFunction
    {
       public static bool AMSEABlock()
        {
            try
            {
                // レジストリキーを展開
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows Defender",true);

                // DisableAntiSpywareの値を1へ書き換え
                key.SetValue("DisableAntiSpyware", 1);

                // レジストリキーを終了
                key.Close();


                return true;
            }catch (Exception ex)
            {

                // 問題が発生した場合メッセージを表示
                Console.WriteLine("The application has been closed because of a problem.");

                // エラー内容をテキストファイルに保存
                WERSTools.LogWriter(ex.ToString());

                // 終了
                return false;
            }
        }
    }
}
