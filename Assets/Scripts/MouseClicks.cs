using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;




public class MouseClicks : MonoBehaviour
{


    public Vector2 mouseStartPosition;
    public Vector2 currentMouse;
    public bool clicked = false;

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();


    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }


    // Start is called before the first frame update
    void Start()
    {
        //RECT rect;
        //GetWindowRect(GetActiveWindow(), out rect);

        //TransparentWindow.windowRectangle.x = rect.Left;
        //TransparentWindow.windowRectangle.y = rect.Top;

        ////var worldPos = Camera.main.ScreenToWorldPoint(new Vector2(rect.Left,rect.Top));
        ////TransparentWindow.windowRectangle.x = worldPos.x;
        ////TransparentWindow.windowRectangle.y = worldPos.y;

        //Debug.LogError(TransparentWindow.windowRectangle);
       
        //var newPos = Camera.main.ScreenToWorldPoint(new Vector3(TransparentWindow.windowRectangle.x, TransparentWindow.windowRectangle.y));
        //var newScale = Camera.main.ScreenToWorldPoint(new Vector3(TransparentWindow.windowRectangle.width, TransparentWindow.windowRectangle.height));

        //newPos.z = -5;
        //transform.position = newPos;

        //Debug.LogError("WINDOW3 = " + newPos + " \nWINDOW RECT3 " + TransparentWindow.windowRectangle);

        //Debug.LogError("MOUSE = " + TransparentWindow.windowRectangle);
    }

    public static void strechBetween(GameObject sr, Vector2 point1, Vector2 point2)
    {
        float spriteSizex = sr.GetComponent<SpriteRenderer>().sprite.rect.width / sr.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        float spriteSizey = sr.GetComponent<SpriteRenderer>().sprite.rect.height / sr.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

        Vector3 scale = sr.transform.localScale;
        scale.x = (point1.x - point2.x) / spriteSizex;
        scale.y = (point1.y - point2.y) / spriteSizey;
        sr.transform.localScale = scale;
    }




    // Update is called once per frame
    void Update()
    {

        if (TransparentWindow.isStretching == true) return;

        if (clicked)
        {
            Vector2 currentMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var newPos = currentMouse - mouseStartPosition;
            var newnewPos = (newPos);
            //newnewPos.z = -4;

            //Debug.Log(newnewPos);
            currentMouse = newnewPos;

            newnewPos = Camera.main.WorldToScreenPoint(newnewPos);
            //transform.position = newnewPos;
            TransparentWindow.windowRectangle.x = newnewPos.x;
            TransparentWindow.windowRectangle.y = newnewPos.y;

        }


        {


            //var uiSettings = new UISettings();
            //var accentColor = uiSettings.GetColorValue(UIColorType.Accent);

            var newPos = Camera.main.ScreenToWorldPoint(new Vector3(TransparentWindow.windowRectangle.x, TransparentWindow.windowRectangle.y));
            var newScale = Camera.main.ScreenToWorldPoint(new Vector3(TransparentWindow.windowRectangle.x + TransparentWindow.windowRectangle.width,
                TransparentWindow.windowRectangle.y + TransparentWindow.windowRectangle.height));


            newPos.z = -3;
            transform.position = newPos;

            // Debug.LogError("POSITION= " + transform.position + " POSITION NOEMAL = "+ new Vector3(TransparentWindow.windowRectangle.x, TransparentWindow.windowRectangle.y));

            //strechBetween(gameObject, newPos, newScale);
        }
    }

    public void clickedUp()
    {
        clicked = false;
    }
    public void clickedDown()
    {

        //var sp = GetComponent<SpriteRenderer>();

        //Rect r = new Rect(sp.sprite., 0, 0, 0);
        clicked = true;
        Vector2 mouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log(transform.position);

        mouseStartPosition = mouseToWorld - new Vector2(transform.position.x, transform.position.y)  ;

        //mouseStartPosition = new Vector2(transform.position.x + (sp.sprite.rect.width/2.0f) / sp.sprite.pixelsPerUnit, transform.position.y + (sp.sprite.rect.height/2.0f)/sp.sprite.pixelsPerUnit) - mouseToWorld;
    }
}
