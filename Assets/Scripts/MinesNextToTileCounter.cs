using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesNextToTileCounter : MonoBehaviour
{

    public int mineValue;
    private GameObject thisTile;
    private bool calculateMinesAround;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.gameObject.CompareTag("isMine") == false)
        {
            calculateMinesAround = true;
            Debug.Log("this mine child found its parent and went to bed" + calculateMinesAround);
        }
        else
        {
            gameObject.tag = "calcMine";
        }
        Debug.Log("Mine tag = " + gameObject.tag);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (calculateMinesAround == true)
        {
            if (other == gameObject.CompareTag("isMine"))
            {
                mineValue++;
            }
        }
    }

}
