using System;
using System.Collections.Generic;
using UnityEngine;

// MANAGES ALL THE INFORMAPTION OF THE PLAYERS BOOKS (SINGLETON)
public class S_BookManager : MonoBehaviour
{
    public static S_BookManager instance;

    public Stack<S_BookInstance> booksInHand = new Stack<S_BookInstance>();
    public SO_Book topBookData;

    // LIST OF BOOKS of the DAY
    public List<GameObject> booksInWorkDay = new List<GameObject>();

    // EVENTS
    public event Action<SO_Book> onBookChanged; // EVENT if we change the book in hand!

    private void Awake()
    {
        if (instance != null && instance != this) // destroy if we already have one
        {
            Destroy(gameObject);
            return;
        }
        instance = this; // instance and dont destroy just in case

        getBooks();
    }

    public void UpdateTopBook()
    {
        if (booksInHand.Count > 0) topBookData = booksInHand.Peek().bookData; // if he has a book -> we save the bookdata
        else topBookData = null; // if he does not -> we save it as null

        onBookChanged(topBookData); // we call the event and we send the bookdata (if theres something subscribed to it)
    }

    public S_BookInstance getTopBook()
    {
        if (booksInHand.Count != 0) return booksInHand.Peek();
        return null;
    }

    public void removeTopBook()
    {
        booksInHand.Pop();
        UpdateTopBook();
    }

    // get all child books
    private void getBooks()
    {
        foreach (Transform child in transform)
        {
            if(CompareTag("Book"))
            {
                booksInWorkDay.Add(child.gameObject);
            }
        }
    }
}
