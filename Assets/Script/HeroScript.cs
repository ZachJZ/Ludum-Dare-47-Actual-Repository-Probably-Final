using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{

    //object ref
    public GameObject TopDoor;
    public GameObject BottomDoor;

    PlayerObjectInteraction myPOI;

    //movement var
    [SerializeField]
    int pSpeed;

    Vector2 movement;

    [SerializeField]
    Rigidbody2D myRB;


    //Pause menu var
    bool gaming;
    bool pausedGame;

    [SerializeField]
    public GameObject pauseMenu;

    bool atBottom;
    bool atTop;

    bool exitDoor;
    bool dayOver;

    GameObject currentPickup;

    //myinteract is set in the ontrigger funtions as it's called
    interactSctipt myInteract;
    FadingScript myFade;
    TimerScript myTimer;
    //need list script to keep track of things


    // Start is called before the first frame update
    void Start()
    {
        myPOI = FindObjectOfType<PlayerObjectInteraction>().GetComponent<PlayerObjectInteraction>();
        myFade = FindObjectOfType<FadingScript>();
        myTimer = FindObjectOfType<TimerScript>();

        gaming = true; 

        if (pSpeed == 0)
        {
            pSpeed = 18;
        }

        myRB = GetComponent<Rigidbody2D>();

        currentPickup = null;
        dayOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (atTop)
            {
                transform.position = BottomDoor.transform.position;
                atTop = false;

            }
            else if (atBottom)
            {
                transform.position = TopDoor.transform.position;
                atBottom = false;
            }

            if (exitDoor)
            {
                dayOver = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            dayOver = true;
        }

        if (dayOver)
        {
            gaming = false;
            myTimer.StartTimer(false);
            myFade.Fade2Black();
        }

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    print("currentPickUp = " + currentPickup.name + "");
        //}

        Controls();

        if (currentPickup != null)
        {
            pickMeUp();
        }

        myRB.MovePosition(myRB.position + movement * pSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        {
            //door
            if (col.gameObject.name == "Top Door")
            {
                atTop = true;
            }

            else if(col.gameObject.name == "Bottom Door")
            {
                atBottom = true;
            }

            else if(col.gameObject.name == "Front Door")
            {
                exitDoor = true;
                //end day and log items
                //fade screen
                //post message
                //restart day
            }

            if (col.gameObject.name == "Interactable")
            {
                currentPickup = col.gameObject;
                myInteract = currentPickup.GetComponent<interactSctipt>();

                //display message
                myInteract.SetText(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Top Door")
        {
            atTop = false;
        }

        else if (col.gameObject.name == "Bottom Door")
        {
            atBottom = false;
        }

        else if (col.gameObject.name == "Front Door")
        {
            exitDoor = false;
            //end day and log items
            //fade screen
            //post message
            //restart day
        }

        if (col.gameObject.name == "Interactable")
        {
            myInteract.SetText(false);

            currentPickup = null;
            myInteract = null;
        }


    }

    void Controls()
    {
        //checks if you have game over or not
        if (gaming)
        {
       
            Movement();

            if (Input.GetKey(KeyCode.S))
            {
                //interact
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pausedGame = !pausedGame;
                PauseGame();
            }
        }
    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    void pickMeUp()
    {
        //check item
        //turn on text
        //press button > pick up item
        //remove text
        //add item to day's list
        //leave item
        //remove text

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentPickup.GetComponent<keysItem>())
            {
                //add keys to list that day's list
                print("got into the keys zone!");
                //currentPickup.GetComponent
                //set currentpickup to null
                //delete keys
            }
            else if (currentPickup.GetComponent<punkItem>())
            {
                print("Picked up!");
                myPOI.IncrementItem("punk");

                //delete skulltee
            }
            else if (currentPickup.GetComponent<dndItem>())
            {

            }
            else if (currentPickup.GetComponent<jamItem>())
            {

            }
            else if (currentPickup.GetComponent<energyItem>())
            {

            }
        }
    }

    public void PauseGame()
    {
        if (pausedGame)
        {
            //unpause
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            pausedGame = true;
        }
        else
        {
            //pause 
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            pausedGame = false;
        }
    }

    //SETTERS 

    public void SetPlaying(bool gameOver)
    {
        gaming = gameOver;
    }

    public void SetTimerDone()
    {
        dayOver = true;
    }

    public void ResetDay()
    {
        //timer back up
        //player position
        //progress items
        //respawn items

    }
}
