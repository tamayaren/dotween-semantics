using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartupManager : MonoBehaviour
{
    [SerializeField]
    private GameObject background;
    private Image backgroundImage;

    [SerializeField]
    private GameObject uiMain;

    [SerializeField]
    private float duration = .35f;

    [SerializeField]
    private Ease ease = Ease.OutQuad;

    void Start()
    {
        background.SetActive(true);
        backgroundImage = background.GetComponent<Image>();

        uiMain.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        StartCoroutine(DoStartupSequence());
    }

    private IEnumerator DoStartupSequence()
    {
        yield return new WaitForSeconds(.4f);
        uiMain.transform.DOScale(new Vector3(1f, 1f, 1f), this.duration).SetEase(this.ease);
        backgroundImage.DOFade(0, this.duration).SetEase(this.ease).onComplete = () =>
        {
            background.SetActive(false);
        };
    }
}
