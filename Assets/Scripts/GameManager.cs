using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [HideInInspector]
    public string UserName = "";
    [HideInInspector]
    public string UserEmail = "";
    [HideInInspector]
    public string UserPhotoPath = "";
    [HideInInspector]
    public string ImageToBase64 = "";

    private void Start()
    {
        Cursor.visible = false;
    }

}
