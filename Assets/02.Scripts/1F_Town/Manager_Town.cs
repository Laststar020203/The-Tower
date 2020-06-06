using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Town : MonoBehaviour {

    public GameObject chat;

	
    private void Start()
    {
        StartCoroutine(OnChat());
    }

    IEnumerator OnChat()
    {
        yield return new WaitForSeconds(1f);
        chat.SetActive(true);

    }
}
