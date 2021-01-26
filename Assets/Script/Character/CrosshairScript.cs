using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrosshairScript : MonoBehaviour
{
    public Vector2 CurrentMousePosition { get; private set; }

    public bool Inverted = false;

    public Vector2 MouseSensitivity = Vector2.zero;

    [SerializeField, Range(0.0f, 1.0f)]
    private float HorizontalPercentageConstrain;

    [SerializeField, Range(0.0f, 1.0f)]
    private float VerticalPercentageConstrain;

    private float HorizontalConstrain;
    private float VerticalConstrain;

    private Vector2 CrosshairStartingPosition;

    private Vector2 CurrentLookDelta = Vector2.zero;

    private float MinHorizontalConstrainValue;
    private float MaxHorizontalConstrainValue;
    private float MinVerticalConstrainValue;
    private float MaxVerticalConstrainValue;

    private GameInputActions InputActions;

    private void Awake()
    {
        InputActions = new GameInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.CursorActive)
        {
            AppEvents.Invoke_MouseCursorEnable(false);
        }

        //Get crosshair starting position
        CrosshairStartingPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);

        //Calculate horiozntal constrain
        HorizontalConstrain = (Screen.width * HorizontalPercentageConstrain) / 2f;
        MinHorizontalConstrainValue = -(Screen.width / 2) + HorizontalConstrain;
        MaxHorizontalConstrainValue = (Screen.width / 2) - HorizontalConstrain;

        //Calculate vertical constrain
        VerticalConstrain = (Screen.height * VerticalPercentageConstrain) / 2f;
        MinVerticalConstrainValue = -(Screen.height / 2f) + VerticalConstrain;
        MaxVerticalConstrainValue = (Screen.height / 2f) - VerticalConstrain;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CrosshairStartingPosition);
        float crosshairXPosition = CrosshairStartingPosition.x + CurrentLookDelta.x;
        float crosshairYPosition = Inverted ? CrosshairStartingPosition.y - CurrentLookDelta.y : 
                                              CrosshairStartingPosition.y + CurrentLookDelta.y;

        CurrentMousePosition = new Vector2(crosshairXPosition, crosshairYPosition);

        transform.position = CurrentMousePosition;
        Debug.Log(transform.position);
    }

    private void OnLook(InputAction.CallbackContext delta)
    {
        // Debug.Log(delta.ReadValue<Vector2>());

        Vector2 mouseDelta = delta.ReadValue<Vector2>();

        CurrentLookDelta.x += mouseDelta.x * MouseSensitivity.x;
        if(CurrentLookDelta.x >= MaxHorizontalConstrainValue ||
           CurrentLookDelta.x <= MinHorizontalConstrainValue)
        {
            CurrentLookDelta.x -= mouseDelta.x * MouseSensitivity.x;
        }

        CurrentLookDelta.y += mouseDelta.y * MouseSensitivity.y;
        if (CurrentLookDelta.y >= MaxVerticalConstrainValue ||
           CurrentLookDelta.y <= MinVerticalConstrainValue)
        {
            CurrentLookDelta.y -= mouseDelta.y * MouseSensitivity.y;
        }
    }

    private void OnEnable()
    {
        InputActions.Enable();
        InputActions.ThirdPerson.Look.performed += OnLook;
    }

    private void OnDisable()
    {
        InputActions.Disable();
        InputActions.ThirdPerson.Look.performed -= OnLook;
    }
}
