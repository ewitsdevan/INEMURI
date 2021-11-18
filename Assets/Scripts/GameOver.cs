using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void TryAgainClick()
    {
        SceneManager.LoadScene(2);
    }

    public void MenuClick()
    {
        SceneManager.LoadScene(1);
    }
}
