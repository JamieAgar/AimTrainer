using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public float fireDelay = 0.1f;

    public LayerMask playerBlockerMask;
    Animator gunAnim;

    // Start is called before the first frame update
    void Start()
    {
        gunAnim = GetComponentInChildren<Animator>();
    }

    private float fireDelayTimer = 0f;
    public void OnFire(InputValue value)
    {
        //If time since last fired is less than the fireDelay, don't fire
        fireDelayTimer += Time.deltaTime;
        if (fireDelayTimer < fireDelay)
        {
            fireDelayTimer = 0f;
            return;
        }

        //Handle gun animation
        Debug.Log("Shooting from PlayerShoot");
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
