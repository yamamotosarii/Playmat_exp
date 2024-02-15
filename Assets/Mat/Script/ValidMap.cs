using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidMap : MonoBehaviour
{
    float min_height;
    State m_state;
    Renderer rend;
    public Material InValidMaterial;
    Material ValidMaterial;

    enum State
    {
        Valid,
        InValid
    };
    // Start is called before the first frame update
    void Awake()
    {
        m_state = State.Valid;
        min_height = Mathf.Infinity;
        rend = GetComponent<Renderer>();
        ValidMaterial = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AutoSetAsInValid()
    {
        m_state = State.InValid;
        if (rend == null)
            Debug.LogError("something Wrong");
        rend.material = InValidMaterial;
    }

    public void SetMinHeight(float height)
    {
        if(height < min_height)
        {
            min_height = height;
        }
    }



    public void AutoAdjust(float ClipAbove)
    {
        //Debug.Log(min_height);
        if (min_height >= ClipAbove)
        {
            m_state = State.Valid;
            rend.material = ValidMaterial;
        }
        else if (min_height < ClipAbove)
        {
            m_state = State.InValid;
            rend.material = InValidMaterial;
            return;
        }
    }

    public bool isValid()
    {
        if (m_state == State.Valid)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetToDefault()
    {
        min_height = Mathf.Infinity;
        m_state = State.Valid;
        rend.material = ValidMaterial;
    }

}
