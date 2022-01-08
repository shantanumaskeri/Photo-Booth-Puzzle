using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyboardDisplayManager : MonoBehaviour
{

	public GameObject keyboard;
	public InputField last_focused_input_field;
	public Text dummy_text;
	
	// Update is called once per frame
	private void Update()
    {
	    foreach (InputField inputField in gameObject.GetComponentsInChildren<InputField>())
	    {
		    if (inputField.isFocused == true)
            {
		        last_focused_input_field = inputField;
		    }
	    }

	    if (last_focused_input_field)
        {
		    keyboard.SetActive(true);
		    last_focused_input_field.text = dummy_text.text; 	
	    }
	}

}
