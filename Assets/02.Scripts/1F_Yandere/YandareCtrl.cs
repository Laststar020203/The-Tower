using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class YandareCtrl : MonoBehaviour {

    #region Var
    public enum Personality {PEACEFUL , MODERATION , VIOLENT , PHYSCO , STOP};

    public Personality state;
    private Transform tr;
   
    private Vector3 bet;
    private Rigidbody rb;

    private int life = 3;
    private bool onTime = false;
    public readonly float MOVESPEED = 8000f;

    public float damp = 90f;
    float moveSpeed;
    WaitForSeconds ws = new WaitForSeconds(0.01f);

    public float power = 50;
    public float height = 5;
    public float nextTime = 0;
    public float stuntTime = 5f;
    private bool isCollision = false;

    public readonly float DASHPOWER = 50f;
    float dashPower;
    
    public bool isStop = false;
    [HideInInspector]
    public Animator anim;
    private readonly int hashRunning = Animator.StringToHash("isRunning");
    private readonly int hashDie = Animator.StringToHash("Die");
    private readonly int hashSlip = Animator.StringToHash("Slip");
    [HideInInspector]
    public readonly int hashFlyGravity = Animator.StringToHash("FlyGravity");
    [HideInInspector]
    public bool isDie = false;

    public float violentDistance = 3f;
    public float moderationDistance = 5f;

    public Transform PulleffectPos;
    public GameObject pullEffect;

    private bool isSturn;
    public Transform target;

    #endregion


    void Start () {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();

       //agent = GetComponent<NavMeshAgent>();
      // agent.Warp(tr.position);
       
     //  agent.speed = moveSpeed;

       // _changeMoveManager = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<ChangeMoveManager>();
    
        StartCoroutine(DashAttack());
        StartCoroutine(PersonalityHandling());
        StartCoroutine(PersonalityState());



        anim.SetBool(hashRunning, true);




    }
   
	
    IEnumerator DashAttack()
    {
        while (!isStop)
        {
            yield return new WaitForSeconds(4f);
            if (!(tr.position.y > target.position.y + 5))
            {

                rb.AddForce((target.position - tr.position) * dashPower * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
   
    // Update is called once per frame
    void Update () {
        
        LookPlayer();
       
       
    }
    private void FixedUpdate()
    {
        Move();
    }
    void LookPlayer()
    {

        if (tr.position.y > target.position.y + 5) return;


        Quaternion rot = Quaternion.LookRotation(target.position - tr.position);

        rot.x = 0;
        rot.z = 0;

        tr.rotation = Quaternion.Slerp(tr.rotation, rot, damp * Time.deltaTime);

       
       // transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
    /*
    void FollowChara(Vector3 pos)
    {
       if (agent.pathPending) return;

       agent.isStopped = false;
       
        agent.SetDestination(pos);
    }
    */
    void Move()
    {
        if (isSturn) return;
        
        Vector3 direction = target.position - tr.position;
        if (tr.position.y > target.position.y+5) return;
        
        rb.AddForce(Vector3.Normalize(direction) * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DEADZONE")) ;
            //Manager_Yandere.instance.YandereDamage();

    }
    private void OnCollisionEnter(Collision coll)
    {
        
        

        if (coll.collider.CompareTag("PLAYER"))
        {
            if (isSturn || isStop) return;
            StartCoroutine(Pull(coll));
        }

    }
    

    

    
    IEnumerator PersonalityState()
    {
        while (!isDie)
        {
            float distance = Vector3.Distance(Vector3.zero ,tr.position);

            if (distance <= violentDistance)
            {
                state = Personality.PEACEFUL;
            }
            else if (distance <= moderationDistance)
            {
                state = Personality.MODERATION;
            }
            else if(distance <= 180f)
            {
                state = Personality.VIOLENT;
            }
            else 
            {
                if (Vector3.Distance(Vector3.zero, target.position) >= 170f)
                {
                    state = Personality.STOP;
                }
                else
                    state = Personality.PHYSCO;


          

            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator PersonalityHandling()
    {
        while (!isDie)
        {
            switch (state)
            {
                case Personality.PEACEFUL:
                    moveSpeed = MOVESPEED;
                    dashPower = DASHPOWER;
                    break;
                case Personality.MODERATION:
                    moveSpeed = MOVESPEED + MOVESPEED * 0.5f;
                    dashPower = DASHPOWER + DASHPOWER * 0.5f;
                    break;
                case Personality.VIOLENT:
                    moveSpeed = MOVESPEED * 1.5f;
                    dashPower = DASHPOWER * 1.5f;
                    rb.velocity -= -tr.position * Time.deltaTime * 2;
                    break;
                case Personality.PHYSCO:
                    //rb.AddForce((patrollPos - tr.position) * dashPower * Time.deltaTime, ForceMode.Impulse);
                    moveSpeed = MOVESPEED;
                    dashPower = 0;
                    rb.velocity -= -tr.position * Time.deltaTime;
                 
                    break;
                case Personality.STOP:
                    rb.velocity = Vector3.zero;
                    dashPower = 0;
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Pull(Collision coll)
    {
        isSturn = true;
        anim.SetBool(hashRunning, false);
        anim.SetTrigger(hashSlip);

        // agent.enabled = false;

       

        bet = transform.position - coll.gameObject.transform.position;
        bet.y = 0;
       
        rb.AddForce(bet * power, ForceMode.Impulse);
        GameObject pullEffectClone = Instantiate(pullEffect, PulleffectPos.position,    PulleffectPos.rotation);

        Debug.Log("effect@");
        Destroy(pullEffectClone, 3.0f);
        yield return new WaitForSeconds(stuntTime);

        anim.SetBool(hashRunning, true);

       
        //agent.enabled = true;

        isSturn = false;
      

    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.CompareTag("FLOOR"))
        {
            state = Personality.STOP;
        }
    }


}
