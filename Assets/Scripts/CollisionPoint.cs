using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPoint : MonoBehaviour
{
    GameManager gm;
    [SerializeField]
    GameObject menu;
    PlayerController head;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        head = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            head.Pause();
            menu.SetActive(true);
        }
    }
}
