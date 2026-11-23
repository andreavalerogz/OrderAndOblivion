using UnityEngine;

public class S_BookInstance : MonoBehaviour, I_Interact
{
    public SO_Book bookData;

    public void Interact(GameObject player)
    {
        player.GetComponent<S_PickDrop>().PickUpBook(this.GetComponent<S_BookInstance>());
    }
}
