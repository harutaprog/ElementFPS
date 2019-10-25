using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    struct bullet
    {
        public int ID;
        public long value;
    };

    [SerializeField]
    private float speed = 10.0f;
    private float cameraSpeed = 3.0f;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    [SerializeField]
    private GameObject Bullet;

    private List<bullet> Bulletlists = new List<bullet>() { new bullet {ID = 0, value = 0} };
    private BulletTable bulletTable;
    private List<BulletBase> bulletBases = new List<BulletBase>();

    void Start()
    {
        bulletTable = Resources.Load<BulletTable>("BulletTable");
        Debug.Log(bulletTable);
        bulletBases = bulletTable.bulleBase;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PlayerTransform = gameObject.transform;
        CameraTransform = GameObject.FindGameObjectWithTag("MainCamera"). GetComponent<Transform>();
    }

    void Update()
    {
        PlayerTransform.Rotate(0, Input.GetAxis("Mouse X") * cameraSpeed, 0);
        CameraTransform.Rotate(-Input.GetAxis("Mouse Y") * cameraSpeed, 0, 0);

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

        if (Input.GetAxis("Vertical") != 0) PlayerTransform.transform.position += dir1 * Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0)
            PlayerTransform.transform.position -= dir2 * Input.GetAxis("Horizontal") *speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //            Instantiate(Bullet, CameraTransform.position, CameraTransform.rotation);
            bulletBases[0].Shot();
        }
    }
}
