using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCamp : Singleton<ObjectCamp>
{
    private List<Object> allFreeObjects;

    private List<System.Tuple<System.Type, System.Func<Object>>> creationRules;
    private List<System.Tuple<System.Type, System.Action<Object>>> pushActions;
    private List<System.Tuple<System.Type, System.Action<Object>>> takeActions;

    public void Awake()
    {
        allFreeObjects = new List<Object>();
        creationRules = new List<System.Tuple<System.Type, System.Func<Object>>>();
        takeActions = new List<System.Tuple<System.Type, System.Action<Object>>>();
        pushActions = new List<System.Tuple<System.Type, System.Action<Object>>>();


        creationRules.Add(new System.Tuple<System.Type, System.Func<Object>>(typeof(FireBall), () =>
        {
            FireBall Created = Instantiate(GameManager.Instance.gameData.prefabs.fireBall).GetComponent<FireBall>();
            return Created;
        }));
        pushActions.Add(new System.Tuple<System.Type, System.Action<Object>>(typeof(FireBall), (Object o) =>
        {
            FireBall objectx = o as FireBall;
            objectx.gameObject.SetActive(false);
            objectx.transform.position = Vector3.zero;
        }));
        takeActions.Add(new System.Tuple<System.Type, System.Action<Object>>(typeof(FireBall), (Object o) =>
        {
            FireBall objectx = o as FireBall;
            objectx.gameObject.SetActive(true);
        }));

    }
    
    public T GetObject<T>() where T : Object
    {
        T result = default;
        System.Type searchingType = typeof(T);
        result = allFreeObjects.Find(x => x.GetType() == searchingType) as T;
        if (!result)
        {
            System.Func<Object> findedRule = creationRules.Find(x => x.Item1 == searchingType)?.Item2;
            if (findedRule != null)
            {
                result = (T)findedRule.Invoke();
            }
        }
        else
        {
            System.Action<Object> findedAction = takeActions.Find(x => x.Item1 == searchingType)?.Item2;
            findedAction?.Invoke(result);
            allFreeObjects.Remove(result);
        }
        return result;
    }
   
    public void TakeObjecy<T>(T O) where T : Object
    {
        allFreeObjects.Add(O);
        System.Type searchingType = typeof(T);
        Debug.Log(searchingType);
        System.Action<Object> findedAction = pushActions.Find(x => x.Item1 == searchingType)?.Item2;
        findedAction?.Invoke(O);
    }


}
