# Windows Easy Registry Writer

## 概要
Windowsにてレジストリを操作する必要のある高度な設定を簡単に実行可能なコンソールアプリケーションです。  

## 機能概要
* Stopping Antimalware service executable Application.
  * Antimalware Service Executableサービスをレジストリ書き換えによって停止させます。  

## 動作要件
* Windows 7以降のNT系Windows
* 管理者としての実行権限

## 注意
* レジストリを書き換えるため、今後新バージョンのWindowsが発表された場合に正しく動作しないかもしれません。  
* レジストリの書き換えはシステムに悪影響を及ぼす可能性があるため本来あまり行うべきではありません。実行は自己責任で。  
* レジストリのバックアップは取ったほうが良いです。万が一書き換えに失敗して動作しなくなった場合、回復環境から書き換えができるかもしれません。
