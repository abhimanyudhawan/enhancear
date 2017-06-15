using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class FindItem : MonoBehaviour
{
    private IEnumerator coroutine;
    public static bool search = false;
    public static string ndb = "01008";

    private void Update()
    {
        coroutine = data();
        StartCoroutine(coroutine);
    }

    private IEnumerator data()
    {
        if (search == true)
        {
            string path;
            search = false;
            string ndb_no = ndb;
        

            //var url = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=18642&type=f&format=json&api_key=CDzFSzR1gUuXPi9uCjACVivpFhlYxQdoTaCYIqc8";
            var url = "https://api.nal.usda.gov/ndb/nutrients/?format=json&api_key=CDzFSzR1gUuXPi9uCjACVivpFhlYxQdoTaCYIqc8&nutrients=208&nutrients=203&nutrients=269&nutrients=307&nutrients=204&nutrients=601&ndbno=" + ndb_no;
            //var url = "https://api.nal.usda.gov/ndb/reports/?ndbno=01009&type=f&format=json&api_key=DEMO_KEY";
            WWW www = new WWW(url);
            yield return www;

            // and check for errors
            if (www.error == null)
            {
                // request completed!
                path = Application.persistentDataPath + "/data.json";
                File.WriteAllText(path, www.text);
                ParseItem.readytobeparsed = true;
                Debug.Log(www.text);

            }
            else
            {
                // something wrong!
                Debug.Log("WWW Error: " + www.error);
            }

        }
    }

}
