using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSctipt : MonoBehaviour
{
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
       

        if(collision.name== "ButtonPressableNew")
        {
            var buttonBase = GameObject.Find("ButtonBaseNew");
            var buttonPressabe = GameObject.Find("ButtonPressableNew");

            buttonBase.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            buttonPressabe.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            buttonBase.GetComponent<Rigidbody2D>().isKinematic = false;
            
        }
    }
}
