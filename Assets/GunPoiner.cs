using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPoiner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        int angleOffset = 90;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
