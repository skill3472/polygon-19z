using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingBar : MonoBehaviour
{

    private Quaternion initRootation;
    private float initPositionX;
    private float initPositionY;
    private Vector3 initPositon;

    void Start()
    {
        initRootation = this.transform.rotation;
        initPositionX = this.transform.localPosition.x;
        initPositionY = this.transform.localPosition.y;
    }

    public void Progress(float percent)
    {
        Vector3 maskTransformScale = this.GetComponentInChildren<SpriteMask>().gameObject.transform.localScale;
        if (percent != 0)
            if (this.GetComponentInChildren<SpriteMask>().gameObject.transform.localScale.x >= 1f)
            {
                this.GetComponentInChildren<SpriteMask>().gameObject.transform.localScale += new Vector3(-1f, 0f, 0f);
            } else
            {
                this.GetComponentInChildren<SpriteMask>().gameObject.transform.localScale += new Vector3(percent / 100, 0f, 0f);
            }
        {
            
        }
    }

    private void LateUpdate()
    {
        this.transform.rotation = initRootation;
        this.transform.localPosition = new Vector3(0f, 0f);
        Vector3 parentScale = this.transform.parent.localScale;
        this.transform.position = this.transform.parent.position + new Vector3(initPositionX * parentScale.x, initPositionY * parentScale.y);

    }
}
