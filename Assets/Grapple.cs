// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent(typeof(LineRenderer))]
// [RequireComponent(typeof(Rigidbody2D))]
// public class Grapple : MonoBehaviour
// {
//     LineRenderer line;
//     Rigidbody2D rigidbody2D;

//     public float horizontal;
    
//     public bool isFiring = false;
//     public bool isRetracting = false;
//     public Vector2 destination;

//     int frames = 10;


//     // Start is called before the first frame update
//     void Start()
//     {
//         line = GetComponent<LineRenderer>();
//         rigidbody2D = GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         horizontal = Input.GetAxis("Horizontal");

//         transform.Translate(new Vector2(horizontal, 0) * Time.deltaTime);

//         if (Input.GetButtonDown("Jump")) {
//             rigidbody2D.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
//         }

//         if (!isFiring && Input.GetButtonDown("Fire1")) {
//             StartCoroutine(FireGrapple());
//         }

//         if (Input.GetButtonUp("Fire1")) {
//             StartCoroutine(RetractGrapple());
//         }

//         line.SetPosition(0, transform.position);
//     }

//     IEnumerator FireGrapple()
//     {
//         isFiring = true;
//         Vector2 origin = transform.position;
//         Vector2 clickDestination = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
//         // float angle = Vector2.SignedAngle(transform.position, clickDestination);
//         // Debug.Log(angle);

//         for (int i = 0; i < frames; i++) {
//             line.positionCount = i + 1;
//             line.SetPosition(i, Vector2.Lerp(origin, clickDestination, (float) i / (float) frames));
//             yield return null;
//         }
        
//         line.positionCount = 2;
//         line.SetPosition(1, clickDestination);
//         isFiring = false;
//     }

//     IEnumerator RetractGrapple()
//     {
//         isRetracting = true;
//         Vector2 origin = transform.position;
//         Vector2 currentDestination = line.GetPosition(1);

//         for (int i = 0; i < frames; i++) {
//             line.positionCount = i + 1;
//             line.SetPosition(i, Vector2.Lerp(origin, clickDestination, (float) i / (float) frames));
//         }
      
//         for (int i = frames; i > 0; i--) {
//             line.positionCount = i;
//             yield return null;
//         }

//         isRetracting = false;
//     }
// }
