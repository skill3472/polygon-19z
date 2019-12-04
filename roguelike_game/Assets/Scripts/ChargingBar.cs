using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingBar : MonoBehaviour
{
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
}
