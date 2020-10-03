using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{

    //object ref
    public GameObject TopDoor;
    public GameObject BottomDoor;

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

    bool doorOpen;
    float doorTimer;


    // Start is called before the first frame update
    void Start()
    {
        gaming = true; 

        if (pSpeed == 0)
        {
            pSpeed = 5;
        }

        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
        DoorReset();
    }

    void FixedUpdate()
    {

        myRB.MovePosition(myRB.position + movement * pSpeed * Time.fixedDeltaTime);

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        {
            //door
            if (col.gameObject.name == "Top Door" && doorOpen == true)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position = BottomDoor.transform.position;
                }
            }

            if (col.gameObject.name == "Bottom Door")
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position = TopDoor.transform.position;
                }
            }
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

    public void SetPlaying(bool gameOver)
    {
        gaming = gameOver;
    }

    void DoorReset()
    {
        doorTimer += Time.deltaTime;
        if (doorTimer > 2.0f)
        {
            doorOpen = true;
        }
        else
        {
            doorOpen = false;
        }
    }


}
