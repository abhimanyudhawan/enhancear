using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class ParseItem : MonoBehaviour
{
    public static bool readytobeparsed = false;
    public Addcons con1;
    public Addpros pro1;

    private IEnumerator coroutine;
    public static bool search = false;
    public static string ndb = "01008";


    string path;
    string jsonString;
    int x = 1;
    int y = 1;

    private void Update()
    {
        if (readytobeparsed)
        {
            readytobeparsed = false;
            path = Application.persistentDataPath + "/data.json";
            jsonString = File.ReadAllText(path);
            //Debug.Log(jsonString);
            var obj = JSON.Parse(jsonString);

            string name = obj["report"]["foods"][0]["name"];
            Debug.Log("Name " + name);

            int eng;
            string energy = obj["report"]["foods"][0]["nutrients"][0]["value"];
            int.TryParse(energy, out eng);
            if (eng > 200)
            {
                Addcons.cons[y] = "High Calorie";
                y++;
            }
            else
            {
                Addpros.pros[x] = "Low Calorie";
                x++;
            }
            energy += obj["report"]["foods"][0]["nutrients"][0]["unit"];
            Debug.Log("Energy " + energy);

            int sod;
            string sodium = obj["report"]["foods"][0]["nutrients"][1]["value"];
            int.TryParse(sodium, out sod);

            if (sodium == "--")
            {
                sodium = "0";
            }
            else if (sod > 250)
            {
                Addcons.cons[y] = "High Sodium";
                y++;
            }
            else if (sod < 200)
            {
                Addpros.pros[x] = "Low Sodium";
                x++;
            }
            sodium += obj["report"]["foods"][0]["nutrients"][1]["unit"];
            Debug.Log("Sodium " + sodium);

            int prot;
            string protein = obj["report"]["foods"][0]["nutrients"][2]["value"];
            int.TryParse(protein, out prot);

            if (protein == "--")
            {
                protein = "0";
            }
            else if (prot < 3)
            {
                Addcons.cons[y] = "Low in Protein";
                y++;
            }
            else if (prot > 5)
            {
                Addpros.pros[x] = "Good in Protein";
                x++;
            }
            protein += obj["report"]["foods"][0]["nutrients"][2]["unit"];
            Debug.Log("Protein " + protein);

            int sug;
            string sugar = obj["report"]["foods"][0]["nutrients"][3]["value"];
            int.TryParse(sugar, out sug);

            if (sugar == "--")
            {
                sugar = "0";
            }
            else if (sug > 4)
            {
                Addcons.cons[y] = "High in Sugar";
                y++;
            }
            else if (sug < 4)
            {
                Addpros.pros[x] = "Low in Sugar";
                x++;
            }
            sugar += obj["report"]["foods"][0]["nutrients"][3]["unit"];
            Debug.Log("Sugar " + sugar);

            int fa;
            string fat = obj["report"]["foods"][0]["nutrients"][4]["value"];
            int.TryParse(fat, out fa);

            if (fat == "--")
            {
                fat = "0";
            }
            else if (fa > 3)
            {
                Addcons.cons[y] = "High in Fat";
                y++;
            }
            else if (fa < 2)
            {
                Addpros.pros[x] = "Low in Fat";
                x++;
            }
            fat += obj["report"]["foods"][0]["nutrients"][4]["unit"];
            Debug.Log("Fat " + fat);

            int chol;
            string cholesterol = obj["report"]["foods"][0]["nutrients"][5]["value"];
            int.TryParse(cholesterol, out chol);

            if (cholesterol == "--")
            {
                cholesterol = "0";
            }
            else if (chol > 2)
            {
                Addcons.cons[y] = "High in Cholesterol";
                y++;
            }
            else if (chol < 2)
            {
                Addpros.pros[x] = "Low in Cholesterol";
                x++;
            }
            cholesterol += obj["report"]["foods"][0]["nutrients"][5]["unit"];
            Debug.Log("Cholesterol " + cholesterol);

            pro1.Addnew();
            con1.Addnew();


            x = 1;
            y = 1;
        }
    }

}
