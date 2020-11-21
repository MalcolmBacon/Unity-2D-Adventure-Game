using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : MonoBehaviour
{
    public Vector2 directionOfSign;
    public GameObject textBox;
    public TMP_Text text;
    public string dialog;
    public bool playerInRange;
    public GameObject playerObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
            if (PlayerFacingSign())
            {
                if (!textBox.activeInHierarchy)
                {
                    textBox.SetActive(true);
                    text.text = dialog;
                }
                else
                {
                    textBox.SetActive(false);
                }
            }
        }
        else if (!playerInRange || !PlayerFacingSign())
        {
            if (textBox.activeInHierarchy)
            {
                textBox.SetActive(false);
            }
        }
    }
    private bool PlayerFacingSign()
    {
        Vector3 lastFacingDirection = playerObject.gameObject.GetComponent<Player>().lastFacingDirection;
        if (lastFacingDirection.y == -directionOfSign.y || lastFacingDirection.x == -directionOfSign.x)
        {
            return true;
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTag"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTag"))
        {
            playerInRange = false;
        }
    }
}
