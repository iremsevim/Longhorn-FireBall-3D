using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonActorBase<Player>
{
    public Transform bulletPoint;
    public bool canShoot;


    public override void ActorUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if(!canShoot) return;
        FireBall bullet = ObjectCamp.Instance.GetObject<FireBall>();
        bullet.transform.position = bulletPoint.position;
        bullet.Throw(bulletPoint.forward);

    }
    public void Dead()
    {
        Destroy(gameObject);
        GameManager.Instance.FinishLevel(false);
    }
    [GE(BaseGameEvents.onWrongHit)]
    public void OnWrongHit()
    {
        canShoot = false;
    }
    [GE(BaseGameEvents.FinishGame)]
    public void FinishGame()
    {
        canShoot = false;
    }
}
