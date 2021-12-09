using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FollowCamera : MonoBehaviour
{
    public GameObject objecttofollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookspeed = 10;
    public PhotonView pv;
    private void Start()
    {

        //if (StaticChecks.unityEditor || StaticChecks.unitystandalone)
        //{
        //    this.enabled = false;
        //}

        objecttofollow = GameObject.FindGameObjectWithTag("MainCamera");

        pv = GetComponentInParent<PhotonView>();
        if (pv.IsMine)
        {
            foreach (Transform t in transform)
            {
                //if (t.GetComponent<SkinnedMeshRenderer>() != null)
                //    t.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
        }
    }

    public void LookTarget()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, objecttofollow.transform.eulerAngles.y, transform.eulerAngles.x) ;

    }

    public void MoveTarget()
    {
        Vector3 _tarPos = objecttofollow.transform.position + objecttofollow.transform.forward * offset.z + objecttofollow.transform.right * offset.x + objecttofollow.transform.up * offset.y;
        _tarPos.y = .8f;
        transform.position = Vector3.Lerp(transform.position, _tarPos, followSpeed * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        if(objecttofollow == null || !pv.IsMine)
        {
            return;
        }

      LookTarget();
        MoveTarget();
    }
}
