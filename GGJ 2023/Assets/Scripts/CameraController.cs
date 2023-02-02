using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Set this to the currently active character controller, so we don't lose
        //the ref between scenes
    }

    //Late update is called once per frame, before Update
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }

    public void SwitchTarget(CharacterMovement newTarget)
    {
        target = newTarget.gameObject.transform;
    }
}
