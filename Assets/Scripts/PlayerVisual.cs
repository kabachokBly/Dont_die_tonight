using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] GameObject Rectangle;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector2 mousePos = GameInput.Instance.GetMousePosition();
        Vector2 playerPosition = Player.Instance.GetPlayerScreenPosition();
        if (mousePos.x < playerPosition.x)
        {
            spriteRenderer.flipX = true;
            Rectangle.transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else
        {
            spriteRenderer.flipX = false;
            Rectangle.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
