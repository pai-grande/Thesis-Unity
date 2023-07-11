using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadPanel(GameObject panelName)
    {
        panelName.SetActive(true);
    }

    public void DestroyPanel(GameObject panelName)
    {
        panelName.SetActive(false);
    }
}


