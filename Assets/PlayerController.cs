using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime);

        if (Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
        }
    }
}
