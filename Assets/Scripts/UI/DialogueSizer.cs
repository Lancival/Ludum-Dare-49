using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(VerticalLayoutGroup))]
[DisallowMultipleComponent]

public class DialogueSizer : MonoBehaviour
{

	[SerializeField] private float maxWidth = 1000;
	[SerializeField] private CustomUI ui;
	[SerializeField] private float defaultDuration = 0.25f;

	private RectTransform rect;
	private VerticalLayoutGroup layout;
	private TextMeshProUGUI text;

	private IEnumerator horizontalLerp;
	private IEnumerator verticalLerp;

	void Awake()
	{
		rect = GetComponent<RectTransform>();
		layout = GetComponent<VerticalLayoutGroup>();
		text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
	}

	void Start()
    {
    	ui.onLineStart.AddListener(SetSizeOfBox);
    }

    // Temporary input
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Return))
    	{
    		ui.MarkLineComplete();
    	}
    }

	private void SetSizeOfBox()
    {
    	string line = ui.GetLine();
    	Vector2 preferredSize = text.GetPreferredValues(line);
    	if (preferredSize[0] > maxWidth - layout.padding.left - layout.padding.right)
    	{
    		rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxWidth);
    		text.text = line;
    		Canvas.ForceUpdateCanvases();
    		//rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, text.preferredHeight + layout.padding.top + layout.padding.bottom);
    		StartVerticalLerp(text.preferredHeight + layout.padding.top + layout.padding.bottom);

    		StartHorizontalLerp(maxWidth);
    	}
    	else
    	{
    		StartVerticalLerp(preferredSize[1] + layout.padding.top + layout.padding.bottom);
    		//rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredSize[1] + layout.padding.top + layout.padding.bottom);

    		StartHorizontalLerp(preferredSize[0] + layout.padding.left + layout.padding.right);
    		//rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, preferredSize[0] + layout.padding.left + layout.padding.right);
    	}
    }

    private IEnumerator LerpRectWidth(float targetValue, float duration)
    {
    	float startValue = rect.rect.width;
    	float startTime = Time.time;
    	float fraction = 0;
    	while (fraction < 1)
    	{
    		rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Lerp(startValue, targetValue, fraction));
    		fraction = (Time.time - startTime) / duration;
    		yield return new WaitForEndOfFrame();
    	}
    	rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetValue);
    	yield break;
    }

    private IEnumerator LerpRectHeight(float targetValue, float duration)
    {
    	float startValue = rect.rect.height;
    	float startTime = Time.time;
    	float fraction = 0;
    	while (fraction < 1)
    	{
    		rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Lerp(startValue, targetValue, fraction));
    		fraction = (Time.time - startTime) / duration;
    		yield return new WaitForEndOfFrame();
    	}
    	rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetValue);
    	yield break;
    }

    private void StartHorizontalLerp(float targetValue)
    {
    	if (horizontalLerp != null)
    		StopCoroutine(horizontalLerp);

    	horizontalLerp = LerpRectWidth(targetValue, defaultDuration);
    	StartCoroutine(horizontalLerp);
    }

    private void StartVerticalLerp(float targetValue)
    {
    	if (verticalLerp != null)
    		StopCoroutine(verticalLerp);

    	verticalLerp = LerpRectHeight(targetValue, defaultDuration);
    	StartCoroutine(verticalLerp);
    }
}
