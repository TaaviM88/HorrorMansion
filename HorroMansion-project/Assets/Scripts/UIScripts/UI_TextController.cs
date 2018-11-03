using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TextController : MonoBehaviour {

    Image textboxImage;
    Color textboxcolor;
    // Use this for initialization
    void Awake ()
    {
        textboxcolor = Color.white;
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
            textboxcolor = textboxImage.color;
            textboxcolor.a = 0.125f;
            textboxImage.color = textboxcolor;
        }
        else
        {
            if(textboxcolor == null)
            {
                Debug.Log("Mitähän vittua");
            }
            else
            {
                textboxcolor = textboxImage.color;
                textboxcolor.a = 0f;
                textboxImage.color = textboxcolor;
            }
            
        }
    }
}
