using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image spriteImage;
    private UIItem Selecteditem;
    //private ToolTip toolTip;

    // Use this for initialization
    void Awake ()
    {
        Selecteditem = GameObject.Find("Selected Item").GetComponent<UIItem>();
        if(Selecteditem == null)
        {
            return;
        }
        /*toolTip = GameObject.Find("ToolTip").GetComponent<ToolTip>();
        if(toolTip == null)
        {
            return;
        }*/
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
	}

    public void UpdateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.itemsUISprite;
            Debug.Log("Päivitettiin UI-esineen kuva");
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            if (Selecteditem.item != null)
            {
                Item clone = new Item(Selecteditem.item);
                Selecteditem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else
            {
                Selecteditem.UpdateItem(this.item);
                UpdateItem(null);
            }
        }
        else if (Selecteditem.item != null)
        {
            UpdateItem(Selecteditem.item);
            Selecteditem.UpdateItem(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {           
            //toolTip.GenerateToolTip(this.item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //toolTip.gameObject.SetActive(false);
    }
}
