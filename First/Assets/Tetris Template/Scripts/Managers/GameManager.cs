//  /*********************************************************************************
//   *********************************************************************************
//   *********************************************************************************
//   * Produced by Skard Games										                  *
//   * Facebook: https://goo.gl/5YSrKw											      *
//   * Contact me: https://goo.gl/y5awt4								              *											
//   * Developed by Cavit Baturalp Gürdin: https://tr.linkedin.com/in/baturalpgurdin *
//   *********************************************************************************
//   *********************************************************************************
//   *********************************************************************************/

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public TetrisShape currentShape;
    public Transform blockHolder;
    public PlayerStats stats;

    void Awake()
    {
        Debug.Log_cyan($"Awake", this, 2);
        isGameActive = false;
    }

    private _StatesBase currentState;
    public _StatesBase State
    {
        get { return currentState; }
    }

    //Changes the current game state
    public void SetState(System.Type newStateType)
    {
        Debug.Log_cyan($"SetState > {newStateType}", this, 2);

        if (currentState != null)
        {
            currentState.OnDeactivate();
        }

        currentState = GetComponentInChildren(newStateType) as _StatesBase;
        if (currentState != null)
        {
            currentState.OnActivate();
        }
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    void Start()
    {
        Debug.Log_cyan($"最初に呼ばれるStart > ここでMenuStateを起動している", this, 2);
        SetState(typeof(MenuState));
    }


}