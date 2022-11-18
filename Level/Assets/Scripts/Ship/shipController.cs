using UnityEngine;

public class shipController : MonoBehaviour
{
    [SerializeField] GameObject shipCam;
    [SerializeField] GameObject[] sails;
    [SerializeField] GameObject sailsUp;
    [SerializeField] GameObject sailsDown;
    [SerializeField] GameObject playerPos;
    [SerializeField] shipMovement shipMove;
    //[SerializeField] Animator anim;

    public bool controllingShip;
    public bool onShip;

    // Update is called once per frame
    void Update()
    {
        if(onShip && Input.GetKeyDown(KeyCode.E))
        {
            gameManager.instance.CurrentObjectiveMiniMapIcon();
            gameManager.instance.hint.SetActive(false);
            gameManager.instance.playerScript.enabled = controllingShip;
            gameManager.instance.mainCamera.SetActive(controllingShip);
            gameManager.instance.playerScript.anim.enabled = !gameManager.instance.playerScript.anim.enabled;
            gameManager.instance.shipControllerScript = this;

            if(shipMove.wake.isPlaying)
            {
                shipMove.wake.Stop();
            }

            if (shipMove.aud.isPlaying)
                shipMove.aud.Stop();


            sailsUp.SetActive(controllingShip);
            sailsDown.SetActive(!controllingShip);
            shipMove.enabled = !controllingShip;
            shipCam.SetActive(!controllingShip);
            controllingShip = !controllingShip;

            if (shipMove.enabled == false)
                shipMove.speed = 0;
            //if(anim != null)
            //    anim.SetBool("PlayerControllingShip", controllingShip);
        }
        if (shipCam.activeSelf)
            ChangeParent();
        else
        {
            RevertParent();
        }

        gameManager.instance.playerScript.MapSelect();
    }

    void ChangeParent()
    {
        gameManager.instance.player.transform.position = playerPos.transform.position;
        gameManager.instance.player.transform.rotation = playerPos.transform.rotation;
        gameManager.instance.player.transform.parent = transform;
    }

    void RevertParent()
    {
        gameManager.instance.player.transform.parent = null;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.instance.hint.SetActive(true);
            onShip = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.instance.hint.SetActive(false);
            onShip = false;
        }
    }
}
