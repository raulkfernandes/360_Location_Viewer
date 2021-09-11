using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionPanelHandler : MonoBehaviour
{
    [SerializeField] private CameraMovementHandler cameraMovementHandler;
    [SerializeField] private Image menuNavigationIcon;
    [SerializeField] private Sprite[] menuNavigationSprites;

    private bool isAnimationRunning = true;
    private bool hasSpriteChanged = false;

    //  Trava a movimenta��o da c�mera e a posi��o do Cursor:
    private void Awake()
    {
        this.SetCameraMovement(false);
    }

    //  Inicia Coroutine para alternar sprites de Menu:
    private void Start()
    {
        StartCoroutine(this.ToggleMenuNavigationSprites());
    }

    //  Mant�m o Cursor travado durante a anima��o:
    private void FixedUpdate()
    {
        if (this.isAnimationRunning)
            Cursor.lockState = CursorLockMode.Locked;
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
        this.cameraMovementHandler.enabled = isEnabled;
        CursorLockMode lockMode = isEnabled ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.lockState = lockMode;
    }

    //  Modifica o status da anima��o e desativa este Script:
    private void DisableAnimation()
    {
        this.isAnimationRunning = false;
        this.enabled = false;
    }
}
