using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Scroll : MonoBehaviour
{
    public float scrollSpeed = -5f;
    private Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.velocity = new Vector2(scrollSpeed * GameManager.Instance.globalSpeed, 0f);
    }
}
