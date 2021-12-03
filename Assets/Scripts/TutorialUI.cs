using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialUI : MonoBehaviour
{
    public void PlayButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
