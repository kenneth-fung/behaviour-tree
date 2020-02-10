using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatUntilFail : Node {

    // Child node for this RepeatUntilFail
    private Node m_childNode;

    // Constructor (takes a child Node)
    public RepeatUntilFail(Node childNode) {
        m_childNode = childNode;
    }

    /// <summary>
    /// Returns Success if child Node returns Failure. Otherwise returns Running.
    /// </summary>
    /// <returns>NodeStates Success, or Running.</returns>
    public override NodeStates Evaluate() {
        NodeStates result = m_childNode.Evaluate();

        // check if child result of child Node is Failure
        if (result == NodeStates.FAILURE) {
            m_nodeState = NodeStates.SUCCESS;
            return m_nodeState;
        }

        // result of child Node is not Failure, return Running
        m_nodeState = NodeStates.RUNNING;
        return m_nodeState;
    }
}
