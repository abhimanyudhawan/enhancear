using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Addpros : MonoBehaviour {
    public TextMeshProUGUI format;
    private bool addheading = true;
    public string[] pros = { "Tasty", "High Calcium", "Low fructose" };

    public void Addnew(string pro)
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
            Debug.Log(format.GetComponent<TextMeshProUGUI>().text);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
