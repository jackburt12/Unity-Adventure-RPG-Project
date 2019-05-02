using System.Collections;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 0.2f;

    public CircleCollider2D circleCollider;

    public GameObject textPrompt;

    public bool nearby = false;

    public bool hasInteracted = false;

    public PlayerMovement player;

    public virtual void Interact()
    {
        //to be overwritten
    }

    public virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = radius;
        circleCollider.isTrigger = true;

        if(textPrompt!=null)
        {
            SetTextPrompt();
            textPrompt.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
        }

        hasInteracted = false;
    }

    public virtual void Update()
    {

        if (nearby && !hasInteracted)
        {
            if (Input.GetButtonDown("Interact"))
            {
                hasInteracted = true;
                if(textPrompt!=null)
                {
                    textPrompt.SetActive(false);
                }
                Interact();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        nearby = true;
        if (textPrompt != null)
        {
            StartCoroutine("TextFadeIn");
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        nearby = false;
        if (textPrompt != null)
        {
            StartCoroutine("TextFadeOut");
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void SetTextPrompt()
    {
        textPrompt.GetComponent<TextMesh>().text = "Press " + "temp" +" to interact";
    }

    public void FreezePlayer()
    {
        player.frozen = true;
    }

    public void UnfreezePlayer()
    {
        player.frozen = false;
    }

    IEnumerator TextFadeIn()
    {
        Debug.Log("FadeIn");

        for (float f = 0.0f; f <= 1f; f += 0.05f)
        {
            Color c = new Color(1, 1, 1, 1);
            c.a = f;
            textPrompt.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
    }

    IEnumerator TextFadeOut()
    {
        Debug.Log("FadeOut");

        for (float f = 1f; f >= 0f; f -= 0.02f)
        {
            Color c = new Color(1, 1, 1, 1);
            c.a = f;
            textPrompt.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
    }
}
