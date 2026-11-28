using System;
using System.Collections.Generic;
using UnityEngine;

// MANAGES THE BOOK PICK UP AND DROP (HAND)
public class S_PickDrop : MonoBehaviour
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

    S_BookManager bookManagerSC;

    public Transform handPosition; // position we want the book to be when we pick it up
    [SerializeField] private float bookOffset = 0.002f;
    [SerializeField] private int carryBookCapacity = 3;

    private void Start()
    {
        bookManagerSC = S_BookManager.instance;
    }

    private void Update()
    {
        if (S_PlayerInputActions.instance.inputs.Player.Drop.WasPressedThisFrame())
        {
            if(!bookManagerSC.booksInHand.Count.Equals(0)) // if list is not empty (he has a book minimum in hand)
            {
                DropBook(bookManagerSC.booksInHand.Pop());
            }
        }

    }
    public void PickUpBook(S_BookInstance book)
    {
        if (bookManagerSC.booksInHand.Count >= carryBookCapacity) return;

        Debug.Log("picking up");
        book.GetComponent<Rigidbody>().isKinematic = true; // disable collisions and collider
        book.GetComponent<BoxCollider>().enabled = false;
        book.transform.SetParent(handPosition); // set parent and position (hand)

        book.transform.localPosition = Vector3.up * (bookManagerSC.booksInHand.Count * bookOffset);
        book.transform.localRotation = Quaternion.identity;
        bookManagerSC.booksInHand.Push(book); // save it in the list

        bookManagerSC.UpdateTopBook();
    }

    void DropBook(S_BookInstance book)
    {
        Debug.Log("Detaching Book: " + book);
        book.GetComponent<Rigidbody>().isKinematic = false; // enable collisions and collider
        book.GetComponent<BoxCollider>().enabled = true;
        book.transform.parent = null; // un-parent

        bookManagerSC.UpdateTopBook();
    }

    
}

