using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class Repeat : MonoBehaviour
{
    public float padding = 0.01f;
    private BoxCollider2D box; 
    private float width; 
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        width = box.size.x * transform.localScale.x;
    }
    void Update()
    {
        Vector3 position = transform.position;
        if(position.x < -width)
        {
            Loop();
        }
    }
    void Loop()
    {
        float offset = width - padding;
        transform.position += new Vector3(offset * 2, 0);
    }
}
