using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonActorBase<T> : GameActor<GameManager> where T:Object
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }


}
