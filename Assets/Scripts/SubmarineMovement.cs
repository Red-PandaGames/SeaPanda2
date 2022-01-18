using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    public int speed;

    public static bool isOn;
    public bool PlayerCanEnter;
    public bool PlayerInside;

    public Transform target;
    public GameObject joueur;

    private void Start()
    {
        isOn = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOn = !isOn;
        }
        if(PlayerCanEnter && Input.GetKeyDown(KeyCode.E))
        {
            InAndOutSumbamrine();
        }
        if (isOn)
        {
            MoveSubmarine();
        }
        if (PlayerInside)
        {
            joueur.GetComponent<Transform>().position = transform.position;
        }
    }

    private void MoveSubmarine()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCanEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCanEnter = false;
        }
    }

    private void InAndOutSumbamrine()
    {
        PlayerInside = !PlayerInside;
        joueur.GetComponent<SpriteRenderer>().enabled = !joueur.GetComponent<SpriteRenderer>().enabled;
    }
}
