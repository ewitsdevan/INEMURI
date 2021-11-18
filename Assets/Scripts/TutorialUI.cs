using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialUI : MonoBehaviour
{
    public void PlayButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenuClick()
    {
        SceneManager.LoadScene(1);
    }
}
