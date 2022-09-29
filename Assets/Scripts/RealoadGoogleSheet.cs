using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class RealoadGoogleSheet : MonoBehaviour
{
     const string SHEET_ID = "1mcOwCd03_Mz5rYHn5oJ3MVC0vKffDWg8SE4Y-Uehb1Y";
        const string SHEET_NAME = "シート1";
    
        IEnumerator Method(string _SHEET_NAME){
            UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/"+SHEET_ID+"/gviz/tq?tqx=out:csv&sheet="+_SHEET_NAME);
            yield return request.SendWebRequest();
    
            if(request.isHttpError || request.isNetworkError) {
                Debug.Log(request.error);
            }
            else{
                Debug.Log(request.downloadHandler.text);
            }
        }
        public void ReLoadGoogleSheet(){
            StartCoroutine(Method(SHEET_NAME));     
        }

        private void Start()
        {
            ReLoadGoogleSheet();
        }
        
        void ViewCSV(string _text){
            StringReader reader = new StringReader(_text);
            string[] headerline = null;
            while (reader.Peek() != -1){
                string line = reader.ReadLine();        // 一行ずつ読み込み
                string[] elements = line.Split(',');    // 行のセルは,で区切られる
                for(int i=0; i<elements.Length; i++){
                    if(elements[i] == "\"\""){
                        continue;                       // 空白は除去
                    }
                    elements[i] = elements[i].TrimStart('"').TrimEnd('"');
                    Debug.Log(elements[i]);
                }
            }
        }
}
