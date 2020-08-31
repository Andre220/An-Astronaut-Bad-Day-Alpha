using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt2D : MonoBehaviour
{
    public Transform targetPos;

    // Start is called before the first frame update
    void Start()
    {
        if (targetPos == null)
        {
            targetPos = GlobalVariables.instance.TargetTransform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = transform.position;
        var direction = targetPos.position - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
