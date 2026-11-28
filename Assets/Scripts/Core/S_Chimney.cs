using UnityEngine;

public class S_Chimney : MonoBehaviour, I_Interact
{
    S_BookInstance bookBurned;

    public void Interact(GameObject player)
    {
        bookBurned = S_BookManager.instance.getTopBook(); // we get the one which is going to be burned
        S_BookManager.instance.removeTopBook(); // we remove it from the list ("burn it")

        SO_Book bookData = bookBurned.GetComponent<S_BookInstance>().bookData;
        S_BookRegistry.instance.setBooksDecision(bookData.ID, BOOK_STATE.Burned);
        Destroy(bookBurned.gameObject);
        Debug.Log("Book " + bookData.title + " burned");
        S_BookRegistry.instance.DebugBookRegistry();
    }
}
