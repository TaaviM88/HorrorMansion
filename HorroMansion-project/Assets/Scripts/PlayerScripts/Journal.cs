﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Journal : MonoBehaviour {
    [SerializeField] Text logText;
    public static Journal Instance { get; set;}

	// Use this for initialization
	void Start () {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;
	}
	
	public void Log(string text)
    {
        logText.text = text;
        //logText.text += "\n" + text;
    }
}