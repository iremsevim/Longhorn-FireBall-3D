using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
public abstract class EventBehaviour<T> : MonoBehaviour where T:Object  //Actors Controller and Drive
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }

    public List<Data> events = new List<Data>();
    public void PushEvent(int ID) => events.FindAll(x => x.ID == ID).ForEach(x => x.Invoke());
    public void AddActor(ActorBase actor)
    {
        var current = actor.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.GetCustomAttributes(typeof(GE), true).Length > 0).ToList();
        foreach (var item in current)
        {
            GE gE = item.GetCustomAttribute<GE>();
            Data data = new Data(actor,item,gE.ID);
            events.Add(data);
        }
    }
    public void RemoveActor(ActorBase actor)
    {
       events.RemoveAll(x=>x.monoBehaviour==actor);
    }

    public class Data
    {
        public ActorBase monoBehaviour;
        public MethodInfo methodInfo;
        public int ID;

        public void Invoke()
        {
            methodInfo.Invoke(monoBehaviour,null);
        }

        public Data(ActorBase actorBase,MethodInfo methodInfo,int ID)
        {
            this.monoBehaviour = actorBase;
            this.methodInfo = methodInfo;
            this.ID = ID;
        }
    }
}
