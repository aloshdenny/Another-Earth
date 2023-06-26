using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VanishFromPlayer : MonoBehaviour
{
    public GameObject player;
    public float range = 5;
    float distance=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < range) {
            gameObject.SetActive(false);
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("detected");
        if (collision.name == "Player") { 
            gameObject.SetActive(false);
        }
    }
}
