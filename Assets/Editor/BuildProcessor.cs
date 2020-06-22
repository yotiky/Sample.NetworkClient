using NUnit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BuildProcessor : IPreprocessBuildWithReport, IPostprocessBuildWithReport
{
    // 実行される順番
    public int callbackOrder => 0;

    // ビルド前処理
    public void OnPreprocessBuild(BuildReport report)
    {
        //var info = new ProcessStartInfo();
        //info.FileName = "cmd.exe";
        //info.Arguments = $"/c " + "Utf8JsonGenerate.bat";
        //info.WorkingDirectory = Environment.CurrentDirectory;
        //info.WindowStyle = ProcessWindowStyle.Hidden;
        //info.UseShellExecute = false;
        //info.RedirectStandardOutput = true;

        //Process process = null;
        //try
        //{
        //    process = Process.Start(info);

        //    Debug.Log(process.StandardOutput.ReadToEnd());
        //    process.WaitForExit();
        //}
        //finally
        //{
        //    if (process != null)
        //    {
        //        if (!process.HasExited)
        //        {
        //            process.Kill();
        //        }
        //        process.Dispose();
        //        process = null;
        //    }
        //}
    }

    // ビルド後処理
    public void OnPostprocessBuild(BuildReport report)
    {
    }
}
