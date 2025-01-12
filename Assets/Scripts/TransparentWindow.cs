using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TransparentWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,int X, int Y, int cx, int cy, uint uFlags);

    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }


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

    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);


    const int GWL_EXSTYLE = -20;
    const uint WS_EX_LAYERED = 0x00080000;
    const uint WS_EX_TRANSPARENT = 0x00000020;
    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

    IntPtr gameWindow;
    public static Rect windowRectangle;

    public Rect windowRectEditor;


    public static bool windowFacingForward = true;
    RPGTalk talk;

    public void makeTransparent()
    {
#if !UNITY_EDITOR
       

       

        MARGINS margins = new MARGINS { cxLeftWidth = -1 };
      
        DwmExtendFrameIntoClientArea(gameWindow, ref margins);
        SetWindowLong(gameWindow, GWL_EXSTYLE, WS_EX_LAYERED/* | WS_EX_TRANSPARENT*/);

        SetWindowPos(gameWindow, HWND_TOPMOST, 0, 0, 0, 0, 0);

        //Screen.fullScreen = true;
      

#endif
    }

    private void Start()
    {
        talk = GameObject.Find("Text Character").GetComponent<RPGTalk>();
        //windowRectangle.x = Screen.width/2;
        //windowRectangle.y = Screen.height/2;
        //windowRectangle.width = Screen.width;
        //windowRectangle.height = Screen.height;

        //MouseClicks.strechBetween(GameObject.Find("Square"),
        //    Camera.main.ScreenToWorldPoint(new Vector2(windowRectangle.x + windowRectangle.width, windowRectangle.y + windowRectangle.height)),
        //    Camera.main.ScreenToWorldPoint(new Vector2(windowRectangle.x, windowRectangle.y)));

        StartCoroutine(startStretch(true));
        //GameObject sqr = GameObject.Find("Square");


        //windowRectangle.x = 1920 / 2;
        //windowRectangle.y = 1080 / 2;
        //windowRectangle.width = 1920;
        //windowRectangle.height = 1080;

        //Vector2 newBottomLeft = new Vector2(900, 500);
        //Vector2 newTopRight = new Vector2(newBottomLeft.x + 1280, newBottomLeft.y + 720);



        ////float width = test2.x - test.x;
        ////float height = test2.y - test.y;

        ////Vector2 size = Camera.main.ScreenToWorldPoint(new Vector2(width / 2.0f, height / 2.0f));

         

        //    Vector2 bottomLeft = new Vector2(windowRectangle.x, windowRectangle.y);
        //    Vector2 topRight = new Vector2(windowRectangle.x + windowRectangle.width, windowRectangle.y + windowRectangle.height);
        //    Vector2 test = Vector2.Lerp(bottomLeft, newBottomLeft, 0);
        //    Vector2 test2 = Vector2.Lerp(topRight, newTopRight, 0);





        //    MouseClicks.strechBetween(sqr, Camera.main.ScreenToWorldPoint(test2), Camera.main.ScreenToWorldPoint(test));

        //    Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector2());
        //    newPos.z = -3;
        //    sqr.transform.position = newPos;




            Debug.LogError("HELLO");

        //Screen.fullScreen = false;
#if !UNITY_EDITOR
        gameWindow = GetActiveWindow();

        RECT rect;
        GetWindowRect(gameWindow, out rect);

        windowRectangle.x = rect.Left;
        windowRectangle.y = 1080 - rect.Top;
        windowRectangle.width = rect.Right - rect.Left + 1;
        windowRectangle.height = rect.Bottom - rect.Top + 1;

#endif
        //GameObject sqr = GameObject.Find("Square");
        //var newPos = Camera.main.ScreenToWorldPoint(new Vector3(windowRectangle.x, windowRectangle.y));
        //var newScale = Camera.main.ScreenToWorldPoint(new Vector3(windowRectangle.width, windowRectangle.height));

        //newPos.z = -5;
        //sqr.transform.position = newPos;

        //Debug.LogError("WINDOW1 = " + newPos + " \nWINDOW RECT1 " + windowRectangle);

        //sqr.transform.localScale = new Vector3(windowRectangle.height/Camera.main.aspect, windowRectangle.width / Camera.main.aspect);


#if !UNITY_EDITOR
           // Screen.fullScreen = true;
#endif

    }

    public Vector3 newScale;


    public void quitApplication()
    {
        Application.Quit(0);
        //Screen.SetResolution(1280, 720, false);
    }
   

    //void DrawQuad(Rect position, Color color)
    //{
    //    Texture2D texture = new Texture2D(1, 1);
    //    texture.SetPixel(0, 0, color);
    //    texture.Apply();
    //    GUI.skin.box.normal.background = texture;
    //    GUI.Box(position, GUIContent.none);
    //}



    public bool firstUpdate = true;

    public IEnumerator startRotation(bool left)
    {
        GameObject wind = GameObject.Find("Window");


        for (int i = 0; i <= 181; i++)
        {
            if (left)
            {
                wind.transform.Rotate(Vector3.up, 1);

               
            }
            else
            {
                wind.transform.Rotate(Vector3.up, -1);
            }


            if(i == 90)
            {
                //var titleBar = GameObject.Find("TitleBar");
                //var closeButton = GameObject.Find("CloseButton");

              
                //var titleBarPos = titleBar.transform.localPosition;
                ////Debug.Log("TITLE BAR POS " + titleBarPos);

                //titleBarPos.z *= -1;
                //titleBar.transform.localPosition = titleBarPos;

                ////Debug.Log("TITLE BAR POS AFTER" + titleBarPos);

                //var closeButtonPos = closeButton.transform.localPosition;
                //closeButtonPos.z *= -1;
                //closeButton.transform.localPosition = closeButtonPos;

                windowFacingForward = !windowFacingForward;

            }

            
            yield return new WaitForSeconds(0.01f);
        }

       

        //Debug.Log(wind.transform.rotation.eulerAngles);
        yield return null;
    }

    private void Update()
    {

        windowRectEditor = windowRectangle;
        if(Input.GetKeyDown(KeyCode.K))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {

            //StartCoroutine(startRotation(true));
            // Screen.fullScreen = false;

           // Screen.SetResolution(1280, 720, false);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            //Screen.SetResolution(1280, 720, false);
            Application.Quit(0);
        }

        if(Input.GetKey(KeyCode.O))
        {
           // var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //GameObject wind = GameObject.Find("Window");

            //wind.transform.LookAt(mousePos, Vector3.up);


            //Vector3 targetPostition = new Vector3(mousePos.x*2,
            //                           this.transform.position.y,
            //                           -3);
            ////wind.transform.LookAt(targetPostition);

            //var lookPos = targetPostition - wind.transform.position;
            //lookPos.y = 0;
            //var rotation = Quaternion.LookRotation(lookPos);
            //wind.transform.rotation = rotation;

            //wind.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*4, 0));

        }

        if(firstUpdate || Input.GetKeyDown(KeyCode.B))
        {

            //GameObject sqr = GameObject.Find("Square");
            //var newPos = Camera.main.ScreenToWorldPoint(new Vector3(windowRectangle.x, windowRectangle.y));
            //var newScale = Camera.main.ScreenToWorldPoint(new Vector3(windowRectangle.width, windowRectangle.height));

            //newPos.z = -5;
            //sqr.transform.position = newPos;

            //Debug.LogError("WINDOW2 = " + newPos +" \nWINDOW RECT2 "+windowRectangle);

           // StartCoroutine(startStretch());

            firstUpdate = false;
        }
       

        //var spriteRenderer = sqr.GetComponent<SpriteRenderer>();
        ////Debug.Log("SPRITE SIZE = " + spriteRenderer.bounds.size.x);


        //newScale = new Vector3(1920 / windowRectangle.width, 1080 / windowRectangle.height);
        //sqr.transform.localScale = newScale;

        //var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("SPRITE SIZE = " + spriteRenderer.bounds.center.x + "NORMAL " + Input.mousePosition + " NEW " + mousePos);
        //spriteRenderer.se = newScale;
        //sqr.transform.localScale = new Vector3(windowRectangle.height / Camera.main.aspect, windowRectangle.width / Camera.main.aspect);

    }


    public void startMinimizing()
    {
        makeTransparent();
        StartCoroutine(startStretch(false));

      

    }

    public void startMaximizing()
    {
        StartCoroutine(startStretch2());
    }

    public static bool isStretching = false;

    IEnumerator startStretch2()
    {
        //isStretching = true;
        GameObject sqr = GameObject.Find("Square");


        //windowRectangle.x = 1920 / 2;
        //windowRectangle.y = 1080 / 2;
        //windowRectangle.width = 1920;
        //windowRectangle.height = 1080;

        Debug.Log("MAZIMIZING");

        Vector2 newBottomLeft = new Vector2(0, 0);
        Vector2 newTopRight = new Vector2(1920, 1080);



        //float width = test2.x - test.x;
        //float height = test2.y - test.y;

        //Vector2 size = Camera.main.ScreenToWorldPoint(new Vector2(width / 2.0f, height / 2.0f));

        for (float i = 0; i < 1; i += 0.01f)
        {
            // var val = 1.0f / i;

            Vector2 bottomLeft = new Vector2(windowRectangle.x, windowRectangle.y);
            Vector2 topRight = new Vector2(windowRectangle.x + windowRectangle.width, windowRectangle.y + windowRectangle.height);
            Vector2 test = Vector2.Lerp(bottomLeft, newBottomLeft, i);
            Vector2 test2 = Vector2.Lerp(topRight, newTopRight, i);

            //if (firstStretch)
            //{
            //    MouseClicks.strechBetween(sqr, Camera.main.ScreenToWorldPoint(test2), Camera.main.ScreenToWorldPoint(test));

            //    Vector3 newPos1 = Camera.main.ScreenToWorldPoint(test);
            //    newPos1.z = -3;
            //    sqr.transform.position = newPos1;
            //    yield break;
            //}


            test.x += UnityEngine.Random.Range(-4.0f, 2.0f);
            test.y += UnityEngine.Random.Range(-2.0f, 4.0f);

            test2.x += UnityEngine.Random.Range(-2.0f, 3.0f);
            test2.y += UnityEngine.Random.Range(-5.0f, 2.0f);

            //test2 -= size;
            //test -= size;

            //Debug.Log("SIZE OS " + size);
            //Debug.Log(Camera.main.ScreenToWorldPoint(test) + " " + Camera.main.ScreenToWorldPoint(test2));

            MouseClicks.strechBetween(sqr, Camera.main.ScreenToWorldPoint(test2), Camera.main.ScreenToWorldPoint(test));

            Vector3 newPos = Camera.main.ScreenToWorldPoint(test);
            newPos.z = -3;
            sqr.transform.position = newPos;

            yield return new WaitForSeconds(0.01f);

        }
       





        MouseClicks.strechBetween(sqr, Camera.main.ScreenToWorldPoint(newTopRight), Camera.main.ScreenToWorldPoint(newBottomLeft));

        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas.enabled = false;

        isStretching = false;
        yield return null;
    }


    string currentScene = "2";

    public void nextText()
    {

        talk.enabled = true;
        talk.lineToStart = "2_start";
        talk.lineToBreak = "2_end";

        talk.PlayNext();
    }

    IEnumerator startStretch(bool firstStretch)
    {

        isStretching = true;
        GameObject sqr = GameObject.Find("Square");


        windowRectangle.x = 1920/2;
        windowRectangle.y = 1080/2;
        windowRectangle.width  = 1920;
        windowRectangle.height = 1080;

        Vector2 newBottomLeft = new Vector2(900, 500);
        Vector2 newTopRight = new Vector2(newBottomLeft.x+1280,newBottomLeft.y+720);



        //float width = test2.x - test.x;
        //float height = test2.y - test.y;

        //Vector2 size = Camera.main.ScreenToWorldPoint(new Vector2(width / 2.0f, height / 2.0f));

        for (float i = 0; i < 1; i += 0.01f) 
        {
           // var val = 1.0f / i;

            Vector2 bottomLeft = new Vector2(windowRectangle.x,windowRectangle.y);
            Vector2 topRight = new Vector2(windowRectangle.x + windowRectangle.width,windowRectangle.y + windowRectangle.height);
            Vector2 test = Vector2.Lerp(bottomLeft, newBottomLeft,i);
            Vector2 test2 = Vector2.Lerp(topRight, newTopRight, i);

            if(firstStretch)
            {
                MouseClicks.strechBetween(sqr, Camera.main.ScreenToWorldPoint(test2), Camera.main.ScreenToWorldPoint(test));

                Vector3 newPos1 = Camera.main.ScreenToWorldPoint(test);
                newPos1.z = -3;
                sqr.transform.position = newPos1;
                yield break;
            }
           

            test.x += UnityEngine.Random.Range(-4.0f, 2.0f);
            test.y += UnityEngine.Random.Range(-2.0f, 4.0f);

            test2.x += UnityEngine.Random.Range(-2.0f, 3.0f);
            test2.y += UnityEngine.Random.Range(-5.0f, 2.0f);

            //test2 -= size;
            //test -= size;

            //Debug.Log("SIZE OS " + size);
            //Debug.Log(Camera.main.ScreenToWorldPoint(test) + " " + Camera.main.ScreenToWorldPoint(test2));

            MouseClicks.strechBetween(sqr,Camera.main.ScreenToWorldPoint(test2), Camera.main.ScreenToWorldPoint(test));

            Vector3 newPos = Camera.main.ScreenToWorldPoint(test);
            newPos.z = -3;
            sqr.transform.position = newPos;

            yield return new WaitForSeconds(0.01f);

        }
        var button = GameObject.Find("Button");
        var buttonBase = GameObject.Find("ButtonBase");
        var buttonPressabe = GameObject.Find("ButtonPressable");

        buttonPressabe.GetComponent<SpringJoint2D>().enabled = false;
        buttonPressabe.GetComponent<BoxCollider2D>().enabled = false;
        buttonPressabe.GetComponent<Rigidbody2D>().isKinematic = true;
        buttonPressabe.transform.parent = buttonBase.transform;


        windowRectangle.x = newBottomLeft.x;
        windowRectangle.y = newBottomLeft.y;
        windowRectangle.width = 1280;
        windowRectangle.height = 720;


        Debug.LogError("BUTTon "+button.transform.position);
        PlayerController.teleportObject(button, false);
        Debug.LogError("BUTTON1 "+button.transform.position);


        var floor1 = GameObject.Find("FloorTeleported");

        PlayerController.teleportObject(floor1, false);
        floor1.GetComponentInChildren<BoxCollider2D>().isTrigger = true;

     
        

        MouseClicks.strechBetween(sqr, Camera.main.ScreenToWorldPoint(newTopRight), Camera.main.ScreenToWorldPoint(newBottomLeft));

        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas.enabled = true;

        Image img= GameObject.Find("TitleBar").GetComponent<Image>();
        img.enabled = true;
        Image img2 = GameObject.Find("CloseButton").GetComponent<Image>();
        img2.enabled = true;

        isStretching = false;
        yield return null;
    }
 

    


}
