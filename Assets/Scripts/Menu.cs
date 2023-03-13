using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button play;
    public void playButton()
    {
        SceneManager.LoadScene(1);
    }

}
