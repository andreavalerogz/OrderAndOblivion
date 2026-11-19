using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class S_PickDropBooks : MonoBehaviour
{
    /* 
     what i need to pick up a book:
    first, if the players presses E
        - raycast and if its a book
        - if he donesnt habe his hands full
    he picks it up
    for droping
        - he has to have a book

    it doesnt have to be super fast (more tedious)
     */

    [SerializeField] private float maxDistance = 10f;

    public Transform handPosition; // position we want the book to be when we pick it up
    private Stack<GameObject> booksInHand = new Stack<GameObject>();
    [SerializeField] private float bookOffset = 0.002f;
    [SerializeField] private int carryBookCapacity = 3;

    LayerMask bookMask;
    void Awake()
    {
        bookMask = LayerMask.GetMask("Book");
    }
    private void Update()
    {
        if (S_PlayerInputActions.instance.inputs.Player.Interact.WasPressedThisFrame()) // player presses E
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, bookMask))
            {
                Debug.Log("Did Hit");
                if(booksInHand.Count < carryBookCapacity) PickUpBook(hit.collider.gameObject); // if he has less than the carry capacity, we pick it up
            }
        }
        if (S_PlayerInputActions.instance.inputs.Player.Drop.WasPressedThisFrame())
        {
            if(!booksInHand.Count.Equals(0)) // if list is not empty (he has a book minimum in hand)
            {
                DropBook(booksInHand.Pop());
            }
        }

    }
    void PickUpBook(GameObject book)
    {
        book.GetComponent<Rigidbody>().isKinematic = true; // disable collisions and collider
        book.GetComponent<Collider>().enabled = false;
        book.transform.SetParent(handPosition); // set parent and position (hand)

        book.transform.localPosition = Vector3.up * (booksInHand.Count * bookOffset);
        book.transform.localRotation = Quaternion.identity;
        booksInHand.Push(book); // save it in the list
    }


    void DropBook(GameObject book)
    {
        Debug.Log("Detaching Book: " + book);
        book.GetComponent<Rigidbody>().isKinematic = false; // enable collisions and collider
        book.GetComponent<Collider>().enabled = true;
        book.transform.parent = null; // un-parent
    }


}

