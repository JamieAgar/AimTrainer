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

    // Start is called before the first frame update
    void Start()
    {
        gunAnim = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
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

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, playerBlockerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 2f);
            Debug.Log("Hit");
            GameObject target = hit.transform.gameObject;
            target.GetComponent<CharacterTarget>().DestroyTarget();
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, 2f);
            Debug.Log("No Hit");
        }

    }
}
