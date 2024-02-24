using UnityEngine;
using UnityEngine.Events;

public class ArrowInputType_KeyboardDroneOldWayMono : MonoBehaviour
{


    public KeyCode m_rotateLeft         = KeyCode.F;
    public KeyCode m_rotateRight        = KeyCode.H;
    public KeyCode m_moveUp         = KeyCode.T;
    public KeyCode m_moveDown       = KeyCode.G;
    public KeyCode m_moveLeft       = KeyCode.J;
    public KeyCode m_moveRight      = KeyCode.L;
    public KeyCode m_moveForward    = KeyCode.I;
    public KeyCode m_moveBackward   = KeyCode.K;


    public BooleanUnityEvent m_onRotateLeft  ;
    public BooleanUnityEvent m_onRotateRight ;
    public BooleanUnityEvent m_onMoveUp      ;
    public BooleanUnityEvent m_onMoveDown    ;
    public BooleanUnityEvent m_onMoveLeft    ;
    public BooleanUnityEvent m_onMoveRight   ;
    public BooleanUnityEvent m_onMoveForward ;
    public BooleanUnityEvent m_onMoveBackward;

    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }

    void Update()
    {

        CheckButtonStateAndSendEvent( m_rotateLeft     , m_onRotateLeft  );
        CheckButtonStateAndSendEvent( m_rotateRight    , m_onRotateRight );
        CheckButtonStateAndSendEvent( m_moveUp         , m_onMoveUp      );
        CheckButtonStateAndSendEvent( m_moveDown       , m_onMoveDown    );
        CheckButtonStateAndSendEvent( m_moveLeft       , m_onMoveLeft    );
        CheckButtonStateAndSendEvent( m_moveRight      , m_onMoveRight   );
        CheckButtonStateAndSendEvent( m_moveForward    , m_onMoveForward );
        CheckButtonStateAndSendEvent(m_moveBackward     , m_onMoveBackward);
    }

    public void CheckButtonStateAndSendEvent(KeyCode button, BooleanUnityEvent eventToSend)
    {
        bool isDown = Input.GetKeyDown(button);
        bool isUp = Input.GetKeyUp(button);
        if (isDown)
            eventToSend.Invoke(true);
        if (isUp)
            eventToSend.Invoke(false);
    }
}