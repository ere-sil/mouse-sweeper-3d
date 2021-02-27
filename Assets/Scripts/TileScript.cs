using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public GameObject explosion;
    private AudioManager audiomanager;
    private GameObject player;
    private bool isMine;
    private GameObject gameController;
    public Material highlight;
    public Material normal;
    private bool isHighlighted;

    // Start is called before the first frame update
    void Start()
    {
        audiomanager = FindObjectOfType<AudioManager>();
        player = GameObject.FindWithTag("Player");
        if (gameObject.CompareTag("isMine"))
        {
            isMine = true;
        }
        else isMine = false;
        isHighlighted = false;
    }

    // Update is called once per frame
    void Update()
    {
        changeTileColor();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& isMine){
            
            Debug.Log("Mine here");
            if (!player.GetComponent<PlayerController>().hasShieldPU) player.GetComponent<PlayerController>().currentHearts--;
            else
            {
                player.GetComponent<PlayerController>().hasShieldPU = false;
                Destroy(GameObject.FindGameObjectWithTag("ShieldPU"));
            }
            if (player.GetComponent<PlayerController>().currentHearts <= 0)//last life=big explosion
            {
                audiomanager.Play("BigExplosion");                
                Vector3 playerPos = new Vector3(player.transform.position.x-3, player.transform.position.y, player.transform.position.z);
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                //not the last life=small explosion
                audiomanager.Play("SmallExplosion");
                Vector3 playerPos= new Vector3(player.transform.position.x-3, player.transform.position.y, player.transform.position.z);
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player") && !isMine)
        {     //somebody should check if & could be used instead of && because if playing as Player, && ignores !isMine
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 8);//uncover some of the nearby tiles
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("noMine"))
                {
                    if (Random.Range(0, 2) == 1)//50% chance of being uncovered
                        Destroy(hitCollider.gameObject);
                }
            }

            Destroy(gameObject);                                        //if Player is true
            Debug.Log("No mine here");
            audiomanager.Play("FreeTile");

        }
    }
    //the following script changes color of all mine-tagged tiles by pressing h from keyboard
    private void changeTileColor()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (isHighlighted == true)
            {
                isHighlighted = false;
            }
            else
            {
                isHighlighted = true;
            }
        }
        if (gameObject.CompareTag("isMine") & isHighlighted == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = highlight;
        }
        else if (gameObject.CompareTag("isMine") & isHighlighted == false)
        {
            gameObject.GetComponent<MeshRenderer>().material = normal;
        }
    }
}
