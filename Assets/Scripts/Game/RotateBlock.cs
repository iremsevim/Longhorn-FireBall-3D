using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateBlock : SingletonActorBase<RotateBlock>,ITouchListener
{
    public float speed;
    public bool �sLocked;
   
    public override void ActorUpdate()
    {
        RotateObstacle();
    }
    
    private void RotateObstacle()
    {
        if(�sLocked)
        {
            transform.Rotate(0, speed * 100 * Time.deltaTime, 0);
        }
      
    }
    [GE(BaseGameEvents.StartGame)]
    public void OnStartGame()
    {
        �sLocked = true;
       
    }
    [GE(BaseGameEvents.FinishGame)]
    public void OnFinishGame()
    {

        �sLocked = false;
    }


    public void TriggerListener(MonoBehaviour toucher)
    {
        if(toucher is FireBall)
        {
            transform.DOScale(transform.localScale * 1.25f, 0.25f).OnComplete(() =>
            {
                transform.DOScale(transform.localScale / 1.25f, 0.25f);
            
            });
            GameManager.Instance.PushEvent(BaseGameEvents.onWrongHit);
            (toucher as FireBall).HitPlayer();
        }
    }
}
