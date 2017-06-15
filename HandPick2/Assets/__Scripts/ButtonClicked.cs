using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//namespace TMPro.Examples
public class ButtonClicked : MonoBehaviour
{
    string path;
    string jsonString;
    public GameObject textElement;
    public Canvas myCanvas;
    float lerpTime = 0.2f;

    bool bClicked = false;

    


    public void Clicked()
    {
        path = Application.streamingAssetsPath + "/data.json";
        jsonString = File.ReadAllText(path);
        ItemInfo itemInfo =  JsonUtility.FromJson<ItemInfo>(jsonString);
		string[] pros = { "healthy", "protein", "carbs" };
		string[] cons = { "dry", "bitter", "pathetic", "repulsive"};
        //string name = itemInfo.name;
        //string[] pros = itemInfo.pros;
       // string[] cons = itemInfo.cons;
		//Debug.Log(itemInfo.name);


        if (bClicked == false)
        {
            for (int i = 0; i < pros.Length; i++)
            {
                Vector3 startPos = new Vector3(380, (-1 + i) * -50, 2);
                Vector3 endPos = new Vector3(80, (-1 + i) * -50, 2);
                Text t1 = textElement.GetComponentInChildren<Text>();
                t1.text = pros[i];
                //t1.material.color = new Color(0, 0, 0);
                //Image panel = textElement.GetComponentInChildren<Image>();
                //panel.color = new Color(0, 0, 0);
                GameObject go1 = Instantiate(textElement, startPos, Quaternion.identity) as GameObject;
                go1.transform.SetParent(myCanvas.transform, false);
                StartCoroutine(SlideAnimation(go1, startPos, endPos, lerpTime));
            }
            for (int i = 0; i < cons.Length; i++)
            {
                Vector3 startPos = new Vector3(-380, (-1 + i) * -50, 2);
                Vector3 endPos = new Vector3(-80, (-1 + i) * -50, 2);
                Text t2 = textElement.GetComponentInChildren<Text>();
                t2.text = cons[i];
                GameObject go2 = Instantiate(textElement, startPos, Quaternion.identity) as GameObject;
                go2.transform.SetParent(myCanvas.transform, false);
                StartCoroutine(SlideAnimation(go2, startPos, endPos, lerpTime));

            }
            bClicked = true;
        }
    }

    IEnumerator SlideAnimation(GameObject go, Vector3 startPos, Vector3 endPos, float totTime)
    {
        float elapsedTime = 0;
        float waitTime = Time.deltaTime;
        Color startColor = new Color(1, 1, 1, 0);
        Color endColor = new Color(0, 0, 0, 0.5f);
        Color endTxtColor = new Color(0, 0, 0, 1);
        while (elapsedTime != totTime)
        {
            // Debug.Log("Pos is " + go.transform.localPosition);
            go.transform.localPosition = Vector3.Slerp(startPos, endPos, elapsedTime / totTime);
            go.transform.localPosition = new Vector3(go.transform.localPosition.x, endPos.y, go.transform.localPosition.z);

            Text txt = go.GetComponentInChildren<Text>();
            Image panel = go.GetComponentInChildren<Image>();
            txt.material.color = Color.Lerp(startColor, endTxtColor, elapsedTime / totTime);
            panel.color = Color.Lerp(startColor, endColor, elapsedTime / totTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}