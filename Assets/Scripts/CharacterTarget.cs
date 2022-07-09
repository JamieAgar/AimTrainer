using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTarget : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float minChangeDirectionTime = .5f;
    public float maxChangeDirectionTime = 2f;
    private float changeDirectionTime;
    public float despawnTime = 5f;

    public CharacterController characterController;

    private Vector3 direction;

    //Initial Z point the target should move to before becoming random. This is to prevent the targets getting stay behind terrain
    private float targetZ = -12f;
    private bool reachedTargetZ = false;

    //Does the target need to go +z to get to target. So that the target doesn't need to reach exactly the target
    private bool posToTarget = false;


    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Target Spawned");
        UpdateChangeDirectionTime();
        //Generate direction on startup
        posToTarget = transform.position.z < targetZ;
        direction = Vector3.zero;
        if(posToTarget)
        {
            direction.z = 1f;
        } else
        {
            direction.z = -1f;
        }
    }

    float newDirectionTimer = 0f;
    float despawnTimer = 0f;
    // Update is called once per frame
    void Update()
    {
        //Get new direction so the target isn't always obvious
        newDirectionTimer += Time.deltaTime;
        if (newDirectionTimer > changeDirectionTime)
        {
            newDirectionTimer = 0f;
            //Don't get a new direction if we haven't reached the target yet
            if (reachedTargetZ)
            {
                UpdateDirection();
            }
        }

        //Despawn the target after some time
        despawnTimer += Time.deltaTime;
        if(despawnTimer > despawnTime)
        {
            Debug.Log("Target Despawned");
            TargetManager tm = FindObjectOfType<TargetManager>();
            tm.SpawnTarget();
            Destroy(this.gameObject);
        }

        if(!reachedTargetZ)
        {
            if (posToTarget && transform.position.z > targetZ)
            {
                reachedTargetZ = true;
                UpdateDirection();
                newDirectionTimer = 0f;
            }
            else if (!posToTarget && transform.position.z < targetZ)
            {
                reachedTargetZ = true;
                UpdateDirection();
                newDirectionTimer = 0f;
            }
        }

        //Move the target in the direction
        characterController.Move(direction * moveSpeed * Time.deltaTime);

        //Handle gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void UpdateDirection()
    {
        direction = transform.right * Random.Range(-1f, 1f) + transform.forward * Random.Range(-1f, 1f);
    }

    void UpdateChangeDirectionTime()
    {
        changeDirectionTime = Random.Range(minChangeDirectionTime, maxChangeDirectionTime);
    }

}
