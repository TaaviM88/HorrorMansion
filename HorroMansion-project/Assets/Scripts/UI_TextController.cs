using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_TextController : MonoBehaviour {
    Image textboxImage;
    Color Textboxcolor;
    // Use this for initialization
    void Start () {
        textboxImage = gameObject.GetComponent<Image>();
        if (textboxImage == null)
        {
            Debug.Log("Lul ei löydy");
        }
        else
            ToggleOn(false);
    }
	
    //Journal säätelee tätä. Tyhmä systemi mutta toimii.
    public void ToggleOn(bool toggle)
    {
        if (toggle)
        {
            Textboxcolor = textboxImage.color;
            Textboxcolor.a = 0.25f;
            textboxImage.color = Textboxcolor;
        }
        else
        {
            Textboxcolor = textboxImage.color;
            Textboxcolor.a = 0f;
            textboxImage.color = Textboxcolor;
        }
    }
}
