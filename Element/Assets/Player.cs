using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    private float cameraSpeed = 3.0f;
    private Transform PlayerTransform;
    private Transform CameraTransform;

    void Start()
    {
        PlayerTransform = gameObject.transform;
        CameraTransform = GameObject.FindGameObjectWithTag("MainCamera"). GetComponent<Transform>();
    }

    void Update()
    {
        PlayerTransform.transform.Rotate(0, Input.GetAxis("Mouse X") * cameraSpeed, 0);
        CameraTransform.transform.Rotate(-Input.GetAxis("Mouse Y") * cameraSpeed, 0, 0);

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

        if (Input.GetAxis("Vertical") != 0) PlayerTransform.transform.position += dir1 * Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0)
            PlayerTransform.transform.position -= dir2 * Input.GetAxis("Horizontal") *speed * Time.deltaTime;
    }
}
