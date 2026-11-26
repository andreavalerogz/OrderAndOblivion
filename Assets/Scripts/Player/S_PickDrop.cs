using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


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

    public Transform handPosition; // position we want the book to be when we pick it up
    private Stack<S_BookInstance> booksInHand = new Stack<S_BookInstance>();
    [SerializeField] private float bookOffset = 0.002f;
    [SerializeField] private int carryBookCapacity = 3;

    public SO_Book topBookData;

    // EVENTS
    public event Action<SO_Book> onBookChanged; // EVENT if we change the book in hand!

    
    private void Update()
    {
        if (S_PlayerInputActions.instance.inputs.Player.Drop.WasPressedThisFrame())
        {
            if(!booksInHand.Count.Equals(0)) // if list is not empty (he has a book minimum in hand)
            {
                DropBook(booksInHand.Pop());
            }
        }

    }
    public void PickUpBook(S_BookInstance book)
    {
        if (booksInHand.Count >= carryBookCapacity) return;

        Debug.Log("picking up");
        book.GetComponent<Rigidbody>().isKinematic = true; // disable collisions and collider
        book.GetComponent<BoxCollider>().enabled = false;
        book.transform.SetParent(handPosition); // set parent and position (hand)

        book.transform.localPosition = Vector3.up * (booksInHand.Count * bookOffset);
        book.transform.localRotation = Quaternion.identity;
        booksInHand.Push(book); // save it in the list

        UpdateTopBook();
    }

    void DropBook(S_BookInstance book)
    {
        Debug.Log("Detaching Book: " + book);
        book.GetComponent<Rigidbody>().isKinematic = false; // enable collisions and collider
        book.GetComponent<BoxCollider>().enabled = true;
        book.transform.parent = null; // un-parent

        UpdateTopBook();
    }

    public void UpdateTopBook()
    {
        if (booksInHand.Count > 0) topBookData = booksInHand.Peek().bookData; // if he has a book -> we save the bookdata
        else topBookData = null; // if he does not -> we save it as null

        onBookChanged(topBookData); // we call the event and we send the bookdata (if theres something subscribed to it)
    }

    public S_BookInstance getTopBook()
    {
        if(booksInHand.Count != 0) return booksInHand.Peek();
        return null;
    }

    public void removeTopBook()
    {
        booksInHand.Pop();
        UpdateTopBook();
    }
}

