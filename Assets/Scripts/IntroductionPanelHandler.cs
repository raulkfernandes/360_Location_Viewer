using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionPanelHandler : MonoBehaviour
{
    [SerializeField] private Image menuNavigationIcon;
    [SerializeField] private Sprite[] menuNavigationSprites;

    [SerializeField] private CameraMovementHandler cameraMovementHandler;
    [SerializeField] private GameObject selectionMenu;
    private CursorHandler cursorHandler;

    private bool isAnimationRunning = true;
    private bool hasSpriteChanged = false;

    //  Desabilita 'SelectionMenu', Cursor e Movimenta��o da C�mera:
    private void Awake()
    {
        this.cursorHandler = this.selectionMenu.GetComponent<CursorHandler>();
        this.selectionMenu.SetActive(false);
        this.SetCameraMovement(false);
    }

    //  Inicia Coroutine para alternar Sprites de Menu:
    private void Start()
    {
        StartCoroutine(this.ToggleMenuNavigationSprites());
    }

    //  Enquanto 'AnimationClip' estiver ativa, alterna Sprites a cada 1s:
    private IEnumerator ToggleMenuNavigationSprites()
    {
        while (this.isAnimationRunning)
        {
            this.ChangeSprite(this.hasSpriteChanged);
            yield return new WaitForSeconds(1f);
        }
    }

    //  Modifica a sprite dentre as duas op��es dispon�veis:
    private void ChangeSprite(bool hasSpriteChagned)
    {
        int spriteIndex = hasSpriteChagned ? 0 : 1;
        this.menuNavigationIcon.sprite = this.menuNavigationSprites[spriteIndex];
        this.hasSpriteChanged = !this.hasSpriteChanged;
    }

    //  Chamado ao final do 'AnimationClip' para encerrar anima��o e liberar cena:
    public void EnableCameraMovement()
    {
        this.EnableSelectionMenu();
        this.SetCameraMovement(true);
    }

    //  Habilita/Desabilita Cursor e Script de movimenta��o de c�mera na cena:
    private void SetCameraMovement(bool isEnabled)
    {
        this.SetCursorState(isEnabled);
        this.cameraMovementHandler.enabled = isEnabled;
    }

    //  Altera configura��es do Cursor:
    private void SetCursorState(bool isEnabled)
    {
        Cursor.lockState = isEnabled ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isEnabled;
        if (isEnabled)
            this.cursorHandler.SetSceneryCursor();
    }

    //  Habilita 'Selection_Menu' e Desabilita 'Introduction_Panel':
    private void EnableSelectionMenu()
    {
        this.selectionMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
