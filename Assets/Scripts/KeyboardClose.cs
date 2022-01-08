using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKeyboard.Utils;

public class KeyboardClose : MonoBehaviour
{

	public GameObject keyboardgameobjectexternal;

	public void close_keyboard()
    {
		keyboardgameobjectexternal.SetActive(false);
	}

}
