using UnityEngine;
using UnityEngine.Networking;

public class Controller : MonoBehaviour
{
    

    public float speedH = 0.5f;
    public float speedV = 0.5f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
	{

        if(Input.GetKeyDown("space")) Screen.fullScreen = !Screen.fullScreen; 

        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(0.0f, xAxisValue / 5, 0.0f));
        }

       /* yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");*/

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }

}