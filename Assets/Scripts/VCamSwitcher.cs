using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamSwitcher : MonoBehaviour
{
    [SerializeField]
    public GameObject[] gameObjects;

    public GameObject lastActive;


    public void SwitchTo(int i)
    {
        if (lastActive != null)
        {
            lastActive.SetActive(false);
        }

        gameObjects[i].SetActive(true);
        lastActive = gameObjects[i];
    }

    // Use this for initialization
    void Start()
    {
        SwitchTo(1);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Q))) { SwitchTo(0); }
        if ((Input.GetKey(KeyCode.Q))) { SwitchTo(1); }
        if ((Input.GetKey(KeyCode.Q))) { SwitchTo(2); }
        if ((Input.GetKey(KeyCode.Q))) { SwitchTo(3); }


    }
}
