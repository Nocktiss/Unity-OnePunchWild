using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{

    [SerializeField] float speed = 2f, jumpForce = 500f;
    Rigidbody2D rb;
    Animator anim;
    bool lookRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

        float move = Input.GetAxis("Horizontal");
        float jumpPower = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
        anim.SetFloat("Speed", Mathf.Abs(move));

        transform.Translate(Vector2.up * Time.deltaTime * jumpPower);
        anim.SetFloat("Jump", Mathf.Abs(move));

        if (move > 0 && !lookRight)
        {
            Flip();
        }
        else if (move < 0 && lookRight)
        {
            Flip();
        }

				///Debug
				if (Input.GetKeyDown(KeyCode.M)) Wind();

		}

		private void FixedUpdate(){
			if (Input.GetKeyDown(KeyCode.Space)){
				rb.AddForce(new Vector2(0, jumpForce));
			}
		}

    void Flip()
    {
        lookRight = !lookRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

		void Wind(){
			anim.SetTrigger("Wind");
		}
}