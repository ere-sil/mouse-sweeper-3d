using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineCounter : MonoBehaviour
{
    public Text mineCounter1;
    public int totalMines;
    public int currentMines;
    public int flaggedMines;
    public int flaggedNoMines;
    public float newY;
    public float newY2;
    public GameObject mineFlag;
    public GameObject noMineFlag;


    // Start is called before the first frame update
    void Start()
    {
    //count the total of mines
    totalMines = GameObject.FindGameObjectsWithTag("isMine").Length;
    mineCounter1.text = totalMines.ToString();
    //currentMines = totalMines;
        
    }

    // Update is called once per frame
    void Update()
    {
        //search tiles with flag tags
        flaggedMines = GameObject.FindGameObjectsWithTag("FlagMine").Length;
        flaggedNoMines = GameObject.FindGameObjectsWithTag("FlagNoMine").Length;

        //calculate
        currentMines = totalMines - flaggedMines - flaggedNoMines;
        if(currentMines<0){
            currentMines = 0;
        }
        mineCounter1.text = currentMines.ToString();

        //on mouse click, select unrevealed tile and flag/unflag it
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 22.0f))
            {
                if(hit.transform.gameObject.tag == "noMine")
                {
                    Debug.Log("Flag on!");
                    //hit.transform.gameObject.SetActive(false);
                    //hit.transform.gameObject.GetComponent<Renderer>().enabled = false;
                     Vector3 pos = hit.transform.gameObject.transform.position;
                     pos.y =+ newY;
                     hit.transform.gameObject.transform.position = pos;
                    Instantiate(noMineFlag, hit.transform.position, hit.transform.rotation);
                     pos.y =+ newY2;
                     hit.transform.gameObject.transform.position = pos;
                    //hit.transform.gameObject.transform.position = new Vector3(transform.position.x, newY, transform.position.z);
                    //hit.transform.gameObject.tag = "FlagNoMine";
                }
                else if(hit.transform.gameObject.tag == "isMine")
                {
                    Debug.Log("Flag on!");
                    //hit.transform.gameObject.SetActive(false);
                    //hit.transform.gameObject.transform.localScale = new Vector3(0, 0, 0);
                     Vector3 pos = hit.transform.gameObject.transform.position;
                     pos.y =+ newY;
                     hit.transform.gameObject.transform.position = pos;
                    Instantiate(mineFlag, hit.transform.position, hit.transform.rotation);
                     pos.y =+ newY2;
                     hit.transform.gameObject.transform.position = pos;
                    //hit.transform.gameObject.tag = "FlagMine";
                }
                else if(hit.transform.gameObject.tag == "FlagMine")
                {
                    Debug.Log("Flag off!");
                    //hit.transform.gameObject.tag = "isMine";
                    Destroy(hit.transform.gameObject);
                    
                }
                else if(hit.transform.gameObject.tag == "FlagNoMine")
                {
                    Debug.Log("Flag off!");
                    //hit.transform.gameObject.tag = "noMine" ;
                    Destroy(hit.transform.gameObject);
                }
            }
        
        }
        
    }
    //when tile is flagged, show how many mines remain
    //doesn't tell if the flagged tile was correct
    void CountMines()
    {


    }

    /*
    void PutFlag(GameObject go)
    {

    }
    */

}
