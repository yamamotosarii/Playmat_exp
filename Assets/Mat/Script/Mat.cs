using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mat : MonoBehaviour
{
    public Shader shaderToUse;
    Renderer rend;
    State m_state;

    enum State
    {
        ValidbyAlogithm,
        InValidbyAlgorithm,
        ValidbyUser
    };

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = new Material(shaderToUse);
        m_state = State.ValidbyAlogithm;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CustomChangeColor(Color ChnagedColor)
    {
        if(m_state == State.InValidbyAlgorithm)
        {
            m_state = State.ValidbyUser;
        }
        rend.material.color = ChnagedColor;
        return;
    }



    public void AutoSetAsInValid()
    {
        if (m_state == State.InValidbyAlgorithm || m_state == State.ValidbyUser)
            return;
        m_state = State.InValidbyAlgorithm;
        if (rend != null)
            rend.material.color = new Color(0, 0, 0, 0);
    }
    public void AutoSetAsValid()
    {
        if (m_state == State.ValidbyAlogithm || m_state == State.ValidbyUser)
            return;
        m_state = State.ValidbyAlogithm;
        if(rend!=null)
            rend.material.color = new Color(1, 1, 1, 1);
    }
}
