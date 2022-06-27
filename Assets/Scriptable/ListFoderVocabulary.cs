using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "ListFoderVoca")]
public class ListFoderVocabulary : ScriptableObject
{
    public List<string> listFoder = new List<string>();
    string path;
  
    public void GetFoder(string temp)
    {
        listFoder.Clear();
        string[] list = temp.Split(' ');
        foreach (string item in list) { listFoder.Add(item);}      
    }
    public void SetPath()
    {
        path = Application.persistentDataPath + "/Foder/ListFoder.txt";
    }
    public bool ExitFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/Foder");
    }

    public void CreateFilePath()
    {
        if (!ExitFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Foder");
        }
        if (!File.Exists(path))
        {
            FileStream file = File.Create(path);
        }
    }

    public void DeleteFoder(int fodeIndex)
    {
        listFoder.RemoveAt(fodeIndex);      
    }
    public void WriteToFile()
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (var item in listFoder)
            {
                string temp = item;
                writer.WriteLine(temp);
            }
            writer.Close();
        }
    }
    public void LoadFile()
    {
        listFoder.Clear();
        string line;
        using (StreamReader reder = new StreamReader(path))
        {
            while ((line = reder.ReadLine()) != null)
            {

                listFoder.Add(line);

            }
            reder.Close();
        }
    }
}
