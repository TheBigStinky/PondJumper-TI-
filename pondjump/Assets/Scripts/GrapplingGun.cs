using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingGun : MonoBehaviour
{
    public float spring;
    public float damper;
    public float massScale;
    public float ropeLength;
    public float minPointMod;
    public float AimAssistRadius;
    public float Refresh;


    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    float refreshTimer;

    bool grappleActive, grappling;
    Transform StuckToo;
    Vector3 StartingPoint;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        grappleActive = false;
        refreshTimer = Refresh;
    }

    public void Grapple(InputAction.CallbackContext context)
    {
        if (context.started && grappleActive && refreshTimer >= Refresh)
        {
            StartGrapple();
        }
        else if (context.canceled)
        {
            StopGrapple();
        }
    }

    private void FixedUpdate()
    {
        refreshTimer += refreshTimer < Refresh ? 1 : 0;

        if(grappling)
        {
            grapplePoint = StuckToo.position + StartingPoint;
            joint.connectedAnchor = StuckToo.position + StartingPoint;
        }
        
    }

    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.SphereCast(camera.position, AimAssistRadius, camera.forward, out hit, maxDistance))
        {
            if((whatIsGrappleable & (1 << hit.transform.gameObject.layer)) != 0)
            {
                Debug.Log(hit.transform.gameObject.layer);
                refreshTimer = 0;

                grappling = true;
                player.gameObject.GetComponent<thirdSoul>().GrapplePhysicsStart();

                StartingPoint = hit.point - hit.transform.position;
                StuckToo = hit.transform;

                grapplePoint = hit.point;
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                //float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
                float distanceFromPoint = 0;

                //The distance grapple will try to keep from grapple point. 
                joint.maxDistance = distanceFromPoint + ropeLength;
                joint.minDistance = distanceFromPoint + ropeLength + minPointMod;

                //Adjust these values to fit your game.
                joint.spring = spring;
                joint.damper = damper;
                joint.massScale = massScale;

                lr.positionCount = 2;
                currentGrapplePosition = gunTip.position;
            }
        }
    }

    public void GrappleEnable(bool state)
    {
        grappleActive = state;
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple()
    {
        player.gameObject.GetComponent<thirdSoul>().GrapplePhysicsEnd();
        grappling = false;
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}