using UnityEngine;


// BOOK DECISION DATA FOR EVERY BOOK

[System.Serializable]
public class D_BookDecision
{
    [SerializeField] private int bookID;
    [SerializeField] private BOOK_STATE bookState = BOOK_STATE.None;
    [SerializeField] private int bookDecisionDate;

    // getters
    public int getBookID() { return bookID; }
    public BOOK_STATE getBookState() { return bookState; }
    public int getBookDecisionDate() { return bookDecisionDate; }

    // construction
    public D_BookDecision(int _bookID, BOOK_STATE _bookState, int _bookDecisionDate)
    {
        bookID = _bookID;
        bookState = _bookState;
        bookDecisionDate = _bookDecisionDate;
    }

    public void setBookDecision(BOOK_STATE _bookState, int _bookDecisionDate)
    {
        bookDecisionDate = _bookDecisionDate;
        bookState = _bookState;
    }
}
