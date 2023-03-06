using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public Text deathText;
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        maxHealth = 200;

   

        stamina = 100;
        maxStamina = 100;
        
        damage = 10;
        damageB = 20;
        attackSpeed = 1f;
    }

    // Update is called once per frame
    public override void Die()
    {
        ArthurController movScript = GetComponent<ArthurController>();
        movScript.StartCoroutine(Death(movScript.anim));
        movScript.enabled = false;
        deathText.text = "Defeat!!!";
    }
    public IEnumerator Death(Animator anim)
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Death Layer"), 1);
        anim.SetTrigger("Death");

        yield return new WaitForSeconds(2f);
       
    }
}
