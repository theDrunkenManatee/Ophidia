using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHelper : MonoBehaviour
{
    public CollisionHandler handler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("CollisionHelper detected hit with " + hit.gameObject.name);
        handler.HandleHit(hit);

    }
}
