using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualSwitchScreen : MonoBehaviour
{
    
    public void MoveToNextScreen(string nextScreen)
    {
        DontDestroyOnLoad(GameObject.Find("_MANAGER"));

        SceneManager.LoadScene(nextScreen);
    }

}
