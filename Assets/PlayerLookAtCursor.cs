using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAtCursor : MonoBehaviour
{

    [SerializeField] Transform _cursor;

    private void Update()
    {

        var direction = _cursor.position - transform.position;
        // v1
        //var rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot - 90);
        // v2
        transform.rotation = Quaternion.LookRotation(transform.forward, direction);

    }


}