using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Journal : MonoBehaviour {
    [SerializeField] Text logText;
    [SerializeField] GameObject textboxobj;
    UI_TextController ui;
    public static Journal Instance { get; set;}
    public float textCooldown = 3f;
    float countdown;
	// Use this for initialization
	void Start () {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;

        ui = textboxobj.GetComponent<UI_TextController>();
        if (ui == null)
        {
            Debug.Log("Ei löytynyt");
        }
        else
            ToggleImageBox(false);

        countdown = textCooldown;
	}

    private void Update()
    {       
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                logText.text = "";
                //ToggleImageBox(false);
            }
    }

    public void Log(string text)
    {
        logText.text = text;
        countdown = textCooldown;
        //ToggleImageBox(true);
        //logText.text += "\n" + text;
    }

    public void ToggleImageBox(bool toggle)
    {
        if (toggle)
        {
            ui.ToggleOn(true);
        }
        else
        {
            ui.ToggleOn(false);
        }
            
    }
}
