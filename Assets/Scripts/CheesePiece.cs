using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePiece : MonoBehaviour
{
    public int points = 200;
    private GameController gc;
    private bool isAvailable;
    // Start is called before the first frame update
    void Start()
    {
       gc= FindObjectOfType<GameController>();
        isAvailable = true;
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isAvailable)
        {
            isAvailable = false;
            Debug.Log("+200 points");
            gc.Score += points;
            StartCoroutine(coolDown());
            Destroy(gameObject);
        }
    }
    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(2);
        isAvailable = true;
    }
}
