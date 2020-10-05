using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HeroScript : MonoBehaviour
{

    //object ref
    public GameObject TopDoor;
    public GameObject BottomDoor;

    PlayerObjectInteraction myPOI;

    public Text punkText;
    public Text dndText;
    public Text jamText;
    public Text giveUpText;
    public GameObject JamWin;
    public GameObject PunkWin;
    public GameObject DNDWin;
    public GameObject iLost;
    public GameObject myHUD;
    //public Text myDayLog;
    public Animator myAnim;

    //movement var
    [SerializeField]
    int pSpeed;

    Vector2 movement;

    [SerializeField]
    Rigidbody2D myRB;

    //Day Start vars
    [SerializeField]
    GameObject startPos;

    //Pause menu var
    bool gaming;
    bool pausedGame;
    [SerializeField]
    public GameObject pauseMenu;

    bool atBottom;
    bool atTop;

    bool exitDoor;
    bool dayOver;

    bool winningJam;

    public GameObject endDayMenu;

    GameObject currentPickup;

    //myinteract is set in the ontrigger funtions as it's called
    interactSctipt myInteract;
    needKeysScript needKeys;
    FadingScript myFade;
    TimerScript myTimer;
    //need list script to keep track of things

    //Sound
    JamMaster myJam;
    CurtainMaster mySM;


    // Start is called before the first frame update
    void Start()
    {
        myPOI = FindObjectOfType<PlayerObjectInteraction>().GetComponent<PlayerObjectInteraction>();
        myFade = FindObjectOfType<FadingScript>();
        myTimer = FindObjectOfType<TimerScript>();
        needKeys = FindObjectOfType<needKeysScript>();
        myAnim = GetComponent<Animator>();
        myJam = FindObjectOfType<JamMaster>();
        myJam.setLoopOff();
        mySM = FindObjectOfType<CurtainMaster>();

        winningJam = false;
        gaming = true; 

        if (pSpeed == 0)
        {
            pSpeed = 15;
        }

        myRB = GetComponent<Rigidbody2D>();

        currentPickup = null;
        dayOver = false;

        iLost.SetActive(false);
        JamWin.SetActive(false);
        PunkWin.SetActive(false);
        DNDWin.SetActive(false);
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
                if (myPOI.hasKeys)
                {
                    dayOver = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            print("StartPos is " + startPos.transform.position);
            gameObject.transform.position = startPos.transform.position;
        }

        if (dayOver)
        {
            EndDay();
        }

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
                if (!myPOI.hasKeys)
                    needKeys.SetKeysText(true);

                exitDoor = true;
            }

            if (col.gameObject.name == "Interactable")
            {
                currentPickup = col.gameObject;
                myInteract = currentPickup.GetComponent<interactSctipt>();
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
            needKeys.SetKeysText(false);
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
        if (movement.x == 0)
        {
            myAnim.SetBool("doRun", false);
        }
        else if (movement.x > 0)
        {
            //go right
            print("Running right");
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            //GetComponent<SpriteRenderer>().flipX = true;
            myAnim.SetBool("doRun", true);

        }
        else if (movement.x < 0)
        {
            //go left
            print("Running left");
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            //GetComponent<SpriteRenderer>().flipX = true;
            myAnim.SetBool("doRun", true);

        }

    }

    void pickMeUp()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentPickup.GetComponent<keysItem>())
            {
                //add keys to list that day's list
                myPOI.IncrementItem("keys");
                //delete item
                currentPickup.gameObject.SetActive(false);
                //set currentpickup to null
                currentPickup = null;
                myJam.PlaySound(3);
            }
            else if (currentPickup.GetComponent<punkItem>())
            {
                //add keys to list that day's list
                myPOI.IncrementItem("punk");
                //delete item
                currentPickup.gameObject.SetActive(false);
                //set currentpickup to null
                currentPickup = null;
                myJam.PlaySound(1);

            }
            else if (currentPickup.GetComponent<dndItem>())
            {
                //add keys to list that day's list
                myPOI.IncrementItem("dnd");
                //delete item
                currentPickup.gameObject.SetActive(false);
                //set currentpickup to null
                currentPickup = null;
                myJam.PlaySound(1);

            }
            else if (currentPickup.GetComponent<jamItem>())
            {
                //add keys to list that day's list
                myPOI.IncrementItem("jam");
                //delete item
                currentPickup.gameObject.SetActive(false);
                //set currentpickup to null
                currentPickup = null;
                myJam.PlaySound(1);

            }
            else if (currentPickup.GetComponent<energyItem>())
            {
                //add keys to list that day's list
                myPOI.IncrementItem("energy");
                //delete item
                currentPickup.gameObject.SetActive(false);
                //set currentpickup to null
                currentPickup = null;
                myJam.PlaySound(3);


            }
            else if (currentPickup.GetComponent<junkItem>())
            {
                //add keys to list that day's list
                //myPOI.IncrementItem("energy");
                //delete item
                currentPickup.gameObject.SetActive(false);
                //set currentpickup to null
                currentPickup = null;
                myJam.PlaySound(0);
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

    public void NewDay()
    {
        dayOver = false;
        //player position
        gaming = true;
        //progress items
        endDayMenu.SetActive(false);
        //spawn/respawn items
        myPOI.ItemSpawning();
        //fade screen back in
        myFade.Fade2Clear();
        //timer back up
        myTimer.ResetDay();

        myJam.StartSong(0);
    }

    void EndDay()
    {
        if (!myPOI.hasEnergy || exitDoor == false)
        {
            myPOI.AddGiveUp();
        }

        myJam.StopSong();
        gaming = false;
        myTimer.StartTimer(false);
        myFade.Fade2Black();
        myPOI.ItemDespawn();
        myPOI.hasKeys = false;

        gameObject.transform.position = startPos.transform.position;

        if (myPOI.GetPunkProg() == 3)
        {
            mySM.LoadPunk();
            //myHUD.SetActive(false);
        }
        else if (myPOI.GetDNDProg() == 3)
        {
            mySM.LoadDND();
            //myHUD.SetActive(false);
        }
        else if (myPOI.GetJamProg() == 3)
        {
            mySM.LoadLD();
            //myHUD.SetActive(false);
        }

        else if (myPOI.GetGiveUpProg() == 5)
        {
            mySM.LoadLoss();
        }
        else
        {
            giveUpText.text = "Giving Up: " + myPOI.GetGiveUpProg() + "/5";
            punkText.text = "Concert: " + myPOI.GetPunkProg() + "/3";
            jamText.text = "Game Jam: " + myPOI.GetJamProg() + "/3";
            dndText.text = "D&D Night: " + myPOI.GetDNDProg() + "/3";
            endDayMenu.SetActive(true);
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

    public float SetVolume(float newVol)
    {
        return Mathf.Clamp(newVol, 0f, 1f);
    }




}
