using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetActor : SingletonActorBase<TargetActor>,ITouchListener
{

    public float rotSpeed;
    public bool isrotLocked;
    public List<GameObject> allParts = new List<GameObject>();


    public override void ActorUpdate()
    {
       if(isrotLocked)
        {
            Rotate();
        }
    }
    public void Rotate()
    {
        
        transform.Rotate(0, rotSpeed * Time.deltaTime * 10, 0);
    }
    
    [GE(BaseGameEvents.StartGame)]
    public void OnGameStart()
    {
        isrotLocked = true;
        UI_Actor.Instance.UpdateCircleAmount(allParts.Count);

    }

    public void TriggerListener(MonoBehaviour toucher)
    {
       if(toucher is FireBall)
        {
            Debug.Log("Ball Hit");
            ObjectCamp.Instance.TakeObjecy(toucher as FireBall);
            Hit();
        }
    }
    public void Hit()
    {
        allParts.Sort((x, y) => (x.transform.position.y.CompareTo(y.transform.position.y)));
      
        for (int i = 1; i < allParts.Count; i++)
        {
            allParts[i].transform.DOMove(allParts[i - 1].transform.position, 0.1f);
        }

        Destroy(allParts[0].gameObject);
        allParts.RemoveAt(0);
        UI_Actor.Instance.UpdateCircleAmount(allParts.Count);
        GameManager.Instance.EarnScore();
        if(allParts.Count<=0)
        {
            GameManager.Instance.FinishLevel(true);
        }
    }
    [GE(BaseGameEvents.FinishGame)]
    public void OnFinishGame()
    {

        isrotLocked = false;
    }
}
