using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookToMouse : MonoBehaviour
{
    Transform player;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        RaycastHit hit;
        Ray mousePos = mainCam.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(mousePos, out hit, 100f))
        {
            Vector3 playerLookAtPos = new Vector3(hit.point.x, player.position.y, hit.point.z);
            player.LookAt(playerLookAtPos);
        }
    }
}
