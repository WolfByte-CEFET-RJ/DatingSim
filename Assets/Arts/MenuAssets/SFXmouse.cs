using UnityEngine;
using UnityEngine.EventSystems;

public class SFXmouse : MonoBehaviour, IPointerUpHandler
{
    // M�todo chamado quando o mouse � solto sobre o GameObject
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("O mouse foi solto!");
        // Reproduza o som aqui ou adicione a l�gica desejada
        AudioManager.Instance.PlaySFX("mouseclick");
    }
}
