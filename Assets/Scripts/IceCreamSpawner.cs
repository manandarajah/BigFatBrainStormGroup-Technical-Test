using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamSpawner : MonoBehaviour
{
    private GameObject[] iceCreams = new GameObject[3];
    public float iceCreamDelayTime = 0, rightConrer, leftConrer;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        iceCreams[0] = GameObject.Find("Vanilla");
        iceCreams[1] = GameObject.Find("Chocolate");
        iceCreams[2] = GameObject.Find("Strawberry");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > iceCreamDelayTime)
        {
            int selectedChoice = (int) Random.Range(0, 3);
            //Debug.Log(selectedChoice);
            float xPosition = Random.Range(leftConrer, rightConrer);

            Instantiate(iceCreams[selectedChoice], new Vector3(xPosition, transform.position.y, transform.position.z), Quaternion.identity);

            currentTime = 0;
        }
    }
}
