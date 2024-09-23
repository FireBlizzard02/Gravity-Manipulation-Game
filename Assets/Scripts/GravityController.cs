using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public GameObject player;
    public GameObject shadow;
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            shadowPosition();
            ToggleAllRenderers();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            shadowPosition();
            shadow.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
            shadow.transform.position += new Vector3(0,4,0);
            ToggleAllRenderers();
            if(Input.GetKeyDown(KeyCode.Return)){
                player.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
                // playerPosition();
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            shadowPosition();
            shadow.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z -90);
            shadow.transform.position += new Vector3(-3,2,0);
            ToggleAllRenderers();
            if(Input.GetKeyDown(KeyCode.Return)){
                player.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z-90);
                // playerPosition();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            shadowPosition();
            shadow.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);
            shadow.transform.position += new Vector3(3,2,0);
            ToggleAllRenderers();
            if(Input.GetKeyDown(KeyCode.Return)){
                player.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z+90);
                // playerPosition();
            }
        }
    }

    public void ToggleAllRenderers()
    {
        foreach (SkinnedMeshRenderer renderer in skinnedMeshRenderers)
        {
            renderer.enabled = !renderer.enabled;
        }
    }

    public void shadowPosition()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 playerRotation = player.transform.eulerAngles;
        Vector3 playerScale = player.transform.localScale;

        shadow.transform.position = playerPosition;
        shadow.transform.eulerAngles = playerRotation;
        shadow.transform.localScale = playerScale;
    }

    public void playerPosition(){
        Vector3 shadowposition = shadow.transform.position;
        Vector3 shadowRotation = shadow.transform.eulerAngles;
        Vector3 shadowScale = shadow.transform.localScale;

        player.transform.position = shadowposition;
        player.transform.eulerAngles = shadowRotation;
        player.transform.localScale = shadowScale;
    }    

}
