using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
 

public class TextFileCreation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        CreateText();
    }

    // Update is called once per frame
 
    void CreateText()
    {
        string path = getPath();
 
        if (!File.Exists(path)) {
            File.WriteAllText(path, "Login Log \n\n");
        }

        string content = "Login Date: "+ System.DateTime.Now + "\n";
        File.AppendAllText(path, content);

    }
 
    private string getPath()
    {

    string fileName = "Log.txt";
#if UNITY_EDITOR
        return Application.dataPath + "/"  + fileName;
        //"Participant " + "   " + DateTime.Now.ToString("dd-MM-yy   hh-mm-ss") + ".csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+fileName;
#else
        return Application.dataPath +"/"+fileName;
#endif
    }
}