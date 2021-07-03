using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTrajectory : MonoBehaviour
{
    
    protected float Animation;

    public float x;
    public float y;
    public float z;
    

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    
    }


    void Update()
    {
        Animation += Time.deltaTime;

        Animation = Animation % 5f;

        

        Vector3 start = new Vector3(x, y, z);

        transform.position = MathParabola.Parabola(start, Vector3.forward * 10f, 5f, Animation / 5f);        
    }
}
