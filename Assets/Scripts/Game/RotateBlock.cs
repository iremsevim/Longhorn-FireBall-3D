using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateBlock : SingletonActorBase<RotateBlock>,ITouchListener
{
    public float speed;
    public bool ÝsLocked;
   
    public override void ActorUpdate()
    {
        RotateObstacle();
    }
    
    private void RotateObstacle()
    {
        if(ÝsLocked)
        {
            transform.Rotate(0, speed * 100 * Time.deltaTime, 0);
        }
      
    }
    [GE(BaseGameEvents.StartGame)]
    public void OnStartGame()
    {
        ÝsLocked = true;
       
    }
    [GE(BaseGameEvents.FinishGame)]
    public void OnFinishGame()
    {

        ÝsLocked = false;
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
