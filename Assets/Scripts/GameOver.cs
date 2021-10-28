using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void TryAgainClick()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
