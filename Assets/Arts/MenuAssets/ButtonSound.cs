using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Button button;

    void Start()
    {
        // Obt�m o componente Button
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Reproduz o som de passar o mouse por cima
        AudioManager.Instance.PlaySFX("mousehover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // P�ra o som de passar o mouse por cima
        //hoverAudioSource.Stop();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

            AudioManager.Instance.PlaySFX("mouseclick");
    }

}
