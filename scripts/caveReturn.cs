using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class caveReturn : MonoBehaviour
{
    public GameObject image;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        

        if (col.name == "Player") {
            
            Debug.Log("CameraSwitching");
            image.SetActive(true);
            text.text = "Go back to surface?(Z/X)";
            //Time.timeScale = 0;
            SwitchCamera.returnSurfaceRequest = true;
            Time.timeScale = 0;
        }
        
    }
}
