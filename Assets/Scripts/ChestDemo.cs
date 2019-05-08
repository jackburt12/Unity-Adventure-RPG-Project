using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour
{
    private Animator animator;

    public GameObject chestGlow;

    public int rarity = 0;

    private Color alphaColour;

    // Start is called before the first frame update
    public void Start()
    {
        if (chestGlow.GetComponentInChildren<Animator>() == null)
        {
            chestGlow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        }

        animator = GetComponent<Animator>();


    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Open", true);

            if (chestGlow.GetComponentInChildren<Animator>() != null)
            {
                chestGlow.GetComponent<Animator>().SetBool("open", true);
            } else
            {
                StartCoroutine("Glow", rarity);
            }



        }
    }

    IEnumerator Glow(int itemRarity)
    {

        Color c;

        switch (itemRarity)
        {
            case 0:
                c = new Color(1, 1, 1, 1);
                break;
            case 1:
                c = new Color(0.25f, 1, 0.25f, 1);
                break;
            case 2:
                c = new Color(0.45f, 0.5f, 1, 1);
                break;
            case 3:
                c = new Color(0.75f, 0.4f, 1f, 1);
                break;
            case 4:
                c = new Color(0.9f, 0.6f, 0.1f, 1);
                break;
            default:
                c = new Color(1, 1, 1, 1);
                break;


        }

        yield return new WaitForSeconds(1);


        for (float f = 0.0f; f <= 1f; f += 0.025f)
        {
            c.a = f;
            chestGlow.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        for (float f = 1f; f >= 0f; f -= 0.005f)
        {
            c.a = f;
            chestGlow.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
    }
}
