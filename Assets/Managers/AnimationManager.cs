using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject animationSubject;

    private RectTransform animationSubjectTransform;
    private Image animationSubjectImage;

    private Color defaultColor;
    private Vector2 defaultAnchored;
    private Quaternion defaultRotation;
    private Vector3 defaultScale;

    private Sequence sequence;

    private void Start()
    {
        animationSubjectTransform = animationSubject.GetComponent<RectTransform>();
        animationSubjectImage = animationSubject.GetComponent<Image>();

        this.defaultColor = animationSubjectImage.color;
        this.defaultAnchored = animationSubjectTransform.anchoredPosition;
        this.defaultRotation = animationSubjectTransform.rotation;
        this.defaultScale = animationSubjectTransform.localScale;
    }

    private void Reset()
    {
        if (this.sequence != null) this.sequence.Complete();
        animationSubjectImage.color = this.defaultColor;

        animationSubjectTransform.anchoredPosition = this.defaultAnchored;
        animationSubjectTransform.rotation = this.defaultRotation;
        animationSubjectTransform.localScale = this.defaultScale;
    }

    private void TweenReset(float duration, Ease ease)
    {
        this.animationSubjectImage.DOColor(this.defaultColor, duration).SetEase(ease);
        this.animationSubjectTransform.DOAnchorPos(this.defaultAnchored, duration).SetEase(ease);
        this.animationSubjectTransform.DORotateQuaternion(this.defaultRotation, duration).SetEase(ease);
        this.animationSubjectTransform.DOScale(this.defaultScale, duration).SetEase(ease);
    }

    public void DoPulse()
    {
        Reset();

        this.sequence = DOTween.Sequence();

        this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(.8f, .8f, 1f), .1f).SetEase(Ease.InBack));
        this.sequence.Join(this.animationSubjectImage.DOFade(.7f, .1f).SetEase(Ease.InBack));

        this.sequence.AppendInterval(.1f);
        this.sequence.onComplete = () => { TweenReset(.35f, Ease.OutBack); };
    }

    public void DoFlash()
    {
        Reset();

        this.sequence = DOTween.Sequence();

        for (int i = 0; i < 2; i++)
        {
            this.sequence.Append(this.animationSubjectImage.DOFade(0f, .1f).SetEase(Ease.OutQuad));
            this.sequence.AppendInterval(.15f);
            this.sequence.Append(this.animationSubjectImage.DOFade(1f, .1f).SetEase(Ease.OutQuad));
        }

        this.sequence.onComplete = () => { TweenReset(.35f, Ease.OutBack); };
    }

    public void DoShake()
    {
        Reset();

        this.sequence = DOTween.Sequence();

        this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), .2f));
        for (int i = 0; i < 10; i++)
        {
            this.sequence.Append(this.animationSubjectTransform.DORotate(new Vector3(0, 0, i % 2 == 0 ? -5f : 5f), .05f));
            this.sequence.Join(this.animationSubjectTransform.DOAnchorPos(this.defaultAnchored + new Vector2((i % 2 == 0 ? -5f : 5f), 0f), .05f));
        }

        this.sequence.onComplete = () => { TweenReset(.35f, Ease.OutQuad); };
    }

    public void DoJiggle()
    {
        Reset();

        this.sequence = DOTween.Sequence();

        this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(1.65f, .5f, 1f), .35f).SetEase(Ease.InSine));
        this.sequence.AppendInterval(.2f);

        for (int i = 0; i < 3; i++)
        {
            this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(.8f, 1.25f, 0), .15f).SetEase(Ease.OutBack));
            this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(1.25f, .8f, 0), .15f).SetEase(Ease.OutBack));
        }

        this.sequence.onComplete = () => { TweenReset(.35f, Ease.OutBack); };
    }

    public void DoTada()
    {
        Reset();
        this.sequence = DOTween.Sequence();

        this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(.3f, .3f, 1f), .2f).SetEase(Ease.InSine));
        this.sequence.Join(this.animationSubjectImage.DOFade(0f, .2f).SetEase(Ease.InSine));
        this.sequence.AppendInterval(.5f);

        this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(1.35f, 1.35f, 1f), .4f).SetEase(Ease.OutBack));
        this.sequence.Join(this.animationSubjectImage.DOFade(1f, .2f).SetEase(Ease.InSine));
        for (int i = 0; i < 10; i++)
        {
            this.sequence.Append(this.animationSubjectTransform.DORotate(new Vector3(0, 0, i % 2 == 0 ? -5f : 5f), .05f));
            this.sequence.Join(this.animationSubjectTransform.DOAnchorPos(this.defaultAnchored + new Vector2((i % 2 == 0 ? -5f : 5f), 0f), .05f));
        }

        this.sequence.onComplete = () => { TweenReset(.35f, Ease.OutQuad); };
    }

    public void DoFlip()
    {
        Reset();

        this.sequence = DOTween.Sequence();

        this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), .2f));
        for (int i = 0; i < 5; i++)
        {
            this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(i % 2 == 0 ? 1f : -1f, 1.2f, 1f), .25f).SetEase(Ease.OutQuad));
            this.sequence.AppendInterval(.1f);
            this.sequence.Append(this.animationSubjectTransform.DOScale(new Vector3(0f, 1.2f, 1f), .05f).SetEase(Ease.OutQuad));
        }

        this.sequence.onComplete = () => { TweenReset(.35f, Ease.OutQuad); };
    }
}
