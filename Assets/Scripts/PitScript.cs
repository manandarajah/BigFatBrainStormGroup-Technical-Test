using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PitScript : MonoBehaviour
{
    private GameObject[] tries;
    private GameObject cupHolder;
    private int tryCounter = -1;

    // Start is called before the first frame update
    void Start()
    {
        tries = GameObject.FindGameObjectsWithTag("Try");
        cupHolder = GameObject.Find("CupHolder");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Color iceCreamColor = collision.gameObject.GetComponent<Renderer>().material.color,
            cupHolderColor = cupHolder.GetComponent<Renderer>().material.color;

        if (iceCreamColor.Equals(cupHolderColor))
        {
            ++tryCounter;
            tries[tryCounter].GetComponent<Image>().color = Color.red;
        }

        Destroy(collision.gameObject);

        //if (tryCounter == 2) EditorApplication.ExitPlaymode();
        if (tryCounter == 2) Application.Quit();
    }
}
