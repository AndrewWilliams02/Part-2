using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void loadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Checks current scene index
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings; //Finds next scene index
        SceneManager.LoadScene(nextSceneIndex); //Loads next scene
    }

    public void exitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Stops unity editor from running
    }
}
