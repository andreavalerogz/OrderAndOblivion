using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class S_BookSlot : MonoBehaviour, I_Interact
{
    [SerializeField] Transform anchor; // where the middle of book should be (just in case)
    public S_BookInstance currentBook { get; private set; } // book in the slot
    public bool isFree => currentBook == null; // if its free or not (default depends on the current book) 

    // place
    [SerializeField] private Vector3 bookPlacedSize = new Vector3(3f, 3f, 3f);
    [SerializeField] private Transform inFrontAnchor;
    [SerializeField] private float transitionTime = .3f;
    private Vector3 bookOriginalSize;
    private Vector3 bookSize;
    Vector3 oldBookPosition;
    Quaternion oldBookRotation;
    Coroutine placeAnim;
    // function to try to place it
    public bool tryToPlace(S_BookInstance book)
    {
        if (!isFree) return false; // if it isnt free returns false
        // if it is free, we save the book in currentBook and we place it in the anchor (and we parent the book to it) returns true
        currentBook = book;
        placeAnim = StartCoroutine(PlaceBook(book));
        return true;
    }

    // function to take off a book (it returns the book so we can get it in hand again)
    public S_BookInstance takeBookOff()
    {
        var bookTaken = currentBook;
        currentBook = null;
        bookTaken.transform.localScale = bookOriginalSize;
        return bookTaken;
    }

    public void Interact(GameObject player)
    {
        S_PickDrop PickDropScript = player.GetComponent<S_PickDrop>();

        if (isFree)
        {
            Debug.Log("placing book");
            S_BookInstance topBook = PickDropScript.getTopBook();
            if (topBook != null)
            {
                bool isBookPlaced = tryToPlace(topBook);
                if (isBookPlaced)
                {
                    Debug.Log("book placed");
                    PickDropScript.removeTopBook();
                }
            }
        }
        else
        {
            PickDropScript.PickUpBook(takeBookOff());
        }
    }

    /*
    IEnumerator PlaceBook(S_BookInstance book, float transitionDuration, Vector3 newPosition, Quaternion newRotation)
    {
        book.transform.SetParent(anchor, true);

        bookOriginalSize = book.transform.localScale;
        oldBookPosition = book.transform.localPosition;
        oldBookRotation = book.transform.localRotation;

        for (float i = 0; i < transitionDuration; i += Time.deltaTime)
        {
            float k = i / transitionDuration;
            book.transform.localPosition = Vector3.Lerp(oldBookPosition, newPosition, k);
            book.transform.localScale = Vector3.Lerp(bookOriginalSize, bookPlacedSize, k);
            book.transform.localRotation = Quaternion.Slerp(oldBookRotation, newRotation, k);
            yield return null;
        }
        book.transform.localPosition = newPosition; book.transform.localRotation = Quaternion.identity; book.transform.localScale = bookPlacedSize;
    }*/

    IEnumerator PlaceBook(S_BookInstance book)
    {
        bookOriginalSize = book.transform.localScale;
        book.transform.SetParent(anchor, true);
        Vector3 frontPoint = anchor.InverseTransformPoint(inFrontAnchor.position);
        yield return MoveBook(book, frontPoint, Quaternion.identity, bookPlacedSize, transitionTime);
        yield return MoveBook(book, Vector3.zero, Quaternion.identity, bookPlacedSize, transitionTime);

    }

    IEnumerator MoveBook(S_BookInstance book, Vector3 newPosition, Quaternion newRotation, Vector3 newScale, float transitionDuration)
    {
        // read values and save them
        bookSize = book.transform.localScale;
        oldBookPosition = book.transform.localPosition;
        oldBookRotation = book.transform.localRotation;

        // loop
        for (float i = 0; i < transitionDuration; i += Time.deltaTime)
        {
            float k = i / transitionDuration;
            book.transform.localPosition = Vector3.Lerp(oldBookPosition, newPosition, k);
            book.transform.localScale = Vector3.Lerp(bookSize, newScale, k);
            book.transform.localRotation = Quaternion.Slerp(oldBookRotation, newRotation, k);
            yield return null;
        }
        // set just in case
        book.transform.localPosition = newPosition; 
        book.transform.localRotation = newRotation; 
        book.transform.localScale = newScale;
    }
}
