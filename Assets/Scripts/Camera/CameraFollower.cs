using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.y = Target.position.y;
        transform.position = transformPosition;
    }
}
