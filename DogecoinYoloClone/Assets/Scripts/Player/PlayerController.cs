using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public enum StockState
    {
        Default = 0,
        Up = 1,
        UpOrDownMore = 2,
        Down = -1,
        
    }

    public StockState currentState;

    private Rigidbody body;

    [SerializeField] private float xSpeed = 0.1f;
    [Space]
    [SerializeField] private float ySpeed = 0.1f;

    private GameObject value;
    private Collider currentCollider;
    private StockState tempState;
    private float targetY;
    int currentCoinValue;


    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        value = GameObject.Find("Value");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentState != StockState.UpOrDownMore)
        {
            EventManager.OnCubeFinished?.Invoke();
            if (currentState == StockState.Default)
            {
                currentState = StockState.Up;
                EventManager.OnPressedUp?.Invoke();
            }

            else if (currentState == StockState.Up)
            {
                currentState = StockState.Down;
                EventManager.OnPressedDown?.Invoke();
            }

            else if (currentState == StockState.Down)
            {
                currentState = StockState.Up;
                EventManager.OnPressedUp?.Invoke();
            }


        }
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case StockState.Default:
                body.transform.position += Vector3.right * xSpeed;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                tempState = StockState.Default;
                break;
            case StockState.Up:
                body.transform.position += Vector3.right * xSpeed;
                body.transform.position += Vector3.up * ySpeed;
                transform.localRotation = Quaternion.Euler(0, 0, -15);
                tempState = StockState.Up;
                break;
            case StockState.Down:
                body.transform.position += Vector3.right * xSpeed;
                body.transform.position += Vector3.down * ySpeed;
                transform.localRotation = Quaternion.Euler(0, 0, 15);
                tempState = StockState.Down;
                break;
            case StockState.UpOrDownMore:
                MoreUpOrDown(currentCollider);
                break;

        }
    }

    public void MoreUpOrDown(Collider collider )
    {
     

        if(collider.GetComponent<Multiplier>().isMultiplier==true)
        {           

                if (body.transform.position.y < targetY / 100f)
                {
                    float multiplierSpeed = (float)currentCoinValue / 75f;
                    body.transform.position += Vector3.up * ySpeed * multiplierSpeed;
                    transform.localRotation = Quaternion.Euler(0, 0, -90);
                }
                else
                {
                    currentState = tempState;
                    EventManager.OnCubeFinished?.Invoke();
                    if(currentState == StockState.Up)
                    {
                        EventManager.OnPressedUp?.Invoke();
                    }
                    else
                    {
                        EventManager.OnPressedDown?.Invoke();
                    }                    
                }   
        }

        if (collider.GetComponent<Multiplier>().isMultiplier == false)
        {               
                if (body.transform.position.y > targetY / 100f)
                {
                    float multiplierSpeed = (float)currentCoinValue / 75f;
                    body.transform.position += Vector3.down * ySpeed * multiplierSpeed;
                    transform.localRotation = Quaternion.Euler(0, 0, 90);
                }
                else
                {
                    currentState = tempState;
                    EventManager.OnCubeFinished?.Invoke();
                    if (currentState == StockState.Up)
                    {
                        EventManager.OnPressedUp?.Invoke();
                    }
                    else
                    {
                        EventManager.OnPressedDown?.Invoke();
                    }
                
                }
            
         

           
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ValueChanger")
        {
            EventManager.OnCubeFinished?.Invoke();
            currentCollider = other;
            if(other.GetComponent<Multiplier>().isMultiplier == true)
            {
                currentCoinValue = value.GetComponent<Value>().coinValue;
                targetY = (float)currentCoinValue * (float)other.GetComponent<Multiplier>().multValue;
                EventManager.OnPressedUp?.Invoke();
                
            }
            else
            {
                currentCoinValue = value.GetComponent<Value>().coinValue;
                targetY = (float)currentCoinValue / (float)other.GetComponent<Multiplier>().multValue;
                EventManager.OnPressedDown?.Invoke();
                
            }
            
            currentState = StockState.UpOrDownMore;
        }

        if(other.tag == "Ground")
        {
            EventManager.OnCubeFinished?.Invoke();
            EventManager.OnPressedDown?.Invoke();
            currentState = StockState.Default;
        }
    }


}
