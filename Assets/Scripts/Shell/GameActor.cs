using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameActor<T> : ActorBase where T:EventBehaviour<T>
{
    private T Driver;

    public override sealed void Awake()
    {
        Driver = FindObjectOfType<T>();
        Driver.AddActor(this);
        ActorAwake();
    }

    public override sealed void FixedUpdate()
    {
        ActorFixedUpdate();
    }

    public override sealed void OnDestroy()
    {
        Driver.RemoveActor(this);
        ActorOnDestroy();
    }

    public override sealed void Start()
    {
        ActorStartUpdate();
    }

    public override sealed void Update()
    {
        ActorUpdate();
    }

    public virtual void ActorAwake() {}
    public virtual void ActorStartUpdate(){}
    public virtual void ActorFixedUpdate(){}
    public virtual void ActorUpdate() { }
    public virtual void ActorOnDestroy() { }





}
