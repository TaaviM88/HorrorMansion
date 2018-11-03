using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemTypes.ItemTypes itemType = ItemTypes.ItemTypes.none;
    public static Item Instance { get; set; }

    public int id;
    public Sprite itemsUISprite;
    public string name;
    public string description;

    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string name, string description, Sprite itemSprite, Dictionary<string, int> stats)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.stats = stats;
        this.itemsUISprite = itemSprite;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.stats = item.stats;
        this.itemsUISprite = item.itemsUISprite;
    }
}
