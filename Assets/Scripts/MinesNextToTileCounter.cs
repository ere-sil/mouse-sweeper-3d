using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesNextToTileCounter : MonoBehaviour
{

    private int mineValue;
    private string mineTextValue;
    private GameObject thisTile;
    private bool calculateMinesAround;
    public Material explodedGround;
    private bool ready = true;

    // Start is called before the first frame update
    void Start()
    {
        checkTags();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //This coroutine includes 
        StartCoroutine(Funcs(other));
    }

    // this checks if objects parent is mine or is not mine. If mine, changes tag to noCalcMine, and if not tag is calcMine.
    // The tag determines if the object on the bottom mine will enable either destructed mine sprite or a number that represents the mines around.
    // mines are calculated if calculateMinesAround == true
    private void checkTags()
    {
        if (transform.parent.gameObject.CompareTag("noMine"))
        {
            calculateMinesAround = true;
            gameObject.tag = "calcMine";
        }
        else if (transform.parent.gameObject.CompareTag("isMine"))
        {
            calculateMinesAround = false;
            gameObject.tag = "triggerIsMine";
            Debug.Log("Found Mine" + gameObject.tag);
        }
        else if (transform.parent.gameObject.CompareTag("BottomTile"))
        {
            calculateMinesAround = false;
        }
    }


    private IEnumerator Funcs(Collider other)
    {
        yield return new WaitForSeconds(1.5f);
        calculateMines(other);
        yield return new WaitForSeconds(2.0f);
        setNumberOrSprite(other);
    }

    //calculates mines aroud the tile
    private void calculateMines(Collider other)
    {
        if (calculateMinesAround)
        {
            if (other.gameObject!=null && other.gameObject.CompareTag("triggerIsMine"))
            {
                mineValue++;
            }
        }
    }

    //this script will either set the mine number in to the Text Mesh OR
    // change material to exploded ground, if colliding with tile marked as mine
    private void setNumberOrSprite(Collider other)
    {
        if (gameObject != null)
        {
            if (gameObject.CompareTag("MineNumber") & other.gameObject.CompareTag("calcMine"))
            {
                mineTextValue = other.gameObject.GetComponent<MinesNextToTileCounter>().mineValue.ToString();
                GetComponent<TextMesh>().text = mineTextValue;
            }
            else if (gameObject.CompareTag("MineNumber") & other.gameObject.CompareTag("triggerIsMine"))
            {
                transform.parent.GetComponent<MeshRenderer>().material = explodedGround;
                gameObject.SetActive(false);
            }
        }
    }

}
