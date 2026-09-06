using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // MIGRATED: New Input System namespace

public class Paddle : MonoBehaviour
{
    public float Speed = 2.0f;
    public float MaxMovement = 2.0f;

    // MIGRATED: InputAction replaces Input.GetAxis("Horizontal")
    private InputAction m_MoveAction;

    // MIGRATED: build a 1D axis composite (A/D + Left/Right arrows) equivalent to the "Horizontal" axis
    void Awake()
    {
        m_MoveAction = new InputAction("Move", InputActionType.Value);
        m_MoveAction.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/a")
            .With("Negative", "<Keyboard>/leftArrow")
            .With("Positive", "<Keyboard>/d")
            .With("Positive", "<Keyboard>/rightArrow");
    }

    // MIGRATED: enable the action while the component is active
    void OnEnable()
    {
        m_MoveAction.Enable();
    }

    // MIGRATED: disable the action when the component is inactive
    void OnDisable()
    {
        m_MoveAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float input = m_MoveAction.ReadValue<float>(); // MIGRATED: was Input.GetAxis("Horizontal")

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }
}
