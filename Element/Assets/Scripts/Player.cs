using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    private float cameraSpeed = 3.0f;
    private int LoadBullet = 0;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    [SerializeField]
    private GameObject Bullet;
    
    [SerializeField]
    private BulletTable bulletTable;
    private List<BulletBase> bulletBases = new List<BulletBase>();

    void Start()
    {

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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadBullet--;
            if(0 > LoadBullet)
            {
                LoadBullet = Bulletlists.Count - 1;
            }
            Debug.Log(LoadBullet);
        }

        else if (Input.GetKeyDown(KeyCode.X))
        {
            LoadBullet++;
            if(Bulletlists.Count <= LoadBullet)
            {
                LoadBullet = 0;
            }
            Debug.Log(LoadBullet);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Bulletlists[LoadBullet].value > 0)
            {
                Bulletlists[LoadBullet].value - 1;
                Instantiate(bulletBases[Bulletlists[LoadBullet].ID], CameraTransform.position, CameraTransform.rotation);
            }
//            bulletBases[0].Shot();
        }
    }
}
