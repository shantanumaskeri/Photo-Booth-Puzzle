using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;

public class PhotoPuzzle : MonoBehaviour
{

	private System.Random _random = new System.Random();

	public Text counter_text;
	float timeLeft = 0.0f;

    public GameObject cell_1_1;
	public GameObject cell_1_2;
	public GameObject cell_1_3;
	public GameObject cell_1_4;

	public GameObject cell_2_1;
	public GameObject cell_2_2;
	public GameObject cell_2_3;
	public GameObject cell_2_4;
	
	public GameObject cell_3_1;
	public GameObject cell_3_2;
	public GameObject cell_3_3;
	public GameObject cell_3_4;

	public GameObject cell_4_1;
	public GameObject cell_4_2;
	public GameObject cell_4_3;
	public GameObject cell_4_4;

	public Image image_1_1;
	public Image image_1_2;
	public Image image_1_3;
	public Image image_1_4;

	public Image image_2_1;
	public Image image_2_2;
	public Image image_2_3;
	public Image image_2_4;

	public Image image_3_1;
	public Image image_3_2;
	public Image image_3_3;
	public Image image_3_4;

	public Image image_4_1;
	public Image image_4_2;
	public Image image_4_3;
	public Image image_4_4;
	
	int gamestarted = 0;

    bool game_completed = false;

    private GameManager gameManager;

    // Use this for initialization
    private IEnumerator Start()
    {
        gameManager = GameObject.Find("_MANAGER").GetComponent<GameManager>();
        
        int[] indexes = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};

        Shuffle(indexes);

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_0_0.png")) { yield return www.SendWebRequest(); image_1_1.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_0_1.png")) { yield return www.SendWebRequest(); image_1_2.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_0_2.png")) { yield return www.SendWebRequest(); image_1_3.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_0_3.png")) { yield return www.SendWebRequest(); image_1_4.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_1_0.png")) { yield return www.SendWebRequest(); image_2_1.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_1_1.png")) { yield return www.SendWebRequest(); image_2_2.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_1_2.png")) { yield return www.SendWebRequest(); image_2_3.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_1_3.png")) { yield return www.SendWebRequest(); image_2_4.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_2_0.png")) { yield return www.SendWebRequest(); image_3_1.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_2_1.png")) { yield return www.SendWebRequest(); image_3_2.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_2_2.png")) { yield return www.SendWebRequest(); image_3_3.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_2_3.png")) { yield return www.SendWebRequest(); image_3_4.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_3_0.png")) { yield return www.SendWebRequest(); image_4_1.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_3_1.png")) { yield return www.SendWebRequest(); image_4_2.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_3_2.png")) { yield return www.SendWebRequest(); image_4_3.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(gameManager.UserPhotoPath + "/SelfieTile_3_3.png")) { yield return www.SendWebRequest(); image_4_4.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)www.downloadHandler).texture.width, ((DownloadHandlerTexture)www.downloadHandler).texture.height), new Vector2(0, 0)); }

        cell_1_1.transform.SetSiblingIndex(indexes[0]);
		cell_1_2.transform.SetSiblingIndex(indexes[1]);
		cell_1_3.transform.SetSiblingIndex(indexes[2]);
		cell_1_4.transform.SetSiblingIndex(indexes[3]);

		cell_2_1.transform.SetSiblingIndex(indexes[4]);
		cell_2_2.transform.SetSiblingIndex(indexes[5]);
		cell_2_3.transform.SetSiblingIndex(indexes[6]);
		cell_2_4.transform.SetSiblingIndex(indexes[7]);

		cell_3_1.transform.SetSiblingIndex(indexes[8]);
		cell_3_2.transform.SetSiblingIndex(indexes[9]);
		cell_3_3.transform.SetSiblingIndex(indexes[10]);
		cell_3_4.transform.SetSiblingIndex(indexes[11]);

		cell_4_1.transform.SetSiblingIndex(indexes[12]);
		cell_4_2.transform.SetSiblingIndex(indexes[13]);
		cell_4_3.transform.SetSiblingIndex(indexes[14]);
		cell_4_4.transform.SetSiblingIndex(indexes[15]);

		timeLeft = 120f;
		gamestarted = 1;

        counter_text.text = Mathf.Round(timeLeft) + "";
    }

    // Update is called once per frame
    private void Update()
    {
	    if (!game_completed)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                timeLeft = 0;
            }

            if ((gamestarted == 1) && (timeLeft <= 0))
            {
                SceneManager.LoadScene("04_dewa_puzzle_lose");
            }
        }
        
        counter_text.text = Mathf.Round(timeLeft) + "";	
	}

 	private void OnSimpleDragAndDropEvent(DragAndDropCell.DropEventDescriptor desc)
    {
        if (Input.touchCount <= 1)
        {
            int all_matched = 1;

            foreach (Transform child in desc.sourceCell.transform.parent)
            {
                DragAndDropItem this_object_dummy = child.GetComponentInChildren<DragAndDropItem>();

                int cell_index = child.GetSiblingIndex();
                int item_index = this_object_dummy.item_index;

                if (cell_index != item_index)
                {
                    all_matched = 0;
                }
            }
            
            if (all_matched == 1)
            {
                game_completed = true;

                GetComponent<AutoSwitchScreen>().enabled = true;
            }
        }
	}

	private void Shuffle(int[] array)
    {
	    int p = array.Length;
	    for (int n = p-1; n > 0 ; n--)
	    {
	        int r = _random.Next(1, n);
	        int t = array[r];
	        array[r] = array[n];
	        array[n] = t;
	    }
	}

}
