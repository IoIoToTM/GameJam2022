using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    public Rigidbody2D rb;



    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }


    public static bool droppedGlass = false;

    public void dropGlass()
    {
        if (!droppedGlass)
        {
            droppedGlass = true;
            GameObject.Find("Glass").GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    public bool canMove = true;

    public void toggleMove()
    {
        canMove = !canMove;
        rb.velocity = Vector2.zero;
    }

    static bool jumpu = false;
    static bool teleported = false;
    private void Update()
    {

        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }
        if ((TransparentWindow.windowFacingForward && canMove)||(!TransparentWindow.windowFacingForward && teleported && canMove))
        {
            if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
            {
                if(teleported)
                rb.velocity = Vector2.up * jumpForce;
                else rb.velocity = Vector2.up * jumpForce;
            }

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            dropGlass();
        }

        //    if (Input.GetKeyDown(KeyCode.G))
        //{
        //    TransparentWindow tw = GameObject.Find("Main Camera").GetComponent<TransparentWindow>();
        //    tw.startMinimizing();
        //}

        if(Input.GetKeyDown(KeyCode.R))
        {
            TransparentWindow tw = GameObject.Find("Main Camera").GetComponent<TransparentWindow>();
            StartCoroutine(tw.startRotation(true));

            if(!teleported)
            rb.isKinematic = !rb.isKinematic;
            rb.velocity = Vector2.zero;

            Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            canvas.enabled = !canvas.enabled;
        }

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    teleportObject(GameObject.Find("PlayerAround"), jumpu);
        //    jumpu = !jumpu;
        //    ////////Camera secondCam = GameObject.Find("FrontCamera").GetComponent<Camera>();
        //    ////////var sqr = GameObject.Find("Square");

        //    //////////var posOnScreen = secondCam.WorldToScreenPoint(transform.position);

        //    ////////// Debug.Log(posOnScreen);
        //    //////////Camera.main.to
        //    //////////transform.position =  Camera.main.ScreenToWorldPoint(posOnScreen);

        //    ////////Vector2 windPos = Camera.main.ScreenToWorldPoint(new Vector2(TransparentWindow.windowRectangle.x, TransparentWindow.windowRectangle.y));
        //    ////////Vector2 windPos2 = Camera.main.ScreenToWorldPoint(new Vector2(TransparentWindow.windowRectangle.x+TransparentWindow.windowRectangle.width, 
        //    ////////    TransparentWindow.windowRectangle.y + TransparentWindow.windowRectangle.height));

        //    ////////Vector2 windScale = windPos / windPos2;

        //    //////////Debug.LogError(windPos  + " WINDOW REXR" + TransparentWindow.windowRectangle);

        //    ////////transform.position = new Vector3(transform.position.x + 100 + windPos.x, transform.position.y/2 + windPos.y, transform.position.z);
        //    ////////transform.localScale = new Vector3(0.32f, 0.32f, 1);

        //    ////////rb.velocity = Vector2.up * jumpForce;
        //    ////////rb.gravityScale = 1;
        //}
        //Debug.LogError(TransparentWindow.windowRectangle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        if ((TransparentWindow.windowFacingForward && canMove)||(!TransparentWindow.windowFacingForward && teleported && canMove))
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }


    }



    public static void teleportObject(GameObject obj, bool majorToMinor)
    {

        if (majorToMinor)
        {
            Vector2 windPos = Camera.main.ScreenToWorldPoint(new Vector2(TransparentWindow.windowRectangle.x, TransparentWindow.windowRectangle.y));


            Debug.LogError(windPos  + " WINDOW REXR" + TransparentWindow.windowRectangle);
            //Camera secondCam = GameObject.Find("FrontCamera").GetComponent<Camera>();
            obj.transform.position = new Vector3(obj.transform.position.x - 100 - windPos.x, obj.transform.position.y * 2 - windPos.y, obj.transform.position.z);
            obj.transform.localScale = new Vector3(1, 1, 1);


            var rb = obj.GetComponent<Rigidbody2D>();
            //rb.velocity = Vector2.up * 10;

            if (rb != null)
            {
                //rb.gravityScale = 2;
            }
        }
        else
        {
            Vector2 windPos = Camera.main.ScreenToWorldPoint(new Vector2(TransparentWindow.windowRectangle.x, TransparentWindow.windowRectangle.y));
            Debug.LogError(windPos + " WINDOW REXR" + TransparentWindow.windowRectangle);
            //Camera secondCam = GameObject.Find("FrontCamera").GetComponent<Camera>();
            //Debug.LogError(secondCam.transform.position);

            obj.transform.position = new Vector3(obj.transform.position.x + 100 + windPos.x, obj.transform.position.y / 2 + windPos.y, obj.transform.position.z);
            obj.transform.localScale = new Vector3(0.32f, 0.32f, 1);



            var rb = obj.GetComponent<Rigidbody2D>();

            if (rb != null)
            {


                rb.velocity = Vector2.up * 10;
                //rb.gravityScale = 1;
            }
            else if(obj.name!="PlayerAround")
            {
                rb = obj.AddComponent<Rigidbody2D>();

                var x = Random.Range(-1f, 1f);
                var y = Random.Range(0, 1f);
                var direction = new Vector3(x, y, 0f);
                //if you need the vector to have a specific length:
                direction = direction.normalized * 10;

                rb.velocity = direction;
            }
            if(obj.name=="PlayerAround")
            {
                teleported = true;
            }
        }

    }
}
