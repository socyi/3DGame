using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonHealthBar : MonoBehaviour
{
    public Text hpValueTextDragon;
    public Image hpFillValueDragon;

    CharacterStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<EnemyStatsDragon>();
    }

    // Update is called once per frame
    void Update() 
    {
        if ((float)playerStats.health > 0)
        {
            hpValueTextDragon.text = playerStats.health.ToString();
            float fillValue = playerStats.health / (float)playerStats.health;
            hpFillValueDragon.rectTransform.localScale = new Vector3(fillValue, 1, 1);
           
        }
        else 
        {
            // DO SOMETHING - WIN GAME
            print("b");
            hpValueTextDragon.text = playerStats.health.ToString();
            hpFillValueDragon.rectTransform.localScale = new Vector3(0, 1, 1);
        }
       }
}
