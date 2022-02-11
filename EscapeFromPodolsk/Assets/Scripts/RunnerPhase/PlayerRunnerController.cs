using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerController : MonoBehaviour
{
    [SerializeField] float jumpTime = 2.5f;
    bool isGrounded = true;
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
           Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
           transform.Translate(touchDeltaPosition.x * 0.005f, 0, 0); // 0.005 отвечает за чувствительность слайда
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).tapCount >= 2)
        {
            if (isGrounded)
            {
                StartCoroutine(JumpCorutine());
            }
        }
    }
    IEnumerator JumpCorutine()
    {
        transform.Translate(Vector3.up * 2);
        isGrounded = false;
        float tempJumpTime = jumpTime;
        while (tempJumpTime > 0)
        {
            tempJumpTime-= 0.25f;
            yield return new WaitForSeconds(0.25f);
        }
        transform.Translate(Vector3.down * 2);
        isGrounded = true;
    }
}
