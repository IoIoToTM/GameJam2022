using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public bool playerIsInside = true;
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
        if(collision.name=="Player")
        {
            playerIsInside = !playerIsInside;
            PlayerController.teleportObject(GameObject.Find("PlayerAround"),playerIsInside);
           
        }
    }
}
