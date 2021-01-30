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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& isMine){
            
            Debug.Log("Mine here");
            player.GetComponent<PlayerController>().currentHearts--;
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
        else if (other.gameObject.CompareTag("Player") && !isMine){
            Destroy(gameObject);
            Debug.Log("No mine here");
            audiomanager.Play("FreeTile");

        }

    }
}
