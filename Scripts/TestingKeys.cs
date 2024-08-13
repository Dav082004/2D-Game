using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Mouse
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("button pressed");
		}
		if (Input.GetMouseButton(0)) {
			Debug.Log("button is pressed");
		}
		if (Input.GetMouseButtonUp(0)) {
			Debug.Log("button released");
		}

		// 1.1 By the way, you can change the number "0" for other numbers
		// 			"1" is the right button
		// 			"2" is the middle button


		// Getting keyboard button events
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("Using Keycode. You can use this to make the player jump");
		}

		if (Input.GetButtonDown("Jump")) {
			Debug.Log("Using Jump. You can use this to make the player jump");
		}

		// 3. Getting Axis for movement
		float horizontal = Input.GetAxis("Horizontal"); // -1 to 1
		float vertical = Input.GetAxis("Vertical"); // -1 to 1

		if (horizontal < 0f || horizontal > 0f) {
			Debug.Log("Horizontal axis is " + horizontal);
		}
		if (vertical < 0f || vertical > 0f) {
			Debug.Log("Vertical axis is " + vertical);
		}
	}
}
