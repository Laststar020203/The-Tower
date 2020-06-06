using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_FootHoldTrap : MonoBehaviour {

    private List<int> number = new List<int>();
    public static Manager_FootHoldTrap instance;




	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void inputNumber(int value , FootHoldCtrl obj)
    {
        Debug.Log(obj.gameObject.name);

        if(value == 0)
        {

            obj.isFall = true;
        }
        else
        {
            

            number.Add(value);
            if (number.Count == 1) return;
            obj.isFall = CheckNumber(value);
        }
      
        
    }

    bool CheckNumber(int value)
    {
        return number[number.Count - 2] + 1 != value;
    }
}
