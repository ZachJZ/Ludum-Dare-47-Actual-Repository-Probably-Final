using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamMaster : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float masterVolume;

    public AudioClip[] Songs;
    public AudioClip[] Effects;

    public AudioSource sMaster;
    public AudioSource sSFX;

    // Update is called once per frame
    void Update()
    {
        //AudioListener.volume = masterVolume;

        sMaster.volume = masterVolume;
        sSFX.volume = masterVolume;

        if (Input.GetKeyDown(KeyCode.U))
        {
            StartSong(1);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            StartSong(2);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartSong(3);
        }
    }

    //Songlist:
    /*0Mundane
    * 1dnd
    * 2chip
    * 3techno
    */

    public void setLoopOff()
    {
        sMaster.loop = false;
    }

    public void StartSong(int songNum)
    {
        sMaster.clip = Songs[songNum];
        sMaster.Play(0);
        
    }

    public void StopSong()
    {
        sMaster.Stop();
    }

    //Effectlist:
         /*0disappointment
         * 1pong
         * 2exclamation
         * 3ding
         */

    public void PlaySound(int thisSFX)
    {
        sSFX.clip = Effects[thisSFX];
        sSFX.Play(0); 
    }

    public void SetVolume(float setTo)
    {
        //idk if this is necessary
        masterVolume = setTo;
        //sMaster.volume = Mathf.Clamp(setTo, 0, 1);
        //sSFX.volume = Mathf.Clamp(setTo, 0, 1);
    }


}
