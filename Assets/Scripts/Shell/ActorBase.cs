using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorBase : MonoBehaviour
{

    public abstract void Awake();
    public abstract void Start();
    public abstract void FixedUpdate();
    public abstract void Update();
    public abstract void OnDestroy();
}
   
