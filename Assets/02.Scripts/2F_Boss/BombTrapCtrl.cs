using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrapCtrl : MonoBehaviour {
    GameObject _gameObject;
    Transform tr;
    public float expRadius = 10.0f;
    public float power = 1000f;
    public float createCoolTime = 4.0f;

   public GameObject wave;

    bool isCheck = false;

    string disableObject = "DisableObject";

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("MONSTER") || coll.collider.CompareTag("PLAYER"))
        {
            if (coll.collider.CompareTag("MONSTER"))
                Manager_Boss2.instance.HitBoss();
            else
                Manager_Boss2.instance.HitPlayer();



            Bomb();

            GameObject obj = Instantiate(wave, tr.position, Quaternion.identity);
            Destroy(obj, 3.0f);


            Invoke(disableObject, 0.3f);


        





           
           
        }
    }

    void Bomb()
    {
        Collider[] colls = Physics.OverlapSphere(tr.position, expRadius, 1 << 12);
        foreach (var coll in colls)
        {
            float distance = Vector3.Distance(tr.position, coll.transform.position);
            
            var _rb = coll.GetComponent<Rigidbody>();

            _rb.AddExplosionForce(power/distance, tr.position, expRadius, power/distance* 1.5f);
        }
    }

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        _gameObject = GetComponent<GameObject>();
    }

    void DisableObject()
    {
        if (isCheck) {
            
            Manager_Boss2.instance.NowTrapCount--;
            isCheck = !isCheck;
            Destroy(gameObject);
            return;
        }
        isCheck = !isCheck;
        this.gameObject.SetActive(false);
        Invoke(disableObject, 2.0f);

    }

  

}
