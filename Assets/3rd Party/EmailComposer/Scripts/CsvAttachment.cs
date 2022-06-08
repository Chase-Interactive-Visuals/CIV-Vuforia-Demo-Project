using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
 

public class CsvAttachment : MonoBehaviour
{
	private List<string> inventory = new List<string>();
    private List<string> OnlyX = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        inventory.Add("F");
        inventory.Add("J");
        OnlyX.Add("X");
    }

    // Update is called once per frame
 
    void Update()
    {
        string filePath = getPath();
 
        StreamWriter writer = new StreamWriter(filePath);
 
        writer.WriteLine("Inventory,OnlyX");
 
        for (int i = 0; i < inventory.Count; ++i)
        {
            for (int j = 0; j < OnlyX.Count; ++j) {
 
                writer.WriteLine(inventory[i] + "," + OnlyX[j]);
            }
       
        }
   
 
        writer.Flush();
        writer.Close();
    }
 
    private string getPath()
    {
string fileName = "Sample.csv";
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