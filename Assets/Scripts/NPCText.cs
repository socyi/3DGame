using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCText : MonoBehaviour
{
    public GameObject FloatingTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        if (gameObject.layer == 13) {

            if (gameObject.CompareTag("Stage1NPC1"))
            {
                go.GetComponent<TextMesh>().text = "Please kill the dragon and save our land!";
               

            }
            else if (gameObject.CompareTag("Stage1NPC2"))
            {
                go.GetComponent<TextMesh>().text = "Collect the treasure chests to get powerful abilities.";
               
            }
            else if (gameObject.CompareTag("Stage1NPC3"))
            {
                go.GetComponent<TextMesh>().text = "Good luck!!";
               
            }

            else if (gameObject.CompareTag("Stage1NPC4"))
            {
                go.GetComponent<TextMesh>().text = "Enter the forest to reach the castle. The dragon is lying there.";
               
            }
            else
            {
                go.GetComponent<TextMesh>().text = "It's very dangerous out there. Be careful!";
                
            }
            
        }
        else if(gameObject.layer == 10)
        {
            go.transform.localPosition = new Vector3(0, 10, 0);
            go.GetComponent<TextMesh>().text = "We are very hungry!";
        }
        else if (gameObject.layer == 14)
        {
            go.transform.localPosition = new Vector3(0, 10, 0);
            go.GetComponent<TextMesh>().text = "You are a dead man";
        }
        
    }

}
