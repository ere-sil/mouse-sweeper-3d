using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePiece : MonoBehaviour
{
    public int points = 200;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
       gc= FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("+200 points");
            gc.Score += points;
            Destroy(gameObject);
        }
    }
}
