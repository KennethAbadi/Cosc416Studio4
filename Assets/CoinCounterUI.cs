using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections;
public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    private float containerInitPosition;
    private float moveAmount;
    [SerializeField] private Ease animationCurve;
    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
        
    }
    public void UpdateScore(int score){
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount,duration).SetEase(animationCurve);
        StartCoroutine(ResetCoinContainer(score));
    }
    private IEnumerator ResetCoinContainer(int score){
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x,containerInitPosition, localPosition.z);

    }

}
