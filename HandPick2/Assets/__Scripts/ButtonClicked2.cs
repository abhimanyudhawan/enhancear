using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples
{
    public class ButtonClicked2 : MonoBehaviour
    {
        public GameObject textElement;
        public Canvas myCanvas;

        bool bClicked = false;

        string[] pros = {"healthy","protein","carbs" };
        string[] cons = {"dry","bitter"};
      //  private const string label = "The <#0050FF>count is: </color>{0:2}";
       // private float m_frame;


        public void Clicked()
        {
            if (bClicked == false)
            {
                RectTransform rectTransform = textElement.GetComponent<RectTransform>();
                //m_textMeshPro = gameObject.AddComponent<TextMeshPro>();
               // m_textMeshPro.autoSizeTextContainer = true;
               // m_textMeshPro.fontSize = 48;

               // m_textMeshPro.alignment = TextAlignmentOptions.Center;

                for (int i = 0; i < pros.Length; i++)
                {
                    TextMeshPro t1 = textElement.GetComponentInChildren<TextMeshPro>();
                    //t1.autoSizeTextContainer = true;
                    //t1.fontSize = 48;
                   // t1.alignment = TextAlignmentOptions.Center;
                    //t1.enableWordWrapping = false;

                    //t1.SetText(pros[i]);
                    t1.text = pros[i];
                   
                    Vector3 textPos = new Vector3(200, i * -50, 2);
                    GameObject go1 = Instantiate(textElement, textPos, Quaternion.identity) as GameObject;
                    go1.transform.SetParent(myCanvas.transform, false);
                }
                for (int i = 0; i < cons.Length; i++)
                {
                    TextMeshPro t2 = textElement.GetComponentInChildren<TextMeshPro>();
                    //t2.autoSizeTextContainer = true;
                    //t2.fontSize = 48;
                    //t2.alignment = TextAlignmentOptions.Center;
                    //t2.enableWordWrapping = false;

                    //t2.SetText(cons[i]);
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
