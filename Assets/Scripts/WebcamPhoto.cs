using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using System.Text.RegularExpressions;

public class WebcamPhoto : MonoBehaviour
{
    
    public float timeLeft = 5.0f;
	public Text counter_text;
	public GameObject counter_block;
	public RawImage rawimage;

    WebCamTexture webcamTexture;
    int webcam_started = 0;
    private int gridSize = 4;
    private GameManager gameManager;
    private int playerCount;

    // Use this for initialization
    private void Start()
    {
        counter_text.text = ((int)timeLeft).ToString();

        webcam_started = 0;
        playerCount = PlayerPrefs.GetInt("playersPlayed");

        gameManager = GameObject.Find("_MANAGER").GetComponent<GameManager>();

        CreatePhotoDirectory();
        ActivateWebcam();
    }
	
	// Update is called once per frame
	private void Update()
    {
		timeLeft -= Time.deltaTime;
		 
	    if ((webcam_started == 1) && (Mathf.RoundToInt(timeLeft) >= 0))
        {
		 	counter_text.text = Mathf.RoundToInt(timeLeft)+"";	
		}

		if ((webcam_started == 1) && (Mathf.RoundToInt(timeLeft) < 0))
        {
            DeactivateWebcam();
		}
	}

    private void CreatePhotoDirectory()
    {
        if (gameManager.UserPhotoPath == null || gameManager.UserPhotoPath.Length == 0)
        {
            playerCount += 1;
            PlayerPrefs.SetInt("playersPlayed", playerCount);

            gameManager.UserPhotoPath = Application.dataPath;
            var stringPath = gameManager.UserPhotoPath + "/..";
            gameManager.UserPhotoPath = Path.GetFullPath(stringPath);
            gameManager.UserPhotoPath = gameManager.UserPhotoPath + "/Screenshots/User_" + playerCount;
            System.IO.Directory.CreateDirectory(gameManager.UserPhotoPath);
        }
    }

    private void ActivateWebcam()
    {
        webcam_started = 1;
        webcamTexture = new WebCamTexture();
        rawimage.texture = webcamTexture;
        webcamTexture.Play();
    }

    private void DeactivateWebcam()
    {
        counter_block.SetActive(false);
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
        snap.SetPixels(webcamTexture.GetPixels());
        snap.Apply();
        System.IO.File.WriteAllBytes(gameManager.UserPhotoPath + "/Selfie.png", snap.EncodeToPNG());
        gameManager.ImageToBase64 = System.Convert.ToBase64String(snap.EncodeToPNG());
        webcam_started = 0;
        webcamTexture.Stop();

        SplitImage(snap, webcamTexture.width/gridSize, webcamTexture.height/gridSize);
    }

    private void SplitImage(Texture2D image, int width, int height)
    {
        bool perfectWidth = image.width % width == 0;
        bool perfectHeight = image.height % height == 0;

        int lastWidth = width;
        if (!perfectWidth)
        {
            lastWidth = image.width - ((image.width / width) * width);
        }

        int lastHeight = height;
        if (!perfectHeight)
        {
            lastHeight = image.height - ((image.height / height) * height);
        }

        int widthPartsCount = image.width / width + (perfectWidth ? 0 : 1);
        int heightPartsCount = image.height / height + (perfectHeight ? 0 : 1);

        for (int i = 0; i < widthPartsCount; i++)
        {
            for (int j = 0; j < heightPartsCount; j++)
            {
                int tileWidth = i == widthPartsCount - 1 ? lastWidth : width;
                int tileHeight = j == heightPartsCount - 1 ? lastHeight : height;

                Texture2D g = new Texture2D(tileWidth, tileHeight);
                g.SetPixels(image.GetPixels(i * width, j * height, tileWidth, tileHeight));
                g.Apply();
                System.IO.File.WriteAllBytes(gameManager.UserPhotoPath + "/SelfieTile_" + i + "_" + j + ".png", g.EncodeToPNG());
            }
        }

        GetComponent<AutoSwitchScreen>().enabled = true;
    }

}
