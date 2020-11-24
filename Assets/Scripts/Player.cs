using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float upForce = 6f;
    public float forward = 1f;
    private Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Flap()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(new Vector2(0f, upForce), ForceMode2D.Impulse);
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Flap();
        }
        Vector3 vel = rigid.velocity;
        float angle = Mathf.Atan2(vel.y, forward) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -45f, 45f);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Column")
        {
            GameManager.Instance.AddScore(1);
        }
    }
}
