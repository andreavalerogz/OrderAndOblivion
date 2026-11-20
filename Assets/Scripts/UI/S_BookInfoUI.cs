using TMPro;
using UnityEngine;

public class S_BookInfoUI : MonoBehaviour
{
    // pickdrop script
    [SerializeField] private S_PickDrop pickdropScript;
    [SerializeField] private GameObject bookInfoPanel;

    // texts
    public TextMeshProUGUI bookTitle;
    public TextMeshProUGUI bookGenre;

    // EVENT onChanges
    void OnEnable()
    {
        pickdropScript.onBookChanged += updateBookInfo;     // subscribe
        updateBookInfo(pickdropScript.topBookData); // we update the UI with the TOP book we saved on topbookdata
    }

    void OnDisable()
    {
        pickdropScript.onBookChanged -= updateBookInfo; // un-suscribe
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
        if (book == null) { hideBookInfo(); return; }

        bookTitle.text = book.title;
        bookGenre.text = book.genre.ToString();
        showBookInfo();
    }
}
