using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name;
    public Sprite icon;
    [TextArea]
    public string description;
    public ItemType type;
    public Rarity rarity;
    public int value;


    //public Item(string name, string description, ItemType type, Rarity rarity, int value)
    //{
    //    this.name = name;
    //    this.description = description;
    //    this.type = type;
    //    this.rarity = rarity;
    //    this.value = value;
    //}

    //public string Name { get; set; }
    //public string Description { get; set; }
    //public ItemType Type { get; set; }
    //public Rarity Rarity { get; set; }
    //public int Value { get; set; }

    public virtual void Use()
    {
        //To be overwritten
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public Color getRarityColour()
    {
        Color c;
        switch (rarity)
        {
            case Rarity.Common:
                c = new Color(1, 1, 1, 1);
                break;
            case Rarity.Uncommon:
                c = new Color(0.25f, 1, 0.25f, 1);
                break;
            case Rarity.Rare:
                c = new Color(0.45f, 0.5f, 1, 1);
                break;
            case Rarity.Epic:
                c = new Color(0.75f, 0.4f, 1f, 1);
                break;
            case Rarity.Legendary:
                c = new Color(0.9f, 0.6f, 0.1f, 1);
                break;
            default:
                c = new Color(1, 1, 1, 1);
                break;


        }
        return c;
    }
}
