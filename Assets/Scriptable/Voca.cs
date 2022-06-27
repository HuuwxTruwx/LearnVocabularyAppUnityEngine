
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWord")]
public class Voca : ScriptableObject
{
    public Dictionary<string, string> Vocabularys = new Dictionary<string, string>();
    string path;
    private void Awake()
    {
        //CreateFilePath();
        //path = Application.persistentDataPath + "/Text/test.txt";
    }
    public void SetPath(string fileName)
    {
         path = Application.persistentDataPath + "/Text/" + fileName + ".txt";
    }
    public int NumberElement()
    {
        return Vocabularys.Count;
    }
    public string GetEnglish(int _index)
    {
        if (Vocabularys != null)
        {
            return Vocabularys.ElementAt(_index).Key;
        }
        return null;
    }

    public string GetVietNameseAnswer(string m)
    {
        Vocabularys.TryGetValue(m, out string result);
        return result;
    }

    public int GetIndexAswer(string m)
    {
        for (int i = 0; i < Vocabularys.Count; i++)
        {
            if (m == Vocabularys.ElementAt(i).Key)
            {
                return i;
            }
        }
        return -1;
    }

    public string GetVietNamese(int i)
    {
        return Vocabularys.ElementAt(i).Value;
    }


    public bool AddToList(string e, string v)
    {
        if (!Vocabularys.ContainsKey(e))
        {
            Vocabularys.Add(e, v);
            return true;
        }
        return false;
    }
    public void UpdateList(int itemIndex , string key,string value)
    {
        DeleteFromList(itemIndex);
        AddToList(key, value);
    }

    public void DeleteFromList(int itemIndex)
    {
        string key = Vocabularys.ElementAt(itemIndex).Key;
        Vocabularys.Remove(key);
    }
    public bool ExitFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/Text");
    }

    public void CreateFilePath()
    {
        if (!ExitFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Text");
        }
        if (!File.Exists(path))
        {
            FileStream file = File.Create(path);
        }
    }

    public void DeleteFile(string fileName)
    {
        SetPath(fileName);
        File.Delete(path);
    }
    public void WriteToFile()
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (var item in Vocabularys)
            {
                string temp = item.Key + ":" + item.Value;
                writer.WriteLine(temp);
            }
            writer.Close();
        }
    }
   
    public void LoadFile()
    {
        Debug.Log(path);
        Vocabularys.Clear();
        string line;
        using (StreamReader reder = new StreamReader(path))
        {
            while ((line = reder.ReadLine()) != null)
            {
                string[] temp = line.Split(':');
                AddToList(temp[0], temp[1]);

            }
            reder.Close();
        }
    }
}