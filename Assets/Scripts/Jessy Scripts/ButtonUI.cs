using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField]
    public string newGameLevel = "Level1";


    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);

    }

}
