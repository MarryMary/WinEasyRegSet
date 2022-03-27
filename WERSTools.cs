using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEasyRegSet
{
    internal class WERSTools
    {
        public static bool StartUpCheck()
        {
            // システム情報取得
            System.OperatingSystem os = System.Environment.OSVersion;

            // アプリケーション情報取得
            var assm = System.Reflection.Assembly.GetExecutingAssembly();
            var name = assm.GetName();

            // WinNT系か？
            if (os.Platform == PlatformID.Win32NT)
            {
                // Win Vista以降か？
                if (os.Version.Major >= 6)
                {
                    // Win 7以降か？
                    if (os.Version.Minor >= 1)
                    {
                        Console.WriteLine("Welcome to Windows Easy Registory Writer.");
                        Console.WriteLine("Application Version: {0}", name.Version);
                        return true;
                    }
                    // 7未満であればfalse返却
                    else
                    {
                        Console.WriteLine("Does not meet the operating requirements. Exit the app.");
                        return false;
                    }
                }
                // Vista未満であればfalse返却
                else
                {
                    Console.WriteLine("Does not meet the operating requirements. Exit the app.");
                    return false;
                }
            }
            // NT系でなければfalse返却
            else
            {
                Console.WriteLine("Does not meet the operating requirements. Exit the app.");
                return false;
            }
        }

        public static bool MenuViewer(bool mode=true, string key = "")
        {
            try
            {
                var MenuList = new Dictionary<string, string>()
                {
                    {"1", "Stopping Antimalware service executable Application."},
                    {"exit", "Application exit" }
                };

                // メニュー表示モード
                if (mode)
                {
                    foreach (KeyValuePair<string, string> menu in MenuList)
                    {
                        string id = menu.Key;
                        string name = menu.Value;
                        Console.WriteLine($"{id}:{name}");
                    }
                    return true;
                }
                // メニュー評価モード（渡されたメニューが存在するかどうか）
                else
                {
                    // もしキーが空なら
                    if(key != "")
                    {
                        return false;
                    }
                    // そうでなければ
                    else
                    {
                        // MenuList(メニュー一覧辞書）に指定されたキーが存在するか？
                        if (MenuList.ContainsKey(key))
                        {
                            return true;
                        }
                        // 存在しなければ
                        else
                        {
                            return false;
                        }
                    }
                }
                //問題が発生した場合
            }catch (Exception ex)
            {
                Console.WriteLine("The application has been closed because of a problem.");
                LogWriter(ex.ToString());
                return false;
            }
        }

        public static string WERSIO()
        {
            // ユーザーに入力を促す表示
            Console.Write("Please select number.>>");
            
            //入力を受ける
            string str = Console.ReadLine();
            // 入力を返却
            return str;
        }

        public static bool Executer(string key)
        {
            var MenuFunction = new Dictionary<string, bool>()
                {
                    {"1", WERSFunction.AMSEABlock()},
                    {"exit", false }
                };

            return MenuFunction[key];
        }

        public static void LogWriter(String text)
        {
            // ファイルのエンコーディングをUTF-8として指定
            Encoding enc = Encoding.GetEncoding("utf-8");

            // WinEasyRegSetERRLog.txtファイルを開く
            StreamWriter writer = new StreamWriter(@"WinEasyRegSetERRLog.txt", true, enc);

            // 渡されたエラーメッセージをファイルに書き込み
            writer.WriteLine(text);

            // ファイルを閉じる
            writer.Close();
        }
    }
}
