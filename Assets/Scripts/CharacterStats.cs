using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public int mana;
    public int maxMana;

    public int stamina;
    public int maxStamina;

    public int damageB;
    public int damage;
    public float attackSpeed;

    public bool isDead = false;

    void showFloatingText(GameObject FloatingTextPrefab)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = damage.ToString();
        
        Destroy(go, 2);
    }

    public void TakeDamage(int damge, GameObject FloatingTextPrefab)
    {
        health -= damage;
        CheckHealth();

        if (FloatingTextPrefab)
        {
            showFloatingText(FloatingTextPrefab);
        }
    }

/*
    public void TakeDamageEnemy(int damge, GameObject FloatingTextPrefab)
    {
        health -= damage;
        CheckHealth();

        if (FloatingTextPrefab)
        {
            showFloatingText(FloatingTextPrefab);
        }
    }*/


    public void TakeDamageB(int damageB, GameObject FloatingTextPrefab)
    {
        health -= damageB;
        CheckHealth();

        if (FloatingTextPrefab)
        {
            showFloatingText(FloatingTextPrefab);
        }
    }
    public virtual void Die()
    {

    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;

            Die();
        }
        if (health >= maxHealth)
            health = maxHealth;
    }
    
    public void Mana()
    {
        if (mana <= 0)
            mana = 0;
        if (mana >= maxMana)
            mana = maxMana;
    }

    public void CheckStamina()
    {
        if (stamina <= 0)
            stamina = 0;
        if (stamina >= maxStamina)
            health = maxStamina;
    }

}
