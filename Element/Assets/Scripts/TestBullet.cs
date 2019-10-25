using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : BulletBase
{
    public override void Shot()
    {
        Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);

    }
}