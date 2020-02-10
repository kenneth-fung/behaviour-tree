using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node {

    // Child node for this Inverter
    private Node m_childNode;

    // Constructor (takes a child Node)
    public Inverter(Node childNode) {
        m_childNode = childNode;
    }

    /// <summary>
    /// Returns Success if child Node returns Failure. Returns Failure if child Node returns Success.
    /// </summary>
    /// <returns>NodeStates Success, Failure, or Running.</returns>
    public override NodeStates Evaluate() {
        switch (m_childNode.Evaluate()) {
            case NodeStates.FAILURE:
                m_nodeState = NodeStates.SUCCESS;
                return m_nodeState;
            case NodeStates.SUCCESS:
                m_nodeState = NodeStates.FAILURE;
                return m_nodeState;
            default:
                m_nodeState = NodeStates.RUNNING;
                return m_nodeState;
        }
    }
}
