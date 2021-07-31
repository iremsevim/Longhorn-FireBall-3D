using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonActorBase<Player>
{

    public Transform bulletPoint;


    public override void ActorUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
  
    private void Fire()
    {
        FireBall bullet = ObjectCamp.Instance.GetObject<FireBall>();
        bullet.transform.position = bulletPoint.position;
        bullet.Throw(bulletPoint.forward);

    }
}
