﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Addcons : MonoBehaviour {
    public TextMeshProUGUI format;
    public static string[] cons = { "", "", "", "", "", "", "" } ;
    private bool addheading = true;

    public void Addnew()
    {
        if (addheading)
        {
            TextMeshProUGUI proheading = TextMeshProUGUI.Instantiate(format, this.transform, false);
            proheading.text = "Cons";
            addheading = false;
        }
        for (int i = 0; i < cons.Length; i++)
        {
            TextMeshProUGUI con1 = TextMeshProUGUI.Instantiate(format, this.transform, false);
            con1.text = cons[i];
        }

    }
	
}
