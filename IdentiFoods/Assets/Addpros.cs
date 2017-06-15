using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Addpros : MonoBehaviour
{
    public TextMeshProUGUI format;
    private bool addheading = true;
    public static string[] pros = { "", "", "", "", "", "", "", "" };
    
    public void Addnew()
    {
        if (addheading)
        {
            TextMeshProUGUI proheading = TextMeshProUGUI.Instantiate(format, this.transform, false);
            proheading.text = "Pros";
            addheading = false;
        }
        for (int i = 0; i < pros.Length; i++)
        {
            TextMeshProUGUI pro1 = TextMeshProUGUI.Instantiate(format, this.transform, false);
            pro1.text = pros[i];  
        }
    } 
}
