using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionPanelHandler : MonoBehaviour
{
    [SerializeField] private CursorHandler cursorHandler;
    [SerializeField] private CameraMovementHandler cameraMovementHandler;
    [SerializeField] private Image menuNavigationIcon;
    [SerializeField] private Sprite[] menuNavigationSprites;

    private bool isAnimationRunning = true;
    private bool hasSpriteChanged = false;

    //  Trava a movimenta��o da C�mera e desabilita Cursor:
    private void Awake()
    {
        this.SetCameraMovement(false);
    }

    //  Inicia Coroutine para alternar sprites de Menu:
    private void Start()
    {
        StartCoroutine(this.ToggleMenuNavigationSprites());
    }

    //  Mant�m a movimenta��o da C�mera travada e Cursor desabilitado durante anima��o:
    private void Update()
    {
        this.SetCameraMovement(false);
    }

    //  Enquanto a anima�ao estiver ativa, alterna as sprites a cada 1s:
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

    //  Chamada ao final do AnimationClip para encerrar a anima��o e liberar a cena:
    public void EnableCameraMovement()
    {
        this.SetCameraMovement(true);
        this.DisableAnimation();
    }

    //  Habilita/Desabilita o Script de movimenta��o de c�mera Trava/Libera o Cursor na cena:
    private void SetCameraMovement(bool isEnabled)
    {
        CursorLockMode lockMode = isEnabled ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.lockState = lockMode;
        Cursor.visible = isEnabled;
        this.cameraMovementHandler.enabled = isEnabled;
        this.cursorHandler.SetSceneryCursor();
    }

    //  Modifica o status da anima��o e desativa este Script:
    private void DisableAnimation()
    {
        this.isAnimationRunning = false;
        this.enabled = false;
    }
}
