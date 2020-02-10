using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node {

    public enum NodeStates { SUCCESS, FAILURE, RUNNING };

    // Delegate that returns the state of the node
    public delegate NodeStates NodeReturn();

    // Current state of the node
    protected NodeStates m_nodeState;

    // Getter for current state of the node
    public NodeStates getNodeState() {
        return m_nodeState;
    }

    // All nodes use this method to evaluate the desired set of conditions
    public abstract NodeStates Evaluate();
}
