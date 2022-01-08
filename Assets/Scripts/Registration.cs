using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using System.Text.RegularExpressions;

public class Registration : MonoBehaviour
{
	
	public InputField emailField;
	public Text form_message;

    private GameManager gameManager;

    // Use this for initialization
    private void Start()
    {
        form_message.color = new Color(1.0f, 0.0f, 0.0f);

        gameManager = GameObject.Find("_MANAGER").GetComponent<GameManager>();
    }

	public void CheckRegistration()
    {
        gameManager.UserEmail = emailField.text.ToLower();

        if (IsValidEmailAddress(gameManager.UserEmail))
        {
            form_message.text = "";
            form_message.color = new Color(1.0f, 0.0f, 0.0f);

            CancelInvoke("ClearMessage");

            GetComponent<EmailDeliverySystem>().SendEmail();
        }
        else
        {
            form_message.text = "Please enter a valid email.";
            form_message.color = new Color(1.0f, 0.0f, 0.0f);

            Invoke("ClearMessage", 2.0f);
        }
	}

    private void ClearMessage()
    {
        form_message.text = "";
    }

    public bool IsValidEmailAddress(string email)
    {
        #region overall conditions

        if (email.IndexOf("@") == -1)
            return false;

        if (email.IndexOf("!") >= 0 || email.IndexOf("#") >= 0 || email.IndexOf("$") >= 0 || email.IndexOf("%") >= 0 || email.IndexOf("^") >= 0 || email.IndexOf("&") >= 0 || email.IndexOf("*") >= 0 || email.IndexOf("(") >= 0 || email.IndexOf(")") >= 0 || email.IndexOf("-") >= 0 || email.IndexOf("=") >= 0 || email.IndexOf("+") >= 0 || email.IndexOf("[") >= 0 || email.IndexOf("{") >= 0 || email.IndexOf("]") >= 0 || email.IndexOf("}") >= 0 || email.IndexOf(":") >= 0 || email.IndexOf(";") >= 0 || email.IndexOf("'") >= 0 || email.IndexOf("|") >= 0 || email.IndexOf(",") >= 0 || email.IndexOf("<") >= 0 || email.IndexOf(">") >= 0 || email.IndexOf("/") >= 0 || email.IndexOf("?") >= 0)
            return false;

        if ((email.IndexOf("0") > email.IndexOf("@")) || (email.IndexOf("1") > email.IndexOf("@")) || (email.IndexOf("2") > email.IndexOf("@")) || (email.IndexOf("3") > email.IndexOf("@")) || (email.IndexOf("4") > email.IndexOf("@")) || (email.IndexOf("5") > email.IndexOf("@")) || (email.IndexOf("6") > email.IndexOf("@")) || (email.IndexOf("7") > email.IndexOf("@")) || (email.IndexOf("8") > email.IndexOf("@")) || (email.IndexOf("9") > email.IndexOf("@")))
            return false;

        if (email.IndexOf("0") == 0 || email.IndexOf("1") == 0 || email.IndexOf("2") == 0 || email.IndexOf("3") == 0 || email.IndexOf("4") == 0 || email.IndexOf("5") == 0 || email.IndexOf("6") == 0 || email.IndexOf("7") == 0 || email.IndexOf("8") == 0 || email.IndexOf("9") == 0 || email.IndexOf("@") == 0 || email.IndexOf(".") == 0)
            return false;

        if (email.IndexOf("@") != email.LastIndexOf("@"))
            return false;

        #endregion

        if (email != "")
        {
            #region divide email into two parts - name & domain

            string[] email_division = email.Split("@"[0]);
            string email_name = email_division[0];
            string email_domain = "@" + email_division[1];

            #endregion

            #region email name conditions

            if (email_name.IndexOf(".") != -1)
            {
                if (email_name.IndexOf(".") == 0)
                {
                    //Debug.Log("if1");
                    return false;
                }
                if (email_name.IndexOf(".") != email_name.LastIndexOf("."))
                {
                    //Debug.Log("if2");
                    return false;
                }
                if (email_name.IndexOf(".") == (email_name.Length - 1))
                {
                    //Debug.Log("if3");
                    return false;
                }
            }

            #endregion


            #region email domain conditions

            if (email_domain.IndexOf(".") == -1)
            {
                //Debug.Log("if4");
                return false;
            }
            if (email_domain.IndexOf(".") != email_domain.LastIndexOf("."))
            {
                if ((email_domain.LastIndexOf(".") - email_domain.IndexOf(".")) != 3)
                {
                    //Debug.Log("if5");
                    return false;
                }
            }
            else
            {
                if ((email_domain.IndexOf(".") - email_domain.IndexOf("@")) < 3)
                {
                    //Debug.Log("if6");
                    return false;
                }
            }

            #endregion
        }

        return true;
    }

}
