using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    private float cameraSpeed = 3.0f;
    private int LoadBullet = 0;
    [SerializeField]
    private bool ShotWait = false;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    [SerializeField]
    private GameObject ShotPoint;
    
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
        //--------------------------------
        //視点移動&キャラクター移動
        //--------------------------------
        PlayerTransform.Rotate(0, Input.GetAxis("Mouse X") * cameraSpeed, 0);
        CameraTransform.Rotate(-Input.GetAxis("Mouse Y") * cameraSpeed, 0, 0);

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

        if (Input.GetAxis("Vertical") != 0) PlayerTransform.transform.position += dir1 * Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0)
            PlayerTransform.transform.position -= dir2 * Input.GetAxis("Horizontal") *speed * Time.deltaTime;

        //--------------------------------
        //ダッシュ機能
        //--------------------------------
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }

        //--------------------------------
        //メニュー機能(？)
        //--------------------------------
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }

        //--------------------------------
        //弾丸切り替え機能
        //--------------------------------
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotWait = false;
            LoadBullet--;
            if(0 > LoadBullet)
            {
                LoadBullet = bulletBases.Count - 1;
            }
            Debug.Log(LoadBullet);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            ShotWait = false;
            LoadBullet++;
            if(bulletBases.Count <= LoadBullet)
            {
                LoadBullet = 0;
            }
            Debug.Log(LoadBullet);
        }

        //--------------------------------
        //弾丸打ち出し
        //--------------------------------
        if (Input.GetMouseButton(0) && ShotWait == false)
        {
//          if (bulletBases[LoadBullet].Amm_Check() > 0){
            bulletBases[LoadBullet].Shot(/*CameraTransform.position*/ShotPoint.transform.position, CameraTransform.rotation);
            if (bulletBases[LoadBullet].WaitTime_Check() > 0)
            {
                ShotWait = true;
                StartCoroutine(BulletWait());
            }
//            }
        }
    }

    //--------------------------------
    //射撃の待機時間の処理
    //--------------------------------
    IEnumerator BulletWait()
    {
        yield return new WaitForSeconds(bulletBases[LoadBullet].WaitTime_Check());
        if (ShotWait == true) ShotWait = false;
    }
}