using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BGController : MonoBehaviour
{
    GameObject target;
    Rigidbody2D rb;
    Vector2 velocity;
    Material material;

    [SerializeField] float moveSpeed;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = target.GetComponent<Rigidbody2D>();
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (rb != null)
        {
            velocity = new Vector2(rb.velocity.x, 0);
            material.mainTextureOffset += velocity * moveSpeed * Time.deltaTime;
        }
    }
}
