using System.Collections.Generic;
using UnityEngine;

public class S_BookRegistry : MonoBehaviour
{
    public static S_BookRegistry instance;

    // book registry dictornaty (we save the id and the BookDecision made)
    private Dictionary<int, D_BookDecision> bookDecisions = new Dictionary<int, D_BookDecision>();
    [SerializeField] int day = 0;

    private void Awake()
    {
        if (instance != null && instance != this) // destroy if we already have one
        {
            Destroy(gameObject);
            return;
        }
        instance = this; // instance and dont destroy just in case
    }

    public void setBooksDecision(int bookID, BOOK_STATE status)
    {
        D_BookDecision bookDecisionAuxiliar;
        if (!bookAlreadyExists(bookID))
        {
            bookDecisionAuxiliar = new D_BookDecision(bookID, status, day);
            bookDecisions.Add(bookID, bookDecisionAuxiliar);
        }
        else
        {
            bookDecisionAuxiliar = getBookDecision(bookID);
            bookDecisionAuxiliar.setBookDecision(status, day);
        }
    }

    bool bookAlreadyExists(int ID)
    {
        foreach(int bookID in bookDecisions.Keys)
        {
            if (bookID == ID) return true;
        }
        return false;
    }

    D_BookDecision getBookDecision(int ID)
    {
        foreach (int bookID in bookDecisions.Keys)
        {
            if (bookID == ID) return bookDecisions[ID];
        }
        return null;
    }

    void setNewDay()
    {
        day++;
    }
    
    public void DebugBookRegistry()
    {
        foreach (var book in bookDecisions)
        {
            D_BookDecision bookDecisionAuxiliar = bookDecisions[book.Key];
            Debug.Log("Libro: " + book.Key + ": State - " + bookDecisionAuxiliar.getBookState() + " Day - " + bookDecisionAuxiliar.getBookDecisionDate());
        }
    }

}
