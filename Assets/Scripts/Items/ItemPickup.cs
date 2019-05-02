using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    private bool skip = false;
    private bool promptFinished = false;

    private int counter = 0;

    public GameObject pickupPrefab;
    public Item item;
    public Font font;

    public override void Interact()
    {
        base.Interact();

        StartCoroutine("Pickup");
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetButtonDown("Interact") && counter > 2)
        {
            skip = true;
        }

        if (Input.GetButtonDown("Interact") && promptFinished)
        {
            Inventory.instance.Add(item);
            Destroy(gameObject);
            UnfreezePlayer();
        }
    }

    //void Pickup()
    //{
    //    Debug.Log("Picking up " + item.name);
    //    Inventory.instance.Add(item);
    //    Destroy(gameObject);
    //}

    IEnumerator Pickup()
    {
        FreezePlayer();

        Vector2 whereToInstantiate = new Vector2(transform.position.x, transform.position.y + 0.5f);
        GameObject popup = Instantiate(pickupPrefab, transform);

        popup.transform.position = whereToInstantiate;

        TextMeshProUGUI[] textMesh = popup.GetComponentsInChildren<TextMeshProUGUI>();

        textMesh[0].text = item.name.ToUpper();
        textMesh[0].color = item.getRarityColour();

        textMesh[1].text = "";

        counter = 0;

        while(counter < item.description.Length && !skip)
        {
            textMesh[1].text = textMesh[1].text + item.description[counter];
            counter++;
            yield return new WaitForSeconds(0.05f);
        }
        textMesh[1].text = item.description;
        skip = false;
        promptFinished = true;

        yield return null;
    }

}
