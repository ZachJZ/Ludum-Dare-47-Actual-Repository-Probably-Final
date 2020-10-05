using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CurtainMaster : MonoBehaviour
{

    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadDND()
    {
        SceneManager.LoadScene("DNDScene");
    }
    public void LoadLD()
    {
        SceneManager.LoadScene("LDScene");
    }
    public void LoadPunk()
    {
        SceneManager.LoadScene("PunkScene");
    }
    public void LoadLoss()
    {
        SceneManager.LoadScene("LossScene");
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
