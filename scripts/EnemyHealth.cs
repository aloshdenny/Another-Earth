using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static float attacked = 0;
    public Slider slider;
    public GameObject SliderObj;
    public static float range;
    public float MaxHealth = 10;
    public GameObject player;
    float health;
    bool check=false;
    bool resetHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameObject.name == "Boss") {
            MaxHealth -= MaxHealth / 2-1;
        }*/
        if (playerHealth.playerDead)
        {
            resetHealth = true;
        }
        if (resetHealth)
        {
            health = MaxHealth;
            resetHealth= false;
        }
        slider.value = health;
        if (!check && attacked > 0)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance <= range)
            {
                health -= attacked;
                check = true;
            }
            if (health<=0) {
                if (gameObject.name == "LavaDemon")
                {
                    LavaDemonMove.dead = true;
                    LavaDoorPuzzle.LavaBossDead = true;
                }
                else if (gameObject.name == "FrostGuardian")
                {
                    FrostDemonMove.dead = true;
                }
                else if (gameObject.name == "FrostGuardian (1)")
                {
                    FrostDemonMove1.dead = true;
                }
                else if (gameObject.name == "Boss") { 
                    BossMove.dead = true;
                }
                SliderObj.SetActive(false);
            }
        }
        else if (attacked == 0) {
            check = false;
        }
    }
    
}
