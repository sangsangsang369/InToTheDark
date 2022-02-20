using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void CollisionObjectFunction()
    {
        Debug.Log("virtualFunction");
    }
}
