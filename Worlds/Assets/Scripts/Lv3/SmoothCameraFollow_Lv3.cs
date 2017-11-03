using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow_Lv3 : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private Transform target;

    public bool yMaxEnabled = false;
    public float yMaxValue = 0;

    public bool yMinEnabled = false;
    public float yMinValue = 0;

    public bool xMaxEnabled = false;
    public float xMaxValue = 0;

    public bool xMinEnabled = false;
    public float xMinValue = 0;


	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 targetPos = target.position;

        //Vertical
        if (yMinEnabled && yMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, yMinValue, yMaxValue);
        }
        else if (yMinEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, yMinValue, target.position.y);
        }
        else if (yMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, yMaxValue);
        }


        //Horizontal
        if (xMinEnabled && xMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, xMaxValue);
        }
        else if (xMinEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, target.position.x);
        }
        else if (xMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, xMaxValue);
        }

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
	}
}
