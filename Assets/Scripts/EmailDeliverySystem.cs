using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmailDeliverySystem : MonoBehaviour
{

    public Text emailText;

    private GameManager gameManager;

    private void Start()
    {
        HideMessage();

        gameManager = GameObject.Find("_MANAGER").GetComponent<GameManager>();
    }

    public void SendEmail()
    {
        StartCoroutine(SendDataToServer());
    }

    private IEnumerator SendDataToServer()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", gameManager.UserEmail);
        form.AddField("image", gameManager.ImageToBase64);

        UnityWebRequest www = UnityWebRequest.Post("http://projects.rayqube.com/dewa_puzzle_email/", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            emailText.text = "Email Sending Failed! " + www.error;
            emailText.color = new Color(1.0f, 0.0f, 0.0f);
        }
        else
        {
            emailText.text = "Email Sent Successfully!";
            emailText.color = new Color(0.0f, 0.5411764705882353f, 0.2235294117647059f);

            string responce_text = www.downloadHandler.text;
            if (responce_text.Length > 0)
            {
                print(responce_text);
            }
        }

        Invoke("ExecuteNextAction", 2.0f);
    }

    private void ExecuteNextAction()
    {
        HideMessage();

        GetComponent<AutoSwitchScreen>().enabled = true;
    }

    private void HideMessage()
    {
        emailText.text = "";
        emailText.color = new Color(1.0f, 0.0f, 0.0f);
    }

}