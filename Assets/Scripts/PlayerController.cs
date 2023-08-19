using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private GameObject model;
    
    private float verticalInput;
    private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertical();

        TurnSideways();

        model.transform.localRotation = Quaternion.Euler(0, 0, 0);
        model.transform.localPosition = Vector3.zero;
    }

    private void MoveVertical()
    {
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput == 0 )
        {
            playerAnim.SetBool("isRunningForward", false);
            playerAnim.SetBool("isRunningBackward", false);
        }
        else if (verticalInput > 0)
        {
            playerAnim.SetBool("isRunningForward", true);
            playerAnim.SetBool("isRunningBackward", false);
        }
        else if (verticalInput < 0)
        {
            playerAnim.SetBool("isRunningForward", false);
            playerAnim.SetBool("isRunningBackward", true);
        }

        transform.Translate(Vector3.forward * verticalInput * runSpeed * Time.deltaTime);
    }

    private void TurnSideways()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
    }

}
