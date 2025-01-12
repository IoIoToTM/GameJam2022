using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{


    public GameObject firstDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static bool alreadyCLicked = false;
    private void OnMouseDown()
    {
        if(!alreadyCLicked)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().dropGlass();
            firstDialog.SetActive(true);
            Destroy(gameObject.transform.parent.gameObject);
        }
        
    }
}
