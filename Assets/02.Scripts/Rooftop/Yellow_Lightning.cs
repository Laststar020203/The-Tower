using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Lightning : Lightning {
    [SerializeField]
    private GameObject Dome;
	// Use this for initialization
	void Start () {
        base.Dome = Dome;
        base.Deaths();
        base.CreateDome();
    }
}
