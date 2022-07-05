using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler 
{
    private string dataDirPath = "";

    private string dateFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dateFileName = dataFileName;
    }

    //public GameData Load()
    //{

    //}

    public void Save(GameData data)
    {
        //different operating systems use different file separators so we use Path.Combine
        string fullPath = Path.Combine(dataDirPath, dateFileName);
    }
}
