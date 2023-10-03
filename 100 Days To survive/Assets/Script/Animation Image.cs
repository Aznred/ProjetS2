using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public GameObject[] pages; // Tableau contenant les pages du livre

    // Méthode appelée lorsque vous appuyez sur le bouton 1
    public void ShowPage1()
    {
        ShowPage(0);
    }

    // Méthode appelée lorsque vous appuyez sur le bouton 2
    public void ShowPage2()
    {
        ShowPage(1);
    }

    // Méthode appelée lorsque vous appuyez sur le bouton 3
    public void ShowPage3()
    {
        ShowPage(2);
    }

    // Méthode appelée lorsque vous appuyez sur le bouton 4
    public void ShowPage4()
    {
        ShowPage(3);
    }

    // Méthode appelée lorsque vous appuyez sur le bouton 5
    public void ShowPage5()
    {
        ShowPage(4);
    }

    // Méthode appelée lorsque vous appuyez sur le bouton 6
    public void ShowPage6()
    {
        ShowPage(5);
    }

    // Méthode pour afficher une page spécifique et masquer les autres
    private void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (i == pageIndex)
            {
                pages[i].SetActive(true);
            }
            else
            {
                pages[i].SetActive(false);
            }
        }
    }
}

