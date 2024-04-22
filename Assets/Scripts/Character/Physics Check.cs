using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    [SerializeField] Vector2 bottomOffset;
    [SerializeField] float chechReduis;
    [SerializeField] LayerMask groundLayer;

    public bool isGround;

    void Update()
    {
        Check();
    }

    void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, chechReduis, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, chechReduis);
    }
}
