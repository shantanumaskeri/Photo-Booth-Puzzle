using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSwitchScreen : MonoBehaviour
{

    public float timeToSwitch = 10.0f;
    public string nextScreen = "";

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("MoveToNextScreen", timeToSwitch);
    }

    private void MoveToNextScreen()
    {
        SceneManager.LoadScene(nextScreen);
    }

}
