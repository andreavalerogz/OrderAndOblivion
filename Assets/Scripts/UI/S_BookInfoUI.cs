using TMPro;
using UnityEngine;

public class S_BookInfoUI : MonoBehaviour
{
    [SerializeField] private GameObject bookInfoPanel;

    // texts
    public TextMeshProUGUI bookTitle;
    public TextMeshProUGUI bookGenre;

    // EVENT onChanges
    void OnEnable()
    {
        S_BookManager.instance.onBookChanged += updateBookInfo;     // subscribe
        updateBookInfo(S_BookManager.instance.topBookData); // we update the UI with the TOP book we saved on topbookdata
    }

    void OnDisable()
    {
        S_BookManager.instance.onBookChanged -= updateBookInfo; // un-suscribe
    }

    public void showBookInfo()
    {
        bookInfoPanel.SetActive(true);
    }

    public void hideBookInfo()
    {
        bookInfoPanel.SetActive(false);
    }

    public void updateBookInfo(SO_Book book)
    {
        if (book == null) { 
            hideBookInfo(); 
            return; 
        }

        bookTitle.text = book.title;
        bookGenre.text = book.genre.ToString();
        showBookInfo();
    }
}
