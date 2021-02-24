using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CartScript : MonoBehaviour
{
    public Transform cart;
    public float cartSpeed;
    public float cartRadius;
    public bool isCartOccupied;

    //Villen
    public int cartGoldAmount;
    public Text goldAmountText;

    // Start is called before the first frame update
    void Start(){
        cart = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){

        // Check for radius
        LayerMask mask = LayerMask.GetMask("Player");
        if(Physics.CheckSphere(cart.transform.position, cartRadius, mask)){
            isCartOccupied = true;
        }
        else{
            if(isCartOccupied != false) { isCartOccupied = false; }
        }

        // Move cart when there is player in the radius
        if (isCartOccupied == true) {
            UpdateCartMovement();
        }
    }

    void UpdateCartMovement(){
        // Simple cart movement script, this can be updated to be more complex on later stages of development
        cart.position += transform.up * cartSpeed * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (cart != null){
            Gizmos.DrawSphere(cart.transform.position, cartRadius);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("Cart collided with: " + col.gameObject.tag);

        if (col.gameObject.tag == "pickup")
        {
            cartGoldAmount++;
            Destroy(col.gameObject);
            goldAmountText.text = "Gold: " + cartGoldAmount;
        }
    }

}
