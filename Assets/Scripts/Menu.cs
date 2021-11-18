using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayButtonClick()
    {
        SceneManager.LoadScene(6);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void YesButtonClick()
    {
        SceneManager.LoadScene(5);
    }

    public void NoButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    public void BackButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
