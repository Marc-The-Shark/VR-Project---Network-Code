using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {


	public float CameraSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		var x = Input.GetAxis("Horizontal") * Time.deltaTime * CameraSpeed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * CameraSpeed;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		if(Camera.current != null)
		{
			Camera.current.transform.Translate(new Vector3(x, 0.0f, z));
		}
	
	}
}
