using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class displayitem : MonoBehaviour {

    public GameObject textElement;
    public Canvas myCanvas;
    public TextMeshProUGUI tx1;
    public static bool displayed = false;
    public static bool removed = false;
    public bool allergens = false;

    string path;
    string jsonString;
    float lerpTime = 0.2f;

    public displayitem()
    {

        lerpTime = 0.2f;
        path= "";
        jsonString = "";
    }

    private void OnGUI()
    {        
        //Debug.Log("Hello");
        string[] pros = { "", "", "","","" };
        string[] cons = { "", "", "","","" };
//		string[] pros;
//		string[] cons;
		var x = 0;
		var y = 0;

        if (displayed == true)
        {
            path = Application.persistentDataPath + "/data.json";
            jsonString = File.ReadAllText(path);
            Debug.Log(jsonString);

            var obj = JSON.Parse(jsonString);
            
			string name = obj["report"]["foods"][0]["name"];
            Debug.Log("Name " + name);

            string energy = obj["report"]["foods"][0]["nutrients"][0]["value"];
            energy += obj["report"]["foods"][0]["nutrients"][0]["unit"];
            Debug.Log("Energy " + energy);

			int sod;
			string sodium = obj["report"]["foods"][0]["nutrients"][1]["value"];
			int.TryParse (sodium, out sod);

			if (sodium == "--") {
				sodium = "0";
			} else if (sod > 500) {
				cons [y] = "High Sodium";
				y++;
			} else if (sod < 500) {
				pros [x] = "Low Sodium";
				x++;
			}
			sodium += obj["report"]["foods"][0]["nutrients"][1]["unit"];
            Debug.Log("Sodium " + sodium);
            
			int prot;
			string protein = obj["report"]["foods"][0]["nutrients"][2]["value"];
			int.TryParse (protein, out prot);

			if (protein == "--") {
				protein = "0";
			} else if (prot < 3) {
				cons [y] = "Low in Protein";
				y++;
			}else if (prot > 5) {
				pros [x] = "Good in Protein";
				x++;
			}
            protein += obj["report"]["foods"][0]["nutrients"][2]["unit"];
            Debug.Log("Protein " + protein);
            
			int sug;
			string sugar = obj["report"]["foods"][0]["nutrients"][3]["value"];
			int.TryParse (sugar, out sug);

			if (sugar == "--"){
                sugar = "0";
			}else if (sug > 4) {
				cons [y] = "High in Sugar";
				y++;
			}else if (sug < 4) {
				pros [x] = "Low in Sugar";
				x++;
			}
            sugar += obj["report"]["foods"][0]["nutrients"][3]["unit"];
			Debug.Log("Sugar " + sugar);
            
			int fa;
			string fat = obj["report"]["foods"][0]["nutrients"][4]["value"];
			int.TryParse (fat, out fa);

			if (fat == "--"){
                fat = "0";
			}else if (fa > 3) {
				cons [y] = "High in Fat";
				y++;
			}else if (fa < 3) {
				pros [x] = "Low in Fat";
				x++;
			}
            fat += obj["report"]["foods"][0]["nutrients"][4]["unit"];
            Debug.Log("Fat " + fat);
            
			int chol;
			string cholesterol = obj["report"]["foods"][0]["nutrients"][5]["value"];
			int.TryParse (cholesterol, out chol);

			if (cholesterol == "--"){
                cholesterol = "0";
			}else if (chol > 2) {
				cons [y] = "High in Cholesterol";
				y++;
			}else if (chol < 2) {
				pros [x] = "Low in Cholesterol";
				x++;
			}
            cholesterol += obj["report"]["foods"][0]["nutrients"][5]["unit"];
            Debug.Log("Cholesterol " + cholesterol);


             
            if (allergens==true)
            {
                tx1.text = "Warning! \n HAS ALLERGENS";
            }
            for (int i = 0; i < pros.Length; i++)
            {
                if (textElement)
                {
                    TextMeshProUGUI t1 = textElement.GetComponentInChildren<TextMeshProUGUI>();
                    t1.text = pros[i];
                    Vector3 startPos = new Vector3(380, (-1 + i) * -50, 2);
                    Vector3 endPos = new Vector3(80, (-1 + i) * -50, 2);

                    GameObject go1 = Instantiate(textElement, startPos, Quaternion.identity) as GameObject;

                    go1.transform.SetParent(myCanvas.transform, false);
                    StartCoroutine(SlideAnimation(go1, startPos, endPos, lerpTime));
                }
            }
            for (int i = 0; i < cons.Length; i++)
            {
                //string previoustext = tx2.text;
                //tx2.text = "\n\n" + previoustext + "\n\n" + cons[i];
                TextMeshProUGUI t2 = textElement.GetComponentInChildren<TextMeshProUGUI>();

                t2.text = cons[i];
                Vector3 startPos = new Vector3(-380, (-1 + i) * -50, 2);
                Vector3 endPos = new Vector3(-80, (-1 + i) * -50, 2);

                GameObject go2 = Instantiate(textElement, startPos, Quaternion.identity) as GameObject;

                go2.transform.SetParent(myCanvas.transform, false);
                StartCoroutine(SlideAnimation(go2, startPos, endPos, lerpTime));
            }
            displayed = false;
        }
        else if (removed == true)
        {
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("mytext");
            foreach (GameObject obj in allObjects)
            {
                Destroy(obj);
            }
            allergens = false;
            //Destroy(allObjects[3]);
            removed = false;
			x = 0;
			y = 0;
        }
        
        }
    
    public void Displayed()
    {
        //Debug.Log(Text);
        

		ItemInfo itemInfo = JsonUtility.FromJson<ItemInfo>(jsonString);

//		string name = itemInfo.name;
//		string[] pros = itemInfo.pros;
//      string[] cons = itemInfo.cons;

		string[] pros = { "healthy", "protein", "carbs" };
		string[] cons = { "dry", "bitter", "pathetic", "repulsive"};
		  
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
//            string previoustext = tx2.text;
//            tx2.text = "\n\n" + previoustext + "\n\n" + cons[i];
            //TextMeshProUGUI t2 = textElement.GetComponentInChildren<TextMeshProUGUI>();

            //t2.text = cons[i];
            //Vector3 startPos = new Vector3(-380, (-1 + i) * -50, 2);
            //Vector3 endPos = new Vector3(-80, (-1 + i) * -50, 2);

            //GameObject go2 = Instantiate(textElement, startPos, Quaternion.identity) as GameObject;
            //go2.transform.SetParent(myCanvas.transform, false);
            //StartCoroutine(SlideAnimation(go2, startPos, endPos, lerpTime));
        }
    }
    IEnumerator SlideAnimation(GameObject go, Vector3 startPos, Vector3 endPos, float totTime)
    {
        float elapsedTime = 0;
        float waitTime = Time.deltaTime;
        Color startColor = new Color(1, 1, 1, 0);
        Color endColor = new Color(0, 0, 0, 0.5f);
        Color endTxtColor = new Color(0, 0, 0, 1);
        while (elapsedTime != totTime && go)
        {
            // Debug.Log("Pos is " + go.transform.localPosition);
            go.transform.localPosition = Vector3.Slerp(startPos, endPos, elapsedTime / totTime);
            go.transform.localPosition = new Vector3(go.transform.localPosition.x, endPos.y, go.transform.localPosition.z);

            TextMeshProUGUI txt = go.GetComponentInChildren<TextMeshProUGUI>();
            Image panel = go.GetComponentInChildren<Image>();
            //panel.transform.localScale = Vector2(txt.maxWidth, txt.maxHeight);
            // Debug.Log ()
            txt.material.color = Color.Lerp(startColor, endTxtColor, elapsedTime / totTime);
            panel.color = Color.Lerp(startColor, endColor, elapsedTime / totTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
