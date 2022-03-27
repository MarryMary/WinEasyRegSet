using System;
using System.IO;
using System.Text;

namespace WinEasyRegSet
{
    class WERSMain
    {
        static void Main()
        {
            bool startup_result = WERSTools.StartUpCheck();
            if (startup_result)
            {
                WERSTools.MenuViewer();
                while (true)
                {
                    // ユーザー入力
                    var user_selected = WERSTools.WERSIO();

                    // ユーザー入力を評価
                    var menu_judge = WERSTools.MenuViewer(false, user_selected);

                    // ユーザー入力がメニューにあれば
                    if (menu_judge)
                    {
                        var result = WERSTools.Executer(user_selected);
                        if (result)
                        {
                            continue;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }

                    // なければ
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                // 起動チェックで未達成の項目があった場合はアプリケーションを終了させる
                Environment.Exit(0);
            }
        }
    }
}