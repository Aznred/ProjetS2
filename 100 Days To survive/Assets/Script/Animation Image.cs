using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public GameObject[] pages; 


    public void ShowPage1()
    {
        ShowPage(0);
    }


    public void ShowPage2()
    {
        ShowPage(1);
    }

    public void ShowPage3()
    {
        ShowPage(2);
    }

    public void ShowPage4()
    {
        ShowPage(3);
    }


    public void ShowPage5()
    {
        ShowPage(4);
    }

    public void ShowPage6()
    {
        ShowPage(5);
    }


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

