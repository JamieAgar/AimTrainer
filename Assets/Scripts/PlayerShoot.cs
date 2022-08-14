using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public float fireDelay = 0.1f;
    private float fireDelayTimer = 0f;
    private bool canFire = true;

    public LayerMask playerBlockerMask;

    Animator gunAnim;

    private PlayerController playerController;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        gunAnim = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (!canFire)
        {
            fireDelayTimer += Time.deltaTime;
            if(fireDelayTimer > fireDelay)
            {
                canFire = true;
                fireDelayTimer = 0f;
            }
        }
    }

    public void OnFire()
    {
        if (!playerController.cursorInputForLook) return;
        if (!canFire) return;
        canFire = false;

        //Handle animations
        gunAnim.SetTrigger("Shoot");

        //Handle raycasting + targets
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity, playerBlockerMask))
        {
            Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 2f);
            //Debug.Log("Hit");
            Target target = hit.transform.gameObject.GetComponent<Target>();
            target.TargetHit();
        }
        else
        {
            Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * 1000, Color.white, 2f);
            //Debug.Log("No Hit");
        }

    }
}
