using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupHolderController : MonoBehaviour
{
    public float rightConrer, leftConrer, moveSpeed;
    public Material[] materials;
    private Material selectedMat;
    private int score = 0;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //materials[0] = (Material)Resources.Load("VanillaMat", typeof(Material));
        //materials[1] = (Material)Resources.Load("ChocolateMat", typeof(Material));
        //materials[2] = (Material)Resources.Load("StrawberryMat", typeof(Material));

        selectedMat = materials[0];
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float axis = Input.GetAxis("Horizontal");

        if ((mouseX < 0 || axis < 0) && transform.position.x > leftConrer)
        {
            transform.Translate(Vector3.left * moveSpeed);
        }

        else if ((mouseX > 0 || axis > 0) && transform.position.x < rightConrer)
        {
            transform.Translate(Vector3.right * moveSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject tmp = collision.gameObject;
        //Debug.Log(tmp.GetComponent<Renderer>().material);

        if (tmp.GetComponent<Renderer>().material.color.Equals(selectedMat.color))
        {
            int matIndex = (int) Random.Range(0, 3);
            selectedMat = materials[matIndex];
            this.GetComponent<Renderer>().material = selectedMat;

            score += 10;
        }

        else
        {
            score -= 10;
        }

        scoreText.text = "Score: " + score;
        Destroy(tmp);
    }
}
