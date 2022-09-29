using UnityEngine;
using System.IO;

public class CSVLoader : MonoBehaviour {

    void Start () {
        //Debug.Log(File.Exists("Assets/Resources/file.csv"));
        TextAsset csv = Resources.Load("file") as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1) {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            foreach (var VARIABLE in values)
            {
                Debug.Log(VARIABLE);
            }
        }
    }
}