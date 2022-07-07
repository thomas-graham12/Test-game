using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float speed;

    public TextMeshProUGUI soulsCollectedText;
    public int soulsCollectedNumber;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.up = player.transform.position - transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            soulsCollectedNumber ++;

            soulsCollectedText.text = soulsCollectedNumber.ToString();


        }
    }
}
