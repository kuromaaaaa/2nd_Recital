using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    public abstract void BulletHit(Collider2D coll);
      
    private void OnTriggerEnter2D(Collider2D collision)
    {
         BulletHit(collision);
    }
}
