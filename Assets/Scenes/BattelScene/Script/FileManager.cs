using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    //
    //  Вызываем при нажатии на кнопку загрузить сохранение
    //
    public void LoadSaveGame()
    {

        IEnumerable Num = FileEditor.OpenFileManager();
        if (Num != null)
        {

            IEnumerator ie = Num.GetEnumerator();
           while (ie.MoveNext())
            {
               print(ie.Current);
            }
        }


    }

    //
    //вызываем при нажатии на кнопку симуляци
    //

    public void LoadSimylationGame()
    {
       IEnumerable Num = FileEditor.OpenFileManager();
       if (Num != null)
        {

            IEnumerator ie = Num.GetEnumerator();
           while (ie.MoveNext())
            {
               print(ie.Current);
            }
        }



    }

    //
    //Вызываем при на жатии сохранить игру
    //

    public void SaveGame()
    {



    }
}
