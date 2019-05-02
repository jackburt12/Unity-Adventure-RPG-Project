using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Animator animator;
    public Image icon;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem ()
    {
        if(item!=null)
        {
            item.Use();
        }
    }

    public void OnHover()
    {
        Debug.Log("Hovered");
        animator.SetBool("selected", true);
    }



    public void OnHoverLeave()
    {
        Debug.Log("Not Hovered");
        animator.SetBool("selected", false);
    }


}
