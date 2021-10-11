using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    private float min_x = -445.0f, max_x = 446.0f;
    private bool canMove;
    private float move_speed = 10f;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
    void Start()
    {
        canMove = true;
        if (Random.Range(0, 2) > 0)
        {
            move_speed *= 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
        if (Input.GetMouseButtonDown(0))
        {
            DropBox();
        }
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_speed * Time.deltaTime;
            if (temp.x>max_x)
            {
                move_speed *= 50f;
            }else if (temp.x < min_x)
            {
                move_speed *= 50f;
            }
            transform.position = temp;
        }
    }

    public void DropBox()
    {
        canMove = false;
        rb.gravityScale = Random.Range(60,100);
    }
}
