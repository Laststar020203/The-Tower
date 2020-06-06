using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Ctrl : MonoBehaviour {

    public enum State { ATTACK , WALKING}

    public State state = State.WALKING;
    Transform tr;
    Transform playerTr;
    Rigidbody rb;

    ParticleSystem wavePs;
    public GameObject aurora;

    public float speed;
    public float dampSpeed;
    public float waveCoolTime = 2.0f;
    public float auroraAttackCoolTime = 5.0f;
    public GameObject wave;

    bool isStop = false;

    //255 0 255 pink 0 255 255 하늘
    Color[] colors = { Color.red, Color.white, Color.blue, Color.yellow, new Color(255,0,255), new Color(0,255,255), Color.green};

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        wavePs = wave.GetComponent<ParticleSystem>();

        StartCoroutine(Wave());
        //StartCoroutine(AuroraAttack());
        

    }
	
	// Update is called once per frame
	void Update () {
        playerTr = Manager_Boss2.instance.playerTr;

        Turn();

       
     


    }
    private void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        if (playerTr == null) return;
        Vector3 direction = playerTr.position - tr.position;
        //nomalize로 하면 속도 동일
        
        direction.y = 0;
        rb.MovePosition(tr.position+(Vector3.Normalize(direction) * speed * Time.deltaTime));
    }
    void Turn()
    {
        Quaternion rot = Quaternion.LookRotation(playerTr.position - tr.position);
        rot.x = 0;
        rot.z = 0;
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * dampSpeed);

    }
    IEnumerator Wave()
    {
        while (!isStop)
        {

            //wavePs.startColor = colors[Random.Range(0, colors.Length)];

            GameObject obj = Instantiate(wave, tr.position, Quaternion.Euler(90, 0, 0));
            Destroy(obj, 0.6f);
            yield return new WaitForSeconds(waveCoolTime);

        }

    }
    IEnumerator AuroraAttack()
    {
        while (!isStop)
        {
            yield return new WaitForSeconds(auroraAttackCoolTime);
            Vector3 distance = playerTr.position - tr.position;
            distance.y = 0;
          
            GameObject _aurora = Instantiate(aurora, tr.position, Quaternion.LookRotation(distance));
            Destroy(_aurora,10f);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Manager_Boss2.instance.HitPlayer();
        }
    }
}
