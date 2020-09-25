using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrapple : MonoBehaviour
{
    public GameObject hookPrefab;
    DistanceJoint2D joint;
    LineRenderer line;
    public bool grappled = false;
    public float jointDistanceOffset = 0.01f;
    public float rapelSpeed = 0.001f;
    float nextShotTime;
    public float shotCooldown = 1f;

    void Start()
    {
        joint = GetComponentInParent<DistanceJoint2D>();
        joint.enabled = false;
        line = GetComponentInParent<LineRenderer>();
        line.enabled = false;
    }

    void Update()
    {
        Vector2 origin = transform.position;
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if (Input.GetButtonDown("Fire1")) {
            RaycastHit2D hit = Physics2D.Raycast(origin, dir, 10f);
            Debug.DrawRay(origin, dir, Color.red, 1f);
            Launch(dir, hit);
        }

        if (Input.GetButtonUp("Fire1")) {
            Detach();
        }

        if (grappled) {
            line.SetPosition(0, line.gameObject.transform.position);
            joint.distance -= Input.GetAxis("Vertical") * rapelSpeed;
        }
    }

    void Launch(Vector2 dir, RaycastHit2D hit)
    {
        if (Time.time < nextShotTime) {
            return;
        }

        nextShotTime = Time.time + shotCooldown;

        if (hit.collider && hit.collider.name == "Stage") {
            Attach(hit.point);
        } else {
            Detach();
        }
    }

    void Attach(Vector2 point)
    {
        grappled = true;
        joint.connectedAnchor = point;
        joint.enabled = true;
        joint.distance = Vector2.Distance(transform.position, point) - jointDistanceOffset;
        line.SetPosition(1, point);
        line.enabled = true;
    }

    void Detach() 
    {
        grappled = false;
        joint.enabled = false;
        line.enabled = false;
    }
}
