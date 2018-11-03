using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {
    private Text toolTipText;
    // Use this for initialization
    void Start () {
        toolTipText = GetComponentInChildren<Text>();
        if(toolTipText == null)
        {
            Debug.Log(toolTipText + " Ei löydy, korjaa tää kun ehdit. Tyhäm.");
            return;
        }
        gameObject.SetActive(false);
	}
	
    public void GenerateToolTip(Item item)
    {
        string statText = "";
        if(item.stats.Count > 0)
        {
            foreach(var stat in item.stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value + "\n";
            }
        }
        string toolTip = string.Format("<b>{0}</b>\n{1}\n\n <b>{2}</b>", item.name, item.description, statText);
        toolTipText.text = toolTip;
        gameObject.SetActive(true);
    }
}
