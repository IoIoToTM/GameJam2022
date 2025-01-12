using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{

    private float startPosX, startPosY;
    private bool isBeingHeld = false;



    // Update is called once per frame
    void Update()
    {
       if(isBeingHeld)
        {
            Vector3 mousePo;
            mousePo = Input.mousePosition;

            mousePo = Camera.main.ScreenToWorldPoint(mousePo);

            gameObject.transform.localPosition = new Vector3(mousePo.x - startPosX, mousePo.y - startPosY, transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {

        if(Input.GetMouseButtonDown(0))
        {


            if(gameObject.name == "Glass")
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<BoxCollider2D>().isTrigger = true;
            }
            Vector3 mousePo;
            mousePo = Input.mousePosition;

            mousePo = Camera.main.ScreenToWorldPoint(mousePo);

            startPosX = mousePo.x - transform.localPosition.x;
            startPosY = mousePo.y - transform.localPosition.y;


            isBeingHeld = true;
        }

    }


    private void OnMouseUp()
    {
        isBeingHeld = false;
    }

}
