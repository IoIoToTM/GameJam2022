using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPhysics : MonoBehaviour
{

    public EventTrigger.TriggerEvent customCallback;
    public EventTrigger.TriggerEvent customCallback2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool isButtonEnabled = true;

    public void disableButton()
    {

        Debug.Log("DISABLED BUTTON");
        isButtonEnabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isButtonEnabled && collision.name == "Player")
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            eventData.selectedObject = this.gameObject;

            customCallback.Invoke(eventData);
            customCallback2.Invoke(eventData);
            isButtonEnabled = false;
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
