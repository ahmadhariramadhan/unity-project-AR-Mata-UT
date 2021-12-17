using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public List<MainMenuComponent> panelCol  = new List<MainMenuComponent>();
    public GameObject UIPanel;
    public MainMenuComponent selectionPanel;
    public MainMenuComponent curPage;
    public MainMenuComponent targetPage;
    public int index = 0;
    public bool isPanelDone = false;

    // Start is called before the first frame update
    void Start()
    {
        panelCol = UIPanel.GetComponentsInChildren<MainMenuComponent>().ToList();
        DisableAll();
     
        if (StaticData.isDonePre)
        {
            //index = panelCol.IndexOf(selectionPanel);
            JumpToPage(selectionPanel);
        }
        else
        {
            index = 0;
           StartCoroutine(BeginMainMenuSequence());
        }
    }

    private void DisableAll()
    {
        foreach (var item in panelCol)
        {
            item.gameObject.SetActive(false);
        }
    }
    
    public void ContinueCor()
    {
        isPanelDone = true;
    }

    IEnumerator BeginMainMenuSequence()
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < panelCol.Count; i++)
        {
            isPanelDone = false;
            index = i; 
            curPage = panelCol[index];
            CanvasGroup cg = curPage.GetComponent<CanvasGroup>();
            curPage.gameObject.SetActive(true);
            cg.alpha = 0;
            LeanTween.alphaCanvas(cg, 1, .5f);
            yield return new WaitForSeconds(curPage.waitingTime);

            //WAIT FOR INPUT
            if (curPage.isWaitingAction)
            {
                //yield break;
                yield return new WaitUntil(() => isPanelDone);
            }
            LeanTween.alphaCanvas(cg, 0, .5f);
            curPage.gameObject.SetActive(false);
        }
    }

    public void JumpToPage(MainMenuComponent mainMenuComponent)
    {
        StopAllCoroutines();
        targetPage = mainMenuComponent; 
        GetCurrentActivePage();
        StartCoroutine(ChangePage());
    }

    public void GetCurrentActivePage()
    {
        foreach (var item in panelCol)
        {
            if (item.isActiveAndEnabled)
                curPage = item;
        }
    }

    IEnumerator ChangePage()
    {
        yield return new WaitForEndOfFrame();
        if (curPage != null)
        {
            CanvasGroup cgFrom = curPage.GetComponent<CanvasGroup>();
            curPage.gameObject.SetActive(true);
            cgFrom.alpha = 1;
            LeanTween.alphaCanvas(cgFrom, 0, .5f);
            yield return new WaitForSeconds(.5f);
            curPage.gameObject.SetActive(false);
        }
        CanvasGroup cgTo = targetPage.GetComponent<CanvasGroup>();
        targetPage.gameObject.SetActive(true);
        cgTo.alpha = 0;
        LeanTween.alphaCanvas(cgTo, 1, .5f);
        yield return new WaitForSeconds(.5f);
    }

    public void StoreCurrentPageAndARIndex(int _index)
    {
        curPage = selectionPanel;
        StaticData.index = _index;
        SceneLoader.Instance.LoadSceneName("ar");
    }

    public void nextPage()
    {
        StopAllCoroutines();
        index++;
        var item = panelCol[index];
        DisableAll();
        item.gameObject.SetActive(true);
        CanvasGroup cg = item.GetComponent<CanvasGroup>();
        cg.alpha = 0;
        LeanTween.alphaCanvas(cg, 1, .5f);
    }

    public void DownloadMarker(string _url){
        Application.OpenURL(_url);
    }
}
