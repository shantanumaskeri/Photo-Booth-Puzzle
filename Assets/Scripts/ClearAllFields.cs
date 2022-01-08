using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearAllFields : MonoBehaviour
{

	public Text text;

	public void clear_text()
    {
		text.text = "";
	}

}
