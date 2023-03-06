using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatsDragon : CharacterStats
{
    public Text victoryText;
    public GameObject Particles;
    public GameObject ColorRandomizer;
    public GameObject HP1;



    // Start is called before the first frame update
    void Start()
    {
        
        health = 500;
        maxHealth = 500;

        damage = 20;

        attackSpeed = 2f;
    }

    public override void Die()
    {
        Destroy (gameObject, 0f);
        victoryText.text = "Victory!!!";
        Particles.SetActive(true);
        ColorRandomizer.SetActive(true);
        HP1.SetActive(true);
    }
   
}
