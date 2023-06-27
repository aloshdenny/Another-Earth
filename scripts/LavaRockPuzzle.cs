using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRockPuzzle : MonoBehaviour
{
    public GameObject rock1,rock2,col1,col2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (gameObject.name == "collide1" && collision.name == "Rock1")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            rock1.SetActive(false);
            col1.SetActive(false);
            print("part1");
        }
        if (gameObject.name == "collide2" && collision.name == "Rock2")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder= 1;
            rock2.SetActive(false);
            col2.SetActive(false);
        }
    }
}
