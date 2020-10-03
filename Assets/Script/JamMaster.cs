using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamMaster : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float masterVolume = 1.0f;

    public AudioClip[] Songs;
    public AudioClip[] Effects;

    public AudioSource sMaster;
    public AudioSource sSFX;

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = masterVolume;

        if (Input.GetKeyDown(KeyCode.O))
        {
            PlaySound(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlaySound(1);
        } 
    }

    //Songlist:
         /*1
         * 2
         * 3
         * 
         */
         
    public void StartSong(int songNum)
    {
        sMaster.clip = Songs[songNum];
        sMaster.Play(0);
    }

    //Effectlist:
         /*1
         * 2
         * 3
         * 
         */

    public void PlaySound(int thisSFX)
    {
        sSFX.clip = Effects[thisSFX];
        sSFX.Play(0); 
    }

    public void SetVolume(float setTo)
    {
        //idk if this is necessary
    }


}
