using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CharecterMovement : MonoBehaviour
{
    public  Animator anim;
    public float speed;
    public int Scene;
    public string tempNpcName;
    public EXP Exp;

    void Start()
    {
        if (Time.realtimeSinceStartup < 5)
        {
            transform.position = new Vector2(0, 0);
        }
        else
        {
            transform.position = Exp.MapBasicPosition;
            Exp.Scene = Scene;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            tempNpcName = collision.name;
        }
    }
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.4f || Input.GetAxisRaw("Horizontal") < -0.4f)
        {
            if (Input.GetAxisRaw("Vertical") > 0.4f || Input.GetAxisRaw("Vertical") < -0.4f)
            {
                transform.Translate(new Vector2(0.7f * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0.7f * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime));
            }
            else
            {
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f));
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0.4f || Input.GetAxisRaw("Vertical") < -0.4f)
        {
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime));
        }
        anim.SetFloat("V", Input.GetAxisRaw("Vertical") );
        anim.SetFloat("H", Input.GetAxisRaw("Horizontal") );
    }
}
