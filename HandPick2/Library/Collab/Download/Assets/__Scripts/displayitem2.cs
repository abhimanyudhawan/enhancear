using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class displayitem2 : MonoBehaviour
{

    public GameObject textElement;
    public Canvas myCanvas;
    public TextMeshProUGUI tx1;
    public TextMeshProUGUI tx2;
    public static bool displayed2 = false;
    public static bool removed2 = false;

    string path;
    string jsonString;
    float lerpTime = 0.2f;

    public displayitem2()
    {

        lerpTime = 0.2f;
        path = "";
        jsonString = "";
    }

    private void OnGUI()
    {
        if (displayed2 == true)
        {
            //Debug.Log("Hello");
            string[] pros = { "healthy", "protein", "carbs" };
            string[] cons = { "dry", "bitter", "pathetic", "repulsive" };
            for (int i = 0; i < pros.Length; i++)
            {
                string previoustext = tx1.text;
                tx1.text = previoustext + "\n" + pros[i] + "\n";
            }
            for (int i = 0; i < cons.Length; i++)
            {
                string previoustext = tx2.text;
                tx2.text = previoustext + "\n" + cons[i] + "\n";
            }
            displayed2 = false;
        }
        //if(removed==true)
        //{
        //    tx1.text = "";
        //    tx2.text = "";
        //}
    }
    public void Displayed()
    {
        //Debug.Log(Text);
        path = Application.streamingAssetsPath + "/data.json";
        jsonString = File.ReadAllText(path);
        Debug.Log(jsonString);

        var obj = JSON.Parse(jsonString);
        string name = obj["report"]["foods"][0]["name"];
        Debug.Log("Name " + name);
        string energy = obj["report"]["foods"][0]["nutrients"][0]["value"];
        energy += obj["report"]["foods"][0]["nutrients"][0]["unit"];
        Debug.Log("Energy " + energy);
        string sodium = obj["report"]["foods"][0]["nutrients"][1]["value"];
        if (sodium == "--")
        {
            sodium = "0";
        }
        sodium += obj["report"]["foods"][0]["nutrients"][1]["unit"];
        Debug.Log("Sodium " + sodium);
        string protein = obj["report"]["foods"][0]["nutrients"][2]["value"];
        if (protein == "--")
        {
            protein = "0";
        }
        protein += obj["report"]["foods"][0]["nutrients"][2]["unit"];
        Debug.Log("Protein " + protein);
        string sugar = obj["report"]["foods"][0]["nutrients"][3]["value"];
        if (sugar == "--")
        {
            sugar = "0";
        }
        sugar += obj["report"]["foods"][0]["nutrients"][3]["unit"];
        Debug.Log("Sugar " + sugar);
        string fat = obj["report"]["foods"][0]["nutrients"][4]["value"];
        if (fat == "--")
        {
            fat = "0";
        }
        fat += obj["report"]["foods"][0]["nutrients"][4]["unit"];
        Debug.Log("Fat " + fat);
        string cholesterol = obj["report"]["foods"][0]["nutrients"][5]["value"];
        if (cholesterol == "--")
        {
            cholesterol = "0";
        }
        cholesterol += obj["report"]["foods"][0]["nutrients"][5]["unit"];
        Debug.Log("Cholesterol " + cholesterol);


        ItemInfo itemInfo = JsonUtility.FromJson<ItemInfo>(jsonString);

        //		string name = itemInfo.name;
        //		string[] pros = itemInfo.pros;
        //      string[] cons = itemInfo.cons;

        string[] pros = { "healthy", "protein", "carbs" };
        string[] cons = { "dry", "bitter", "pathetic", "repulsive" };

        for (int i = 0; i < pros.Length; i++)
        {

            //TextMeshProUGUI t1 = textElement.GetComponentInChildren<TextMeshProUGUI>();
            //t1.text = pros[i];
            //Vector3 startPos = new Vector3(380, (-1 + i) * -50, 2);
            //Vector3 endPos = new Vector3(80, (-1 + i) * -50, 2);

            //GameObject go1 = Instantiate(textElement, startPos, Quaternion.identity) as GameObject;
            //go1.transform.SetParent(myCanvas.transform, false);
            //StartCoroutine(SlideAnimation(go1, startPos, endPos, lerpTime));
        }
        for (int i = 0; i < cons.Length; i++)
        {
            string previoustext = tx2.text;
            tx2.text = "\n\n" + previoustext + "\n\n" + cons[i];
            //TextMeshProUGUI t2 = textElement.GetComponentInChildren<TextMeshProUGUI>();

            //t2.text = cons[i];
            //Vector3 startPos = new Vector3(-380, (-1 + i) * -50, 2);
            //Vector3 endPos = new Vector3(-80, (-1 + i) * -50, 2);

            //GameObject go2 = Instantiate(textElement, startPos, Quaternion.identity) as GameObject;
            //go2.transform.SetParent(myCanvas.transform, false);
            //StartCoroutine(SlideAnimation(go2, startPos, endPos, lerpTime));
        }
    }
    //    IEnumerator SlideAnimation(GameObject go, Vector3 startPos, Vector3 endPos, float totTime)
    //    {
    //        float elapsedTime = 0;
    //        float waitTime = Time.deltaTime;
    //        Color startColor = new Color(1, 1, 1, 0);
    //        Color endColor = new Color(0, 0, 0, 0.5f);
    //        Color endTxtColor = new Color(0, 0, 0, 1);
    //        while (elapsedTime != totTime)
    //        {
    //            // Debug.Log("Pos is " + go.transform.localPosition);
    //            go.transform.localPosition = Vector3.Slerp(startPos, endPos, elapsedTime / totTime);
    //            go.transform.localPosition = new Vector3(go.transform.localPosition.x, endPos.y, go.transform.localPosition.z);

    //            TextMeshProUGUI txt = go.GetComponentInChildren<TextMeshProUGUI>();
    //            Image panel = go.GetComponentInChildren<Image>();
    ////panel.transform.localScale = Vector2(txt.maxWidth, txt.maxHeight);
    //           // Debug.Log ()
    //            txt.material.color = Color.Lerp(startColor, endTxtColor, elapsedTime / totTime);
    //            panel.color = Color.Lerp(startColor, endColor, elapsedTime / totTime);
    //            elapsedTime += Time.deltaTime;
    //            yield return new WaitForEndOfFrame();
    //        }
    //    }
}
