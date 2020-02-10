using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : Node {

    // Method signature for the action
    public delegate NodeStates ActionNodeDelegate();

    // Delegate that is called to evaluate the action
    private ActionNodeDelegate m_action;

    // Constructor (takes a method to set the action as)
    public ActionNode(ActionNodeDelegate action) {
        m_action = action;
    }

    /// <summary>
    /// Evaluates the delegate's method and returns the resulting NodeState.
    /// </summary>
    /// <returns>NodeStates Success, Failure, or Running.</returns>
    public override NodeStates Evaluate() {
        NodeStates result = m_action();
        switch (result) {
            case NodeStates.FAILURE:
            case NodeStates.SUCCESS:
            case NodeStates.RUNNING:
                m_nodeState = result;
                return m_nodeState;
            default:
                Debug.Log("Action (" + m_action.Method.Name + ") did not return a Node State.");
                m_nodeState = NodeStates.FAILURE;
                return m_nodeState;
        }
    }
}
