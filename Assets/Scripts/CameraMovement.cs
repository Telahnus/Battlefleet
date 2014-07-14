using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	void Update () {

		//move CameraTarget along x/z axis
		float translationX = Input.GetAxis("Horizontal");
		float translationZ = Input.GetAxis("Vertical");
		transform.Translate(translationX, 0, translationZ);

		//rotate camera about y axis
		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate(0, -1, 0);
		}
		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate(0, 1, 0);
		}

	}


}
