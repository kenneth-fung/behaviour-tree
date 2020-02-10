using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : Node {

    // Child node for this Repeater
    private Node m_childNode;

    // Integer limit to terminate the Repeater
    private int m_limit;
    
    // Constructor (takes a child Node and an integer limit)
    public Repeater(Node childNode, int limit) {
        m_childNode = childNode;
        m_limit = limit;
    }

    /// <summary>
    /// Returns Success when limit has been exceeded. Otherwise returns Running.
    /// </summary>
    /// <returns>NodeStates Success, or Running.</returns>
    public override NodeStates Evaluate() {
        m_childNode.Evaluate();
        m_limit--;

        // check if limit exceeded
        if (m_limit <= 0) {
            m_nodeState = NodeStates.SUCCESS;
            return m_nodeState;
        }

        // limit not exceeded, return Running
        m_nodeState = NodeStates.RUNNING;
        return m_nodeState;
    }
}
