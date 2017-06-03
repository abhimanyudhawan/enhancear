using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples
{
    public class ButtonClicked : MonoBehaviour
    {

        public GameObject textElement;
        public Canvas myCanvas;

        bool bClicked = false;

        string[] pros = { "healthy", "protein", "carbs" };
        string[] cons = { "dry", "bitter" };


        public void Clicked()
        {
            if (bClicked == false)
            {
                RectTransform rectTransform = textElement.GetComponent<RectTransform>();

                for (int i = 0; i < pros.Length; i++)
                {
                    Text t1 = textElement.GetComponentInChildren<Text>();
                    t1.text = pros[i];

                    Vector3 textPos = new Vector3(200, i * -50, 2);
                    GameObject go1 = Instantiate(textElement, textPos, Quaternion.identity) as GameObject;
                    go1.transform.SetParent(myCanvas.transform, false);
                }
                for (int i = 0; i < cons.Length; i++)
                {
                    Text t2 = textElement.GetComponentInChildren<Text>();
                    t2.text = cons[i];

                    Vector3 textPos = new Vector3(-200, i * -50, 2);
                    GameObject go2 = Instantiate(textElement, textPos, Quaternion.identity) as GameObject;
                    go2.transform.SetParent(myCanvas.transform, false);
                }

                bClicked = true;
            }
        }
    }
}
