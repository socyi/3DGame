using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Text hpValueText;
    public Image hpFillValue;

    CharacterStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update() 
    {
        if ((float)playerStats.health > 0)
        {
            hpValueText.text = playerStats.health.ToString();
            float fillValue = playerStats.health / (float)playerStats.health;
            hpFillValue.rectTransform.localScale = new Vector3(fillValue, 1, 1);
        }
        else if ((float)playerStats.health == 0)
        {
            hpValueText.text = playerStats.health.ToString();
            hpFillValue.rectTransform.localScale = new Vector3(0, 1, 1);
        }
       }
}
