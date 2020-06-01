using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class CharecterMovement : MonoBehaviour
{
    public  Animator anim;
    public float speed = 2.5f;
    public int Scene;
    public string tempNpcName;
    public EXP Exp;
    Rigidbody2D Character;
    Material Mat;
    public bool Mask = false , PPEKIT = false;
    public float Health = 100;
    public HealthBarScript HBS;
    public Text T;
    float GameTime = 0;


    void Start()
    {
        GameTime = 0;
        if (Exp.CharecterPresent)
        {
          //  Destroy(gameObject);
           // Debug.Log(Exp.CharecterPresent);
        }
        Exp.CharecterPresent = true;
       // DontDestroyOnLoad(gameObject);
        Mat = GetComponent<SpriteRenderer>().material;
        Character = GetComponent < Rigidbody2D > ();
        gameObject.transform.position = new Vector2(0, 0);

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
                //Character.AddForce(new Vector2(0.7f * Input.GetAxisRaw("Horizontal") * speed , 0.7f * Input.GetAxisRaw("Vertical") * speed));
                transform.Translate(new Vector2(0.7f * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0.7f * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime));


            }
            else
            {
               // Character.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0f));
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f));
                
   
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0.4f || Input.GetAxisRaw("Vertical") < -0.4f)
        {
           // Character.AddForce(new Vector2(0f, Input.GetAxisRaw("Vertical")* speed ));
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime));


        }
        anim.SetFloat("V", Input.GetAxisRaw("Vertical") );
        anim.SetFloat("H", Input.GetAxisRaw("Horizontal") );
       

        if (Mask) Mat.SetFloat("_Mask", 1);
        if (PPEKIT)
        {
            Mat.SetFloat("_ON", 1);
            Mat.SetFloat("_Mask", 0);
        }
        tempNpcName = null;
        Health -= 0.00f;
        HBS.SetHealth(Health);
        if (Health <= 0)
        {
            speed = 0;
        }
        else speed = 2.5f;
        //Debug.Log(Time.realtimeSinceStartup);
        GameTime += Time.deltaTime;
        Exp.GameTime = GameTime;
    }
    
}
