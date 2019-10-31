using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BulletTable : ScriptableObject
{
    [SerializeField]
    public List<BulletBase> bulleBase = new List<BulletBase>();
}
