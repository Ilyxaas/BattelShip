using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class FileEditor : EditorWindow
{

    //
    // Функция которая вызывает открытие файлового проводника
    //


    [MenuItem("Example/Overwrite Texture")]
    public static IEnumerable<string> OpenFileManager()
    {


       string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "");
       if (path.Length != 0)
       {
            IEnumerable<string> Linefile;

            Linefile = File.ReadLines(path);

            return Linefile;
       }
        return null;
   }


    //
    // Функция которая вызывает сохранение файлового проводника
    //


   [MenuItem("Example/Overwrite Texture")]
   public static IEnumerable<string> SaveFileManager()
   {


        string path = EditorUtility.SaveFilePanel("Overwrite with png", "", "", "");
        if (path.Length != 0)
       {
           IEnumerable<string> Linefile;

            Linefile = File.ReadLines(path);

            return Linefile;
        }
        return null;
   }
}
