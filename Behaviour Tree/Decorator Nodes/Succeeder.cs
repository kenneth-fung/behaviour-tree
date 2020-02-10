using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Succeeder : Node {

    // Child node for this Succeeeder
    private Node m_childNode;

    // Constructor (takes a child Node)
    public Succeeder(Node childNode) {
        m_childNode = childNode;
    }

    /// <summary>
    /// Returns Success no matter what the child Node returns.
    /// </summary>
    /// <returns>NodeStates Success.</returns>
    public override NodeStates Evaluate() {
        switch (m_childNode.Evaluate()) {
            default:
                m_nodeState = NodeStates.SUCCESS;
                return m_nodeState;
        }
    }
}
