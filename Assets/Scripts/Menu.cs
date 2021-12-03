using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void YesButtonClick()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void NoButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
