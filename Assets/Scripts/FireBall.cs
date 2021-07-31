using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class FireBall : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    public void Throw(Vector3 fireDireciton)
    {
        rb.AddForce(fireDireciton * 1000);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITouchListener touchListener))
        {
            touchListener.TriggerListener(this);
        }
    }

    public void HitPlayer()
    {
        transform.DOMove(Player.Instance.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            Player.Instance.Dead();
        });

    }
}
